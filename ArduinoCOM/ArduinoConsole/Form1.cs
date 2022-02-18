using ModBusManager;
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
        // Modbus Functions
        const int ReadCoils =             0x01;
        const int ReadDiscreteInputs =    0x02;
        const int ReadHoldingRegisters =  0x03;
        const int ReadInputRegisters  =   0x04;
        const int WriteSingleCoil =       0x05;
        const int WriteSingleRegiste =    0x06;
        ManualResetEvent MRE = new ManualResetEvent(false);

        // Modbus on/off
        int commandOn = 0xFF00;
        int off = 0x0000;


        // Coils
        int ledOn;
        int ledOff;
        // Holding Registers
        int minDimRegister;
        int maxDimRegister;
        int setDimRegister;
        // Input Registers
        int dimValue;
        // Discret Input
        int ledStatus;

        // Interfaces values for commands
        int setDimmerValue;


        // Internal variables
        bool isConnected = false;
        bool statusThred = false;
        String[] ports;
        TSerialManager serialport;
        byte[] requestSent;


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

        private void Connect_Button_Click(object sender, EventArgs e)
        {
            setTrasparentStatusLabel();
            if (isConnected == false)
            {
                try
                {
                    string selectedPort = this.selectedPort.GetItemText(this.selectedPort.SelectedItem);
                    serialport = new TSerialManager(selectedPort, 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
                    serialport.Open();
                    serialport.DataReceived += GetResponseModbus;
                    isConnected = true;
                    EnableCommand();
                    connectButton.Text = "Disconnect";
                    connectButton.BackColor = Color.IndianRed;
                    label1.Text = "";
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    label1.Text = "ERROR SELECT ANOTHER PORT";
                }
            }
            else
            {
                connectButton.Text = "Connect";
                connectButton.BackColor = Color.DarkSeaGreen;
                serialport.Close();
                serialport.DataReceived -= GetResponseModbus;
                isConnected = false;
                MRE.Set();
                DisableCommand();
            }
        }

        private void GetResponseModbus(object sender, SerialDataReceivedEventArgs e)
        {
            
                SerialPort serialPort = sender as SerialPort;
                if (serialPort != null)
                {
                    if (InvokeRequired)
                    {
                        this.Invoke(new MethodInvoker(delegate 
                        {
                            byte[] response = TModBusSerial.GetMessage(serialport);
                            if(response.Length > 0)
                            {
                                List<int> res = TModBusSerial.InterpreterMessage(response, requestSent, 1);

                                if (response[1] == 4)
                                {
                                    if (res[0] > 0)
                                    {
                                        onButton.BackColor = Color.DarkSeaGreen;
                                        offButton.BackColor = Color.Silver;
                                        dim.Value = res[0];
                                        dimtrack.Value = res[0];
                                    }
                                    if (res[0] == 0)
                                    {
                                        offButton.BackColor = Color.IndianRed;
                                        onButton.BackColor = Color.Silver;
                                        progressBar.Value = res[0];
                                    }
                                }
                                if (res.Count > 2)
                                {
                                    if (res[2] == 3)
                                    {
                                        minLabel.Text = res[0].ToString();
                                        maxLabel.Text = res[1].ToString();
                                    }
                                }

                                
                            }
                        }));
                    }
                }
        }

        private void SetMaxDim_ValueChanged(object sender, EventArgs e)
        {

        }

        private void SetMinDim_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void On_Id_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < idLed.Value * 2; i += 2)
            {
                ledOn = 100 + i;
                ledOff = 100 + i + 1;
            }
            for (int i = 0; i < idLed.Value * 3; i += 3)
            {
                minDimRegister = 200 + i;
                maxDimRegister = 200 + i + 1;
                setDimRegister = 200 + i + 2;
            }
            for (int i = 0; i < idLed.Value; i++)
            {
                dimValue = 100 + i;
                ledStatus = 100 + i;
            }

            if (serialport.IsOpen)
            {
                requestSent = TModBusSerial.SendMessageRead(serialport, (int)device_id.Value, ReadInputRegisters, dimValue, 1);            }
        }

        private void On_dim_ValueChanged(object sender, EventArgs e)
        {
            setDimmerValue = (int)dim.Value;
            dimtrack.Value = (int)dim.Value;
            if (serialport.IsOpen)
            {
                requestSent = TModBusSerial.SendMessageWrite(serialport, (int)device_id.Value, WriteSingleRegiste, setDimRegister, setDimmerValue);
            }
        }

        private void On_dimtrack_Scroll(object sender, EventArgs e)
        {
            setDimmerValue = dimtrack.Value;
            dim.Value = dimtrack.Value;
        }

        private void GetStatus_Click(object sender, EventArgs e)
        {
            if(statusThred == false)
            {
                statusThred = true;
                if (serialport.IsOpen)
                {
                    new Thread(() =>
                    {
                        while (!MRE.WaitOne(1000))
                        {
                            requestSent = TModBusSerial.SendMessageRead(serialport, (int)device_id.Value, ReadInputRegisters, dimValue, 1);

                        }
                    }).Start();
                }
                getStatus.BackColor = Color.SandyBrown;
                getStatus.Text = "UPDATING STATUS";
            }
            else
            {
                statusThred = false;
                getStatus.Text = "START UPDATE STATUS";
                getStatus.BackColor = Color.Silver;
                MRE.Set();
            }
        }

        private void SetDim_Click(object sender, EventArgs e)
        {
            setTrasparentStatusLabel();
            if (serialport.IsOpen)
            {
                requestSent = TModBusSerial.SendMessageWrite(serialport, (int)device_id.Value, WriteSingleRegiste, setDimRegister, setDimmerValue);   
            }
        }

        private void OffButton_Click(object sender, EventArgs e)
        {
            setTrasparentStatusLabel();
            if (serialport.IsOpen)
            {
                requestSent = TModBusSerial.SendMessageWrite(serialport, (int)device_id.Value, WriteSingleCoil, ledOff, commandOn);
            }
        }

        private void OnButton_Click(object sender, EventArgs e)
        {
            setTrasparentStatusLabel();
            if (serialport.IsOpen)
            {
                requestSent = TModBusSerial.SendMessageWrite(serialport, (int)device_id.Value, WriteSingleCoil, ledOn, commandOn);
            }
        }

        private void SetMax_Click(object sender, EventArgs e)
        {
            setTrasparentStatusLabel();
            if (serialport.IsOpen)
            {
                TModBusSerial.SendMessageWrite(serialport, (int)device_id.Value, WriteSingleRegiste, maxDimRegister, (int)maxDimValue.Value);
                dimtrack.Maximum = (int)maxDimValue.Value;
                progressBar.Maximum = (int)maxDimValue.Value;
            }
        }

        private void SetMin_Click(object sender, EventArgs e)
        {
            setTrasparentStatusLabel();
            if (serialport.IsOpen)
            {
                TModBusSerial.SendMessageWrite(serialport, (int)device_id.Value, WriteSingleRegiste, minDimRegister, (int)minDimValue.Value);
                dimtrack.Minimum = (int)minDimValue.Value;
                progressBar.Minimum = (int)minDimValue.Value;
            }
        }

        private void setTrasparentStatusLabel()
        {
            statusLabel.Visible = false;
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
            minLabel.Text = "";
            maxLabel.Text = "";
            statusLabel.Enabled = false;
            idLed.Enabled = false;
            dim.Enabled = false;
            onButton.Enabled = false;
            offButton.Enabled = false;
            setDim.Enabled = false;
            getStatus.Enabled = false;
        }
    }
}
