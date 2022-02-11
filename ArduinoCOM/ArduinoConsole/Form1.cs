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
        List<int> ids = new List<int>();

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
                    connectButton.BackColor = Color.IndianRed;
                    label1.Text = "";

                    string message = "ids";
                    serialManager.WriteLine(message);

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
            if (onButton.Enabled && serialManager.IsOpen)
            {
                string id = idLed.Value.ToString();
                string message = id + "*on";
                string get = id + "*get";
                serialManager.WriteLine(message);
                serialManager.WriteLine(get);
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            noIdAlert.Text = "";
            if (serialManager.IsOpen)
            {
                if (ids.IndexOf((int)idLed.Value) != -1)
                {
                    string id = idLed.Value.ToString();
                    string message = id + "*get";
                    serialManager.WriteLine(message);
                }
                else
                {
                    noIdAlert.Text = "NO EXISTIG ID";
                }

            }
        }

        private void offButton_Click(object sender, EventArgs e)
        {
            setTrasparentStatusLabel();
            if (offButton.Enabled && serialManager.IsOpen)
            {
                string id = idLed.Value.ToString();
                string message = id + "*off";
                string get = id + "*get";
                serialManager.WriteLine(message);
                serialManager.WriteLine(get);
            }
        }

        private void setDim_Click(object sender, EventArgs e)
        {
            setTrasparentStatusLabel();
            if (setDim.Enabled && serialManager.IsOpen)
            {
                string id = idLed.Value.ToString();
                string val = dim.Value.ToString();
                string message = id + "*dim*" + val;
                string get = id + "*get";
                serialManager.WriteLine(message);
                serialManager.WriteLine(get);
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
                string message = id + "*get";
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

            string[] subs = m.Split('*');
            foreach (var sub in subs)
            {
                mList.Add(sub);
            }

            string[] mess = mList.ToArray();
            string type = mess[0];
            switch (type)
            {
                //case "set":
                //    int led = int.Parse(mess[1]);
                //    int br = int.Parse(mess[2]);
                //    if (led == idLed.Value)
                //    {
                //        progressBar1.Value = br;
                //    }
                //    break;
                case "get":
                    string id = mess[1];
                    int brightness = int.Parse(mess[2]);
                    progressBar1.Value = brightness;
                    statusLabel.Visible = true;
                    statusLabel.Text = "Led " + id + ": " + brightness + "%";
                    break;
                case "ids":
                    try
                    {
                        for (int i = 1; i < mess.Length; i++)
                        {
                            ids.Add(int.Parse(mess[i]));
                        }
                    }
                    catch
                    {}
                    break;
            }
        }
    }
}
