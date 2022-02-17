using SerialManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoConsole
{
    public partial class Form1 : Form
    {
        
        bool isConnected = false;
        String[] ports;
        SerialPort serialManager;


        public Form1()
        {
            InitializeComponent();
            getAvailableComPorts();

            foreach (string port in ports)
            {
                selectedPort.Items.Add(port);
            }
        }
        void getAvailableComPorts()
        {
            ports = SerialPort.GetPortNames();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisableCommand();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setTrasparentStatusLabel();
            selectedPort.Text = "COM PORT";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setTrasparentStatusLabel();
            if (isConnected == false)
            {
                try
                {
                    string selectedPort = this.selectedPort.GetItemText(this.selectedPort.SelectedItem);
                    serialManager = new SerialPort(selectedPort, 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
                    serialManager.Open();
                    serialManager.DataReceived += SerialManager_GetStatusResponse;
                    isConnected = true;
                    EnableCommand();
                    connectButton.Text = "Disconnect";
                    connectButton.BackColor = Color.Red;
                    label1.Text = "";
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    label1.Text = "ERROR SELECT ANOTHER PORT";
                }
            }
            else
            {
                connectButton.Text = "Connect";
                serialManager.Close();
                serialManager.DataReceived -= SerialManager_GetStatusResponse;
                isConnected = false;
            }
        }

        private void onButton_Click(object sender, EventArgs e)
        {
            setTrasparentStatusLabel();
            if (onButton.Enabled && serialManager.IsOpen )
            {
                string id = idLed.Value.ToString();
                string message = id + " on";
                serialManager.WriteLine(message);
                progressBar1.Value = 100;
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void offButton_Click(object sender, EventArgs e)
        {
            setTrasparentStatusLabel();
            if (offButton.Enabled && serialManager.IsOpen)
            {
                string id = idLed.Value.ToString();
                string message = id + " off";
                serialManager.WriteLine(message);
                progressBar1.Value = 0;
            }
        }

        private void setDim_Click(object sender, EventArgs e)
        {
            setTrasparentStatusLabel();
            if (setDim.Enabled && serialManager.IsOpen)
            {
                string id = idLed.Value.ToString();
                string val = dim.Value.ToString();
                string message = id + " dim " + val;
                serialManager.WriteLine(message);
                progressBar1.Value = (int)dim.Value;
            }
        }


        private void EnableCommand()
        {
            idLed.Enabled = true;
            dim.Enabled = true;
            onButton.Enabled = true;
            offButton.Enabled = true;
            setDim.Enabled = true;
            getStatus.Enabled = true;
        }

        private void DisableCommand()
        {
            statusLabel.Enabled = false;
            idLed.Enabled = false;
            dim.Enabled = false;
            onButton.Enabled = false;
            offButton.Enabled = false;
            setDim.Enabled = false;
            getStatus.Enabled = false;
        }

        private void getStatus_Click(object sender, EventArgs e)
        {
            if (serialManager.IsOpen)
            {
                string id = idLed.Value.ToString();
                string message = id + " get";
                serialManager.WriteLine(message);               
            }
        }

        private void SerialManager_GetStatusResponse(object sender, SerialDataReceivedEventArgs e)
        {
            
                SerialPort serialPort = sender as SerialPort;
                if (serialPort != null)
                {
                    string m = serialPort.ReadLine();
                    if (statusLabel.InvokeRequired)
                    {
                        statusLabel.Invoke(new MethodInvoker(delegate 
                        {
                            StatusResponse(m);
                        }));
                    }
                }
        }

        private void setTrasparentStatusLabel()
        {
            statusLabel.Visible = false;
        }

        private void StatusResponse(string m)
        {

            List<string> mList = new List<string>();


            //string message = "id 1 50";
            string[] subs = m.Split(' ');
            foreach (var sub in subs)
            {
                mList.Add(sub);
            }

            string[] mess = mList.ToArray();

            string type = mess[0];
            string id = mess[1];

            int brightness = int.Parse(mess[2]);
            progressBar1.Value = brightness;

            statusLabel.Visible = true;
            statusLabel.Text = "Id " + id + ": " + brightness + "%";
        }
    }
}
