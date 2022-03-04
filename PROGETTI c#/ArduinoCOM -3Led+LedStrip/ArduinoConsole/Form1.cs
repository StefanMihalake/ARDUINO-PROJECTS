using ArduinoConsole.Device;
using ArduinoConsole.Devices;
using ModBusManager;
using SerialManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        bool canRefresh = false;
        int updateTime = 100;


        // password list
        List<string> password = new List<string>() { "pass", "ciao" };

        bool admin = false;

        // leds istance
        TLed led1 = new TLed(1, false, 100, 101, 200, 201, 202, 100, 101, 102);
        TLed led2 = new TLed(2, false, 102, 103, 203, 204, 205, 103, 104, 105);
        TLed led3 = new TLed(3, false, 104, 105, 206, 207, 208, 106, 107, 108);
        TLedStrip ledStrip = new TLedStrip(4, false, 209, 210, 211, 212);


        List<TLed> leds = new List<TLed>();

        // thred reset and stop
        ManualResetEvent MRE = new ManualResetEvent(false);
        bool CanWork;


        // Modbus Functions
        const byte ReadCoils = 0x01;
        const byte ReadDiscreteInputs = 0x02;
        const byte ReadHoldingRegisters = 0x03;
        const byte ReadInputRegisters = 0x04;
        const byte WriteSingleCoil = 0x05;
        const byte WriteSingleRegiste = 0x06;

        // Modbus on/off
        int commandOn = 0xFF00;


        // Write Coils
        int ledOn;
        int ledOff;

        // Write Holding Registers
        int minDimWrite;
        int maxDimWrite;
        int dimWrite;

        // Read Input Registers
        int dimRead;
        int minDimRead;
        int maxDimRead;

        // Discret Input
        int ledStatus;

        // Internal variables
        bool isConnected = false;
        String[] ports;

        // TSerialManager serialport;
        SerialPort serialport;

        // NeoPixel 
        int r;
        int g;
        int b;
        int lr;
        int lg;
        int lb;

        TabPage AdminPageControl;

        public Form1()
        {
            InitializeComponent();
            getAvailableComPorts();

            foreach (string port in ports)
            {
                selectComPort.Items.Add(port);
            }
            selectComPort.Text = "SELECT COM PORT";
        }

        void getAvailableComPorts()
        {
            ports = SerialPort.GetPortNames();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisableCommand();
            leds.Add(led1);
            leds.Add(led2);
            leds.Add(led3);

        }

        private void Connect_Button_Click(object sender, EventArgs e)                           // Connect to the selected Com Port
        {
            if (isConnected == false)
            {
                try
                {
                    //string selectedPort = this.selectedPort.GetItemText(this.selectedPort.SelectedItem);
                    string selectedPort1 = this.selectComPort.GetItemText(this.selectComPort.SelectedItem);
                    //serialport = new TSerialManager(selectedPort, 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
                    serialport = new SerialPort(selectedPort1, 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
                    serialport.Open();
                    CanWork = true;
                    serialport.DataReceived += GetResponseModbus;
                    isConnected = true;
                    //EnableCommand();
                    connectButton.Text = "Disconnect";
                    connectButton.BackColor = Color.IndianRed;
                    Update_Interface(updateTime);
                    portErrorLabel.Text = "";
                    MRE.Reset();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    portErrorLabel.Visible = true;
                    portErrorLabel.Text = "ERROR SELECT ANOTHER PORT";
                }
            }
            else
            {
                CanWork = false;
                MRE.Set();
                connectButton.Text = "Connect";
                connectButton.BackColor = Color.DarkSeaGreen;
                serialport.DataReceived -= GetResponseModbus;
                isConnected = false;
                DisableCommand();
                serialport.Close();
            }
        }               

        private void Update_Interface(int updateTime)                                           // Start updating the user interface when click the connect button
        {
            if (serialport.IsOpen)
            {
                new Thread(() =>
                {
                    while (!MRE.WaitOne(updateTime))
                    {
                        TModBusSerial.SendMessageRead(serialport, (byte)slave_id.Value, ReadInputRegisters, dimRead, 3);
                    }
                }).Start();
            }
        }       


        private void GetResponseModbus(object sender, SerialDataReceivedEventArgs e)            // Methon that start another thread, take all the responses and filter them
        {
            try
            {
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        byte[] response = TModBusSerial.GetMessage(serialport);

                        // 1. Function code 
                        // 4. Dimmer value
                        // 6. Min dimmer value
                        // 8. Max dimmer value

                        if (response.Length > 0)                    // response not empty
                        {
                            switch (response[1])
                            {
                                case 4:
                                    EnableCommand();
                                    if (response[4] > 0)                                          // if the brightness is > than 0
                                    {
                                        onButton.BackColor = Color.DarkSeaGreen;
                                        offButton.BackColor = Color.Silver;
                                        int value = (int)Math.Round((decimal)(response[4]) * 100 / 255);
                                        progressbar.Value = value;
                                        dimLed.Visible = true;
                                        dimLed.Text = value.ToString();
                                    }
                                    if (response[4] == 0)               // if the brightness is = 0
                                    {
                                        offButton.BackColor = Color.IndianRed;
                                        onButton.BackColor = Color.Silver;
                                        progressbar.Value = 0;
                                        dimLed.Text = "OFF";
                                    }
                                    if (response[6] == 0)                // if min brightnes is default
                                    {
                                        minValueLabel.Text = "10%";
                                        minUserLabel.Text = "10%";
                                    }
                                    else
                                    {
                                        int min = (int)Math.Round((decimal)(response[6]) * 100 / 255);
                                        minValueLabel.Text = min.ToString() + "%";
                                        minUserLabel.Text = min.ToString() + "%";
                                        dimtrack.Minimum = min;
                                    }
                                    if (response[8] == 0)                 // if max brightnes is default
                                    {
                                        maxValueLabel.Text = "100%";
                                        maxUserLabel.Text = "100%";
                                    }
                                    else
                                    {
                                        int max = (int)Math.Round((decimal)(response[8]) * 100 / 255);
                                        maxValueLabel.Text = max.ToString() + "%";
                                        maxUserLabel.Text = max.ToString() + "%";
                                        dimtrack.Maximum = max;
                                    }
                                    break;

                                case 132:
                                    errorResponseLabel.Visible = true;
                                    errorResponseLabel.Text = "Exception Response Memory Parity Error: 132 (84 hex)";

                                    WriteError($"{DateTime.UtcNow} - Exception Response: 132 (84 hex)");
                                    break;

                                default:
                                    WriteError($"{DateTime.UtcNow} - Exception Response: {response[1]}");
                                    break;
                            }


                        }
                        else if (response.Length == 0)
                        {
                            // CRC CORUPT
                        }

                    }));
                }
            }
            catch (Exception err)
            {
                Console.WriteLine($"Error:  {err.Message}");
            }

        }         

        private void On_Id_ValueChanged(object sender, EventArgs e)                             // If change the device id all the addresses use for updating the interface change for that id
        {
            ResetCamp();

            noIdLabel.Text = "NO LED WITH ID ";
            foreach (var led in leds)
            {
                if (admin && !disableControls.Checked)
                {
                    if (deviceId.Value == led.Id)
                    {
                        ledOn = led.LedOnWriteCoil;
                        ledOff = led.LedOffWriteCoil;

                        minDimWrite = led.MinWriteReg;
                        maxDimWrite = led.MaxWriteReg;
                        dimWrite = led.DimWriteReg;

                        dimRead = led.DimReadReg;
                        minDimRead = led.DimReadReg;
                        maxDimRead = led.MaxReadReg;

                        noIdLabel.Visible = false;
                        noIdLabel.Text = "";
                        canRefresh = true;
                    }
                }
                if(!admin)
                {
                    if (deviceId.Value == led.Id && led.AdminRequire == false)
                    {
                        ledOn = led.LedOnWriteCoil;
                        ledOff = led.LedOffWriteCoil;

                        minDimWrite = led.MinWriteReg;
                        maxDimWrite = led.MaxWriteReg;
                        dimWrite = led.DimWriteReg;

                        dimRead = led.DimReadReg;
                        minDimRead = led.DimReadReg;
                        maxDimRead = led.MaxReadReg;

                        noIdLabel.Visible = false;
                        noIdLabel.Text = "";
                        canRefresh = true;
                    }
                }

            }
        }                                                   


        private void On_dim_ValueChanged(object sender, EventArgs e)                            // If change the dim numeric set the brightness to the select value
        {
            int setDimmerValue = (int)dim.Value*255/100;
            if (serialport.IsOpen)
            {
                TModBusSerial.SendMessageWrite(serialport, (byte)slave_id.Value, WriteSingleRegiste, dimWrite, setDimmerValue);
            }
        }                         

        private void On_dimTrack_ValueChanged(object sender, EventArgs e)                       // If change the track value set the brightness
        {
            int a = (int)dimtrack.Value * 255 / 100;
            dim.Value = dimtrack.Value;
            //if (serialport.IsOpen)
            //{
            //    TModBusSerial.SendMessageWrite(serialport, (byte)device_id.Value, WriteSingleRegiste, dimWrite, a);
            //}
        }                     



        private void OffButton_Click(object sender, EventArgs e)                                // Turn Off the led
        {
            if (serialport.IsOpen)
            {
               TModBusSerial.SendMessageWrite(serialport, (byte)slave_id.Value, WriteSingleCoil, ledOff, commandOn);
            }
        }                             

        private void OnButton_Click(object sender, EventArgs e)                                 // Turn On the led
        {
            if (serialport.IsOpen)
            {
                TModBusSerial.SendMessageWrite(serialport, (byte)slave_id.Value, WriteSingleCoil, ledOn, commandOn);
            }
        }                              


        private void SetMax_Click(object sender, EventArgs e)                                   // Change minimum value for the led brightness
        {
            if (serialport.IsOpen)
            {
                TModBusSerial.SendMessageWrite(serialport, (byte)slave_id.Value, WriteSingleRegiste, maxDimWrite, (int)maxDimValue.Value * 255 / 100);
            }
        }                                

        private void SetMin_Click(object sender, EventArgs e)                                   // Change maximmum value for the led brightness
        {
            if (serialport.IsOpen)
            {
                TModBusSerial.SendMessageWrite(serialport, (byte)slave_id.Value, WriteSingleRegiste, minDimWrite, (int)minDimValue.Value * 255 / 100);
            }
        }                                


        private void LoginAdmin_Click(object sender, EventArgs e)                               // When Login the set min and max brightness value shows
        {
            string pass = passwordTextBox.Text;

            if (password.Contains(pass))
            {
                admin = true;
                AdminGroup.Visible = false;
                passwordNotValidLabel.Text = "";
                adminLabel.Visible = true;
                disableControls.Visible = true;
                minDimValue.Visible = true;
                maxDimValue.Visible = true;
                setMinButton.Visible = true;
                setMaxButton.Visible = true;
                passwordTextBox.ResetText();
                minLabel.Visible = true;
                maxLabel.Visible = true;
                minValueLabel.Visible = true;
                maxValueLabel.Visible = true;
                disableControls.Enabled = true;
                //tabControl1.TabPages.Add(AdminPageControl);
                //tabControl1.SelectedTab = AdminPageControl;
                //checkBox2.Click += AdminCheck;
                //checkBox2.CheckedChanged += ciao;
            }
            else
            {
                passwordNotValidLabel.Text = "PASSWORD NOT VALID!";
            }

        }                            

        private void DisableControls_CheckedChanged(object sender, EventArgs e)                 // Log out from admin and hide set min and max button
        {
            if (disableControls.Checked)
            {
                admin = false;
                adminLabel.Visible = false;
                disableControls.Enabled = false;
                minDimValue.Visible = false;
                maxDimValue.Visible = false;
                minValueLabel.Text = "";
                maxValueLabel.Text = "";
                minValueLabel.Visible = false;
                maxValueLabel.Visible = false;
                minLabel.Visible = false;
                maxLabel.Visible = false;
                setMinButton.Visible = false;
                setMaxButton.Visible = false;
                disableControls.Checked = false;
                disableControls.Visible = false;
                AdminGroup.Visible = true;
            }
        }              


        private void ResetCamp()                                                                // Reset the old id values camp
        {   
            ledOn = 0;
            ledOff = 0;

            minDimWrite = 0;
            maxDimWrite = 0;
            dimWrite = 0;

            dimRead = 0;
            minDimRead = 0;
            maxDimRead = 0;

            maxValueLabel.Text = "";
            minValueLabel.Text = "";

            noIdLabel.Visible = true;
        }                                                             

        private void EnableCommand()
        {
            AdminGroup.Visible = true;
            AdminGroup.Enabled = true;
            deviceId.Enabled = true;
            dim.Enabled = true;
            onButton.Enabled = true;
            offButton.Enabled = true;
            slave_id.Enabled = true;
            disableControls.Enabled = true;
            dimtrack.Enabled = true;

            errorResponseLabel.Visible = false;
        }

        private void DisableCommand()
        {
            errorResponseLabel.Visible = false;
            dimtrack.Enabled = false;
            dimLed.Visible = false;
            AdminGroup.Visible = true;
            AdminGroup.Enabled = false;
            adminLabel.Visible = false;
            disableControls.Enabled = false;
            minDimValue.Visible = false;
            maxDimValue.Visible = false;
            minLabel.Visible = false;
            maxLabel.Visible = false;
            minValueLabel.Text = "";
            maxValueLabel.Text = "";
            minUserLabel.Text = "";
            maxUserLabel.Text = "";
            setMinButton.Visible = false;
            setMaxButton.Visible = false;
            //slave_id.Enabled = false;
            passwordNotValidLabel.Text = "";
            minValueLabel.Visible = false;
            maxValueLabel.Visible = false;
            noIdLabel.Visible = false;
            portErrorLabel.Visible = false;
            //deviceId.Enabled = false;
            dim.Enabled = false;
            onButton.Enabled = false;
            offButton.Enabled = false;
            disableControls.Visible = false;
        }

        private void WriteError(string message)
        {
            if (!File.Exists("ErrorsFile.txt"))
            {
                // Creating the same file if it doesn't exist
                using (StreamWriter sw = File.CreateText("ErrorsFile.txt"))
                {
                    sw.WriteLine($" -----------------------");
                    sw.WriteLine($" ");
                    sw.WriteLine($" ERROR: {message}");
                    sw.WriteLine($" ");
                    sw.WriteLine($" -----------------------");
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText("ErrorsFile.txt"))
                {
                    sw.WriteLine($" -----------------------");
                    sw.WriteLine($" ");
                    sw.WriteLine($" ERROR: {message}");
                    sw.WriteLine($" ");
                    sw.WriteLine($" -----------------------");
                }
            }
        }


        // Test method
        private void SetDim_Click(object sender, EventArgs e)
        {
            if (serialport.IsOpen)
            {
                TModBusSerial.SendMessageWrite(serialport, (byte)slave_id.Value, WriteSingleRegiste, dimWrite, dimWrite);
            }
        }


        // Empty method
        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void SetMaxDim_ValueChanged(object sender, EventArgs e)
        {

        }
        private void SetMinDim_ValueChanged(object sender, EventArgs e)
        {

        }
        private void AdminCheck(object sender, EventArgs e)
        {
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void colorpicker_Click(object sender, EventArgs e)
        {
            r = colorpicker.SelectedColor.R;
            g = colorpicker.SelectedColor.G;
            b = colorpicker.SelectedColor.B;

            lr = colorpicker.SelectedColor.R;
            lg = colorpicker.SelectedColor.G;
            lb = colorpicker.SelectedColor.B;
            colorpanel.BackColor = Color.FromArgb(r, g, b);

            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, ledStrip.RWriteReg, r);
            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, ledStrip.GWriteReg, g);
            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, ledStrip.BWriteReg, b);
        }

        private void onPixel_Click(object sender, EventArgs e)
        {
            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, ledStrip.RWriteReg, lr);
            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, ledStrip.GWriteReg, lg);
            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, ledStrip.BWriteReg, lb);
        }

        private void offPixel_Click(object sender, EventArgs e)
        {
            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, ledStrip.RWriteReg, 0);
            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, ledStrip.GWriteReg, 0);
            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, ledStrip.BWriteReg, 0);
        }

        private void colorDialog_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            r = colorDialog1.Color.R;
            g = colorDialog1.Color.G;
            b = colorDialog1.Color.B;

            lr = colorpicker.SelectedColor.R;
            lg = colorpicker.SelectedColor.G;
            lb = colorpicker.SelectedColor.B;
            int w = (int)(colorDialog1.Color.GetBrightness() * 240);

            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, ledStrip.RWriteReg, r);
            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, ledStrip.GWriteReg, g);
            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, ledStrip.BWriteReg, b);
            //TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, 209, w);
            colorpanel.BackColor = Color.FromArgb(r, g, b);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, ledStrip.BrightnessWriteReg, (int)brightnessSet.Value);
        }
    }
}



