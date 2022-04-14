using ArduinoConsole.Device;
using ArduinoConsole.Devices;
using CommunicationArduinoModbusMqtt.Mqtt;
using ModBusManager;
using MQTTnet;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Extensions.ManagedClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ArduinoConsole
{
    public partial class ArduinoForm : Form
    {

        MqttClientOptionsBuilder builder;

        // Create client options objects
        ManagedMqttClientOptions options;

        // Creates the client object
        IManagedMqttClient _mqttClient;

        // Topics
        string topicToPublishLed = "Mosaico/UffProgrammazione/Prime11/Arduino/Set/Led";

        bool canRefresh = false;
        bool workerArduino;
        int updateTime = 500;


        // password list
        List<string> password = new List<string>() { "pass", "ciao" };

        bool admin = false;

        // leds istance
        TLed led1 = new TLed(1, false, 100, 101, 200, 201, 202, 100, 101, 102);
        TLed led2 = new TLed(2, false, 102, 103, 203, 204, 205, 103, 104, 105);
        TLed led3 = new TLed(3, false, 104, 105, 206, 207, 208, 106, 107, 108);
        TLedStrip ledStrip = new TLedStrip(4, false, 209, 210, 211, 212);
        

        List<int> ids = new List<int>();
        List<string> operations = new List<string>() { "on", "off", "dim", "min", "max", "brightness", "rgb" };

        // Name of items use for user interface update
        string[] component = { "Led1", "Led2", "Led3", "Strip" };

        // List of led and strip use for set 
        List<TLed> leds = new List<TLed>();
        List<TLedStrip> ledStrips = new List<TLedStrip>();

        // thred reset and stop
        ManualResetEvent MRE = new ManualResetEvent(false);

        //  MODBUS ADDRESSES
        int _startCoil = 100;
        int _startHReg = 200;
        int _startIReg = 100;
        int _startDIReg = 100;

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


        // Mqtt led strip
        int On;
        int Off;

        int ledminDimWrite;
        int ledmaxDimWrite;
        int leddimWrite;

        int leddimRead;
        int ledminDimRead;
        int ledmaxDimRead;


        int R;
        int G;
        int B;
        int pixelbrighness;

        // Internal variables
        bool isConnected = false;
        String[] ports;

        // TSerialManager serialport;
        SerialPort serialport;

        // FORM NeoPixel 
        int r;
        int g;
        int b;
        int lr;
        int lg;
        int lb;

        int itemId;


        public ArduinoForm()
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
            ledStrips.Add(ledStrip);

            ids.Add(led1.Id);
            ids.Add(led2.Id);
            ids.Add(led3.Id);
            ids.Add(ledStrip.Id);
        }

        private void Connect_Button_Click(object sender, EventArgs e)                           // Connect to the selected Com Port
        {
            if (isConnected == false)
            {
                try
                {
                    string selectedPort1 = this.selectComPort.GetItemText(this.selectComPort.SelectedItem);     // selected port from interface
                    serialport = new SerialPort(selectedPort1, 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);     // create serialPort connection
                    serialport.Open();
                    serialport.DataReceived += GetResponseModbus;                                // if any response pass it to delegate method 
                    isConnected = true;
                    //EnableCommand();
                    connectButton.Text = "Disconnect";
                    connectButton.BackColor = Color.IndianRed;
                    Update_Interface(updateTime);
                    portErrorLabel.Text = "";
                    MRE.Reset();                                                                // if stop the connection reset when restart
                }
                catch (ArgumentException ex)
                {
                    portErrorLabel.Visible = true;
                    portErrorLabel.Text = "ERROR SELECT ANOTHER PORT";
                }
            }
            else
            {                                                               
                workerArduino = false;                                                          // close the mqtt client
                MRE.Set();                                                                      // close the get status Modbus Thread
                connectButton.Text = "Connect";
                connectButton.BackColor = Color.DarkSeaGreen;
                serialport.DataReceived -= GetResponseModbus;
                isConnected = false;
                DisableCommand();
                serialport.Close();                                                             // close serial port
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
                        //TModBusSerial.SendMessageRead(serialport, (byte)slave_id.Value, ReadInputRegisters, dimRead, 3);
                        //Thread.Sleep(50);
                        TModBusSerial.SendMessageRead(serialport, (byte)slave_id.Value, ReadInputRegisters, 100, 13);
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
                        byte[] response = TModBusSerial.GetMessage(serialport);     // response from modbus

                        JObject items = Separator(response);                            // parse response in json and send to mqtt topic

                        string varString = JsonConvert.SerializeObject(items);      // strig for controlling length
                        
                        if (items.Count > 0)                                   // if json have items
                        {
                            bool checkedId = false;
                            foreach (var item in leds)                              
                            {
                                if (deviceId.Value == item.Id)                      // if selected id is one of the respons items
                                {
                                    checkedId = true;
                                }
                            }
                            if (checkedId)
                            {
                                var comp = component[(int)deviceId.Value - 1];

                                switch (comp)
                                {
                                    case "Led1":
                                    case "Led2":
                                    case "Led3":
                                        EnableCommand();
                                        if ((int)items[comp]["Dim"] > 0)                // if the brightness is > than 0
                                        {
                                            onButton.BackColor = Color.DarkSeaGreen;
                                            offButton.BackColor = Color.Silver;
                                            int value = (int)Math.Round((decimal)((int)items[comp]["Dim"]) * 100 / 255);
                                            if (progressbar.Value != value)
                                            {
                                                progressbar.Value = value;
                                            }
                                            dimLed.Visible = true;
                                            dimLed.Text = value.ToString() + "%";
                                        }
                                        else if ((int)items[comp]["Dim"] == 0)               // if the brightness is = 0
                                        {
                                            offButton.BackColor = Color.IndianRed;
                                            onButton.BackColor = Color.Silver;
                                            progressbar.Value = 0;
                                            dimLed.Text = "OFF";
                                        }
                                        if ((int)items[comp]["Min"] == 0)                // if min  is default
                                        {
                                            minValueLabel.Text = "10%";
                                            minUserLabel.Text = "10%";
                                            maxDimValue.Minimum = 10;
                                            dim.Minimum = 10;
                                            dimtrack.Minimum = 10;
                                        }
                                        else
                                        {
                                            int min = (int)Math.Round((decimal)((int)items[comp]["Min"]) * 100 / 255);
                                            minValueLabel.Text = min.ToString() + "%";
                                            minUserLabel.Text = min.ToString() + "%";
                                            maxDimValue.Minimum = min;
                                            dim.Minimum = min;
                                            dimtrack.Minimum = min;
                                        }
                                        if ((int)items[comp]["Max"] == 0)                 // if max  is default
                                        {
                                            maxValueLabel.Text = "100%";
                                            maxUserLabel.Text = "100%";
                                            minDimValue.Maximum = 100;
                                            dim.Maximum = 100;
                                            dimtrack.Maximum = 100;
                                        }
                                        else
                                        {
                                            int max = (int)Math.Round((decimal)((int)items[comp]["Max"]) * 100 / 255);
                                            maxValueLabel.Text = max.ToString() + "%";
                                            maxUserLabel.Text = max.ToString() + "%";
                                            minDimValue.Maximum = max;
                                            dim.Maximum = max;
                                            dimtrack.Maximum = max;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                // No item with selected id
                            }

                            if ((int)items["Strip"]["R"] == 0 && (int)items["Strip"]["G"] == 0 && (int)items["Strip"]["B"] == 0)                // if the brightness is > than 0
                            {
                                offPixel.BackColor = Color.IndianRed;
                                onPixel.BackColor = Color.Silver;
                                
                            }
                            else               // if the brightness is = 0
                            {
                                onPixel.BackColor = Color.DarkSeaGreen;
                                offPixel.BackColor = Color.Silver;
                                colorpanel.BackColor = Color.FromArgb((int)items["Strip"]["R"], (int)items["Strip"]["G"], (int)items["Strip"]["B"]);
                            }
                            int val = (int)Math.Round((decimal)((int)items["Strip"]["Brightness"]) * 100 / 255);
                            brightnessLabel.Text = val.ToString() + "%";
                        }


                    }));
                }
            }
            catch (Exception err)
            {
                Console.WriteLine($"Error:  {err.Message}");
            }

        }

        private JObject Separator(byte[] response)                                      // separate the response in items 
        {
            if (response.Length > 15 && response[1] == 4)
            {
                string json = JsonConvert.SerializeObject(new
                {
                    Led1 = new
                    {
                        Min = response[4],
                        Max = response[6],
                        Dim = response[8]
                    },
                    Led2 = new
                    {
                        Min = response[10],
                        Max = response[12],
                        Dim = response[14]
                    },
                    Led3 = new
                    {
                        Min = response[16],
                        Max = response[18],
                        Dim = response[20]
                    },
                    Strip = new
                    {
                        R = response[22],
                        G = response[24],
                        B = response[26],
                        Brightness = response[28]
                    }
                });

                if (workerArduino)
                {
                    _mqttClient.PublishAsync("Mosaico/UffProgrammazione/PrimePc11/Arduino/Status", json, 0);
                }
                return JObject.Parse(json);
            }
            else
            {
                return JObject.Parse("{}");
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
                if (!admin)
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
                passwordTextBox.ResetText();
                adminPannel.Visible = true;
                disableControls.Visible = true;
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
                AdminGroup.Visible = true;
                adminPannel.Visible = false;
                disableControls.Checked = false;
                disableControls.Visible = false;
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
            AdminGroup.Enabled = true;
            userPannel.Enabled = true;
            neoPannel.Enabled = true;
            disableControls.Enabled = true;
            errorResponseLabel.Visible = false;
        }

        private void DisableCommand()
        {
            errorResponseLabel.Visible = false;
            AdminGroup.Enabled = false;
            disableControls.Visible = false;
            passwordNotValidLabel.Text = "";
            noIdLabel.Visible = false;
            portErrorLabel.Visible = false;
            userPannel.Enabled = false;
            neoPannel.Enabled = false;
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


        private void colorpicker_Click(object sender, EventArgs e)
        {
            r = colorpicker.SelectedColor.R;
            g = colorpicker.SelectedColor.G;
            b = colorpicker.SelectedColor.B;

            lr = colorpicker.SelectedColor.R;
            lg = colorpicker.SelectedColor.G;
            lb = colorpicker.SelectedColor.B;
            //colorpanel.BackColor = Color.FromArgb(r, g, b);

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
            //colorpanel.BackColor = Color.FromArgb(r, g, b);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, ledStrip.BrightnessWriteReg, (int)brightnessSet.Value*255/100);
        }

        private void startWorker_Click(object sender, EventArgs e)
        {
            try
            {
                new Thread(() =>
                {
                    workerArduino = true;
                    while (workerArduino)
                    {
                        builder = new MqttClientOptionsBuilder()
                                .WithClientId("ClientWorker")
                                .WithTcpServer("localhost", 707);

                        // Create client options objects
                        options = new ManagedMqttClientOptionsBuilder()
                                                .WithAutoReconnectDelay(TimeSpan.FromSeconds(60))
                                                .WithClientOptions(builder.Build())
                                                .Build();

                        // Creates the client object
                        _mqttClient = new MqttFactory().CreateManagedMqttClient();

                        // Subscribe to a topic

                        _mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(ReceivedMessage);

                        // Set up handlers
                        _mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(OnConnected);
                        _mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(OnDisconnected);
                        _mqttClient.ConnectingFailedHandler = new ConnectingFailedHandlerDelegate(OnConnectingFailed);


                        Console.WriteLine("MODBUSFORM WORKER LISTENING....");
                        // Starts a connection with the Broker

                        _mqttClient.StartAsync(options).GetAwaiter().GetResult();

                        Console.ReadLine();
                    }
                }).Start();
            }
            catch (Exception)
            {
                Console.WriteLine("error");
            }
        }

        private void OnConnectingFailed(ManagedProcessFailedEventArgs obj)
        {
            Console.WriteLine("Successfully disconnected.");
        }

        private void OnDisconnected(MqttClientDisconnectedEventArgs obj)
        {
            Console.WriteLine("Couldn't connect to broker.");
        }

        private void OnConnected(MqttClientConnectedEventArgs obj)
        {
            Console.WriteLine("Successfully connected.");
            _mqttClient.SubscribeAsync("Mosaico/UffProgrammazione/PrimePc11/Arduino/Set/#");
        }

        private void ReceivedMessage(MqttApplicationMessageReceivedEventArgs context)
        {
            var stringCommand = context.ApplicationMessage?.Payload == null ? null : Encoding.UTF8.GetString(context.ApplicationMessage?.Payload);
            string topic = context.ApplicationMessage?.Topic;
            TMqttMessage jsonCommand = JsonConvert.DeserializeObject<TMqttMessage>(stringCommand);

            int itemid = jsonCommand.Id;
            string op = jsonCommand.Operation;
            int val = jsonCommand.Value;

            Console.WriteLine($"Successfully receive: {jsonCommand.Id}, operation: {jsonCommand.Operation}, value: {jsonCommand.Value}, R: {jsonCommand.R}");

            string[] subs = topic.Split('/');
            string item = subs.Last();
            bool isled;
            bool isledstrip;


            switch (item)
            {
                case "Led":
                    isled = true;
                    isledstrip = false;
                    foreach (var led in leds)
                    {
                        if (itemid == led.Id)
                        {
                            On = led.LedOnWriteCoil;
                            Off = led.LedOffWriteCoil;

                            ledminDimWrite = led.MinWriteReg;
                            ledmaxDimWrite = led.MaxWriteReg;
                            leddimWrite = led.DimWriteReg;

                            leddimRead = led.DimReadReg;
                            ledminDimRead = led.DimReadReg;
                            ledmaxDimRead = led.MaxReadReg;
                        }
                    }
                    break;
                case "LedStrip":
                    isledstrip = true;
                    isled = false;
                    foreach (var ledstrip in ledStrips)
                    {
                        if (itemid == ledstrip.Id)
                        {
                            R = ledstrip.RWriteReg;
                            G = ledstrip.GWriteReg;
                            B = ledstrip.BWriteReg;
                            pixelbrighness = ledStrip.BrightnessWriteReg;
                        }
                    }
                    break;
                default:
                    isled = false;
                    isledstrip = false;
                    break;
            }



            if (isled)
            {
                switch (op)
                {
                    case "on":
                        if (serialport.IsOpen)
                        {
                            TModBusSerial.SendMessageWrite(serialport, (byte)slave_id.Value, WriteSingleCoil, On, commandOn);
                        }
                        break;
                    case "off":
                        if (serialport.IsOpen)
                        {
                            TModBusSerial.SendMessageWrite(serialport, (byte)slave_id.Value, WriteSingleCoil, Off, commandOn);
                        }
                        break;
                    case "dim":
                        if (serialport.IsOpen)
                        {
                            TModBusSerial.SendMessageWrite(serialport, (byte)slave_id.Value, WriteSingleRegiste, leddimWrite, val * 255 / 100);
                        }
                        break;
                    case "min":
                        if (serialport.IsOpen)
                        {
                            TModBusSerial.SendMessageWrite(serialport, (byte)slave_id.Value, WriteSingleRegiste, ledminDimWrite, val * 255 / 100);
                        }
                        break;
                    case "max":
                        if (serialport.IsOpen)
                        {
                            TModBusSerial.SendMessageWrite(serialport, (byte)slave_id.Value, WriteSingleRegiste, ledmaxDimWrite, val * 255 / 100);
                        }
                        break;
                    default:
                        break;
                }
            }
            if(isledstrip)
            {
                switch (op)
                {
                    case "on":
                        if (serialport.IsOpen)
                        {
                            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, R, lr);
                            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, G, lg);
                            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, B, lb);
                        }
                        break;

                    case "off":
                        if (serialport.IsOpen)
                        {
                            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, R, 0);
                            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, G, 0);
                            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, B, 0);
                        }
                        break;

                    case "rgb":
                        if (serialport.IsOpen)
                        {
                            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, R, jsonCommand.R);
                            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, G, jsonCommand.G);
                            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, B, jsonCommand.B);
                        }
                        lr = jsonCommand.R;
                        lg = jsonCommand.G;
                        lb = jsonCommand.B;
                        break;

                    case "brightness":
                        if (serialport.IsOpen)
                        {
                            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, ledStrip.BrightnessWriteReg, jsonCommand.Value);
                        }
                        break;

                    default:
                        break;
                }
            }

        }
    }
}


