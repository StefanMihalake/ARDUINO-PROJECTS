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
            getAvailableComPorts();                                                 //ask for available com ports

        }
        void getAvailableComPorts()
        {
            ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                selectedPort.Items.Add(port);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisableCommand();                                                       // disable all comand til get the connection on
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setTrasparentStatusLabel();                                             // set trasparent the get information area
            selectedPort.Text = "COM PORT";
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            setTrasparentStatusLabel();
            if (isConnected == false)
            {
                try
                {
                    string selectedPort = this.selectedPort.GetItemText(this.selectedPort.SelectedItem);                   // get the selected port
                    serialManager = new SerialPort(selectedPort, 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);       // create connection with the port selected
                    serialManager.Open();                                               // open the port
                    serialManager.DataReceived += SerialManager_GetStatusResponse;      // if there is any respons send to the Serial response Manager 
                    isConnected = true;
                    EnableCommand();                                                    // enable comand
                    connectButton.Text = "Disconnect";
                    connectButton.BackColor = Color.IndianRed;
                    errorPortAlert.Text = "";                                           // set void alert

                    string message = "ids";                                             
                    serialManager.WriteLine(message);                                   // ask the ids to arduino

                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    errorPortAlert.Text = "ERROR SELECT ANOTHER PORT";
                }
            }
            else
            {
                DisableCommand();
                progressBar1.Value = 0;
                connectButton.BackColor = Color.DarkSeaGreen;
                connectButton.Text = "Connect";                                         // if disconnect from the port set the label name
                serialManager.Close();                                                  // close the com port
                serialManager.DataReceived -= SerialManager_GetStatusResponse;          
                isConnected = false;
            }
        }

        private void onButton_Click(object sender, EventArgs e)
        {
            setTrasparentStatusLabel();                                                 // set trasparent the get information area
            if (serialManager.IsOpen)
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
            if (serialManager.IsOpen)
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
            if (serialManager.IsOpen)
            {
                
                string id = idLed.Value.ToString();
                string val = dim.Value.ToString();
                string message = id + "*dim*" + val;
                string get = id + "*get";
                serialManager.WriteLine(message);
                serialManager.WriteLine(get);
                trackDim.Value = (int)dim.Value;
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
                case "set":
                    int led = int.Parse(mess[1]);
                    int br = int.Parse(mess[2]);
                    if (led == idLed.Value)
                    {
                        progressBar1.Value = br;
                        dim.Value = br;
                        trackDim.Value = br;
                    }
                    break;
                case "get":
                    string id = mess[1];
                    int brightness = int.Parse(mess[2]);
                    progressBar1.Value = brightness;
                    dim.Value = brightness;
                    trackDim.Value = brightness;
                    statusLabel.Visible = true;
                    dim.Value = brightness;
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

        private void trackDim_Scroll(object sender, EventArgs e)
        {
            setTrasparentStatusLabel();
            if (serialManager.IsOpen)
            {
                string id = idLed.Value.ToString();
                string val = trackDim.Value.ToString();
                dim.Value = trackDim.Value;
                //string message = id + "*dim*" + val;
                //string get = id + "*get";
                //serialManager.WriteLine(message);
                //serialManager.WriteLine(get);
            }
        }
    }
}
