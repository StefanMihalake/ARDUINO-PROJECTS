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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mqtt_WinForm
{
    public partial class Form1 : Form
    {
        // StripLed Id
        int stripId = 4;

        // MQTT 
        MqttClientOptionsBuilder builder;
        ManagedMqttClientOptions options;
        IManagedMqttClient _mqttClient;
        
        // password list
        List<string> passwords = new List<string>() { "pass", "ciao" };

        List<int> leds = new List<int>() { 1, 2, 3 };
        string[] component = { "Led1", "Led2", "Led3", "Strip" };


        volatile bool worker = false;
        // Topics
        string topicToPublishLed = "Mosaico/UffProgrammazione/PrimePc11/Arduino/Set/Led";
        string topicToPublishPixel = "Mosaico/UffProgrammazione/PrimePc11/Arduino/Set/LedStrip";

        // Last color set
        int lr;
        int lg;
        int lb;

        volatile JObject jObject;
        volatile bool messageRecived = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisableCommand();
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            if (worker == false)
            {
                try
                {
                    new Thread(() =>
                    {
                        worker = true;
                        while (worker)
                        {
                            builder = new MqttClientOptionsBuilder()
                                                    .WithClientId("ArduinoWorker")
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

                            Console.WriteLine("WORKER STARTED");

                            // Starts a connection with the Broker
                            _mqttClient.StartAsync(options).GetAwaiter().GetResult();

                            while (worker)
                            {
                                if (messageRecived)
                                {
                                    messageRecived = false;
                                    if (InvokeRequired)
                                    {
                                        this.Invoke(new MethodInvoker(delegate
                                        {
                                            bool checkedId = false;
                                            foreach (var item in leds)
                                            {
                                                if (deviceId.Value == item)                      // if selected id is one of the respons items
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
                                                        if ((int)jObject[comp]["Dim"] > 0)                // if the brightness is > than 0
                                                        {
                                                            onButton.BackColor = Color.DarkSeaGreen;
                                                            offButton.BackColor = Color.Silver;
                                                            int value = (int)Math.Round((decimal)((int)jObject[comp]["Dim"]) * 100 / 255);
                                                            if (progressbar.Value != value)
                                                            {
                                                                progressbar.Value = value;
                                                            }
                                                            dimLed.Visible = true;
                                                            dimLed.Text = value.ToString() + "%";
                                                        }
                                                        else if ((int)jObject[comp]["Dim"] == 0)               // if the brightness is = 0
                                                        {
                                                            offButton.BackColor = Color.IndianRed;
                                                            onButton.BackColor = Color.Silver;
                                                            progressbar.Value = 0;
                                                            dimLed.Text = "OFF";
                                                        }
                                                        if ((int)jObject[comp]["Min"] == 0)                // if min  is default
                                                        {
                                                            minValueLabel.Text = "10%";
                                                            minUserLabel.Text = "10%";
                                                            minDimValue.Minimum = 10;
                                                            dim.Minimum = 10;
                                                        }
                                                        else
                                                        {
                                                            int min = (int)Math.Round((decimal)((int)jObject[comp]["Min"]) * 100 / 255);
                                                            minValueLabel.Text = min.ToString() + "%";
                                                            minUserLabel.Text = min.ToString() + "%";
                                                            maxDimValue.Minimum = min;
                                                            dim.Minimum = min;
                                                        }
                                                        if ((int)jObject[comp]["Max"] == 0)                 // if max  is default
                                                        {
                                                            maxValueLabel.Text = "100%";
                                                            maxUserLabel.Text = "100%";
                                                            minDimValue.Maximum = 100;
                                                            dim.Maximum = 100;
                                                        }
                                                        else
                                                        {
                                                            int max = (int)Math.Round((decimal)((int)jObject[comp]["Max"]) * 100 / 255);
                                                            maxValueLabel.Text = max.ToString() + "%";
                                                            maxUserLabel.Text = max.ToString() + "%";
                                                            minDimValue.Maximum = max;
                                                            dim.Maximum = max;
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

                                            if ((int)jObject["Strip"]["R"] == 0 && (int)jObject["Strip"]["G"] == 0 && (int)jObject["Strip"]["B"] == 0)                // if the brightness is > than 0
                                            {
                                                offPixel.BackColor = Color.IndianRed;
                                                onPixel.BackColor = Color.Silver;

                                            }
                                            else               // if the brightness is = 0
                                            {
                                                onPixel.BackColor = Color.DarkSeaGreen;
                                                offPixel.BackColor = Color.Silver;
                                                colorpanel.BackColor = Color.FromArgb((int)jObject["Strip"]["R"], (int)jObject["Strip"]["G"], (int)jObject["Strip"]["B"]);
                                            }
                                            int val = (int)Math.Round((decimal)((int)jObject["Strip"]["Brightness"]) * 100 / 255);
                                            brightnessLabel.Text = val.ToString() + "%";
                                        }));
                                    }
                                }
                            }
                        }
                    }).Start();
                }
                catch (Exception)
                {
                    Console.WriteLine("error");
                }
                connectButton.Text = "DISCONNECT";
            }
            else
            {
                connectButton.Text = "CONNECT";
                worker = false;
                _mqttClient.StopAsync();
            }
        }

        private void ReceivedMessage(MqttApplicationMessageReceivedEventArgs obj)
        {
            Console.WriteLine("Response received.");

            jObject = JObject.Parse(Encoding.UTF8.GetString(obj.ApplicationMessage.Payload));

            messageRecived = true;
        }

        private void OnConnectingFailed(ManagedProcessFailedEventArgs obj)
        {
            Console.WriteLine("Couldn't connect to broker.");
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    connectionStatusLabel.Text = "Couldn't connect to broker.";
                    DisableCommand();
                }));
            }
        }

        private void OnDisconnected(MqttClientDisconnectedEventArgs obj)
        {
            Console.WriteLine("Connection stopped");
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    connectionStatusLabel.Text = "Connection stopped";
                    DisableCommand();
                }));
            }
        }

        private void OnConnected(MqttClientConnectedEventArgs obj)
        {
            Console.WriteLine("Successfully connected.");
            _mqttClient.SubscribeAsync("Mosaico/UffProgrammazione/PrimePc11/Arduino/Status");
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    connectionStatusLabel.Text = "Successfully connected.";
                    EnableCommand();
                }));
            }
        }

        private void ledOffButton_Click(object sender, EventArgs e)
        {
            if (_mqttClient.IsConnected)
            {
                string json = JsonConvert.SerializeObject(new
                {
                    Id = (int)deviceId.Value,
                    Operation = "off"
                });
                _mqttClient.PublishAsync(topicToPublishLed, json);
            }
        }

        private void ledOnButton_Click(object sender, EventArgs e)
        {
            if (_mqttClient.IsConnected)
            {
                string json = JsonConvert.SerializeObject(new
                {
                    Id = (int)deviceId.Value,
                    Operation = "on"
                });
                _mqttClient.PublishAsync(topicToPublishLed, json);
            }
        }

        private void numDim_ValueChanged(object sender, EventArgs e)
        {
            if (_mqttClient.IsConnected)
            {
                string json = JsonConvert.SerializeObject(new
                {
                    Id = (int)deviceId.Value,
                    Operation = "dim",
                    value = (int)dim.Value
                });
                _mqttClient.PublishAsync(topicToPublishLed, json);
            }
        }

        private void DisableCommand()
        {
            connectionStatusLabel.Text = "";
            userPannel.Enabled = false;
            adminPannel.Visible = false;
            neoPannel.Enabled = false;
            loginPannel.Enabled = false;
            passErrorLabel.Visible = false;
            //setMinButton.Visible = false;
            //setMaxButton.Visible = false;
            //minDimValue.Visible = false;
            //maxDimValue.Visible = false;
            //logOutButton.Visible = false;
            //minValueLabel.Visible = false;
            //maxValueLabel.Visible = false;
        }

        private void EnableCommand()
        {
            userPannel.Enabled = true;
            neoPannel.Enabled = true;
            loginPannel.Enabled = true;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (passwords.Contains(passwordTextbox.Text))
            {
                adminPannel.Enabled = true;
                loginPannel.Visible = false;
                passErrorLabel.Visible = false;

                //setMinButton.Visible = true;
                //setMaxButton.Visible = true;
                //minDimValue.Visible = true;
                //maxDimValue.Visible = true;
                //logOutButton.Visible = true;
                //minValueLabel.Visible = true;
                //maxValueLabel.Visible = true;

                //passwordTextbox.Visible = false;
                //loginButton.Visible = false;
                //passLabel.Visible = false;

            }
            else
            {
                passErrorLabel.Visible = true;
            }
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            setMinButton.Visible = false;
            setMaxButton.Visible = false;
            minDimValue.Visible = false;
            maxDimValue.Visible = false;
            logOutButton.Visible = false;

            passwordTextbox.Visible = true;
            loginButton.Visible = true;
            passLabel.Visible = true;
        }

        private void pixelOnButton_Click(object sender, EventArgs e)
        {
            if (_mqttClient.IsConnected)
            {
                string json = JsonConvert.SerializeObject(new
                {
                    Id = stripId,
                    Operation = "rgb",
                    R = lr,
                    G = lg,
                    B = lb
                });
                _mqttClient.PublishAsync(topicToPublishPixel, json);
            }
        }

        private void pixelOffButton_Click(object sender, EventArgs e)
        {
            if (_mqttClient.IsConnected)
            {
                string json = JsonConvert.SerializeObject(new
                {
                    Id = stripId,
                    Operation = "rgb",
                    R = 0,
                    G = 0,
                    B = 0
                });
                _mqttClient.PublishAsync(topicToPublishPixel, json);
            }
        }

        private void pixelBrightnessNum_ValueChanged(object sender, EventArgs e)
        {
            if (_mqttClient.IsConnected)
            {
                string json = JsonConvert.SerializeObject(new
                {
                    Id = stripId,
                    Operation = "brightness",
                    Value = (int)pixelBrightnessNum.Value * 255 / 100
                });
                _mqttClient.PublishAsync(topicToPublishPixel, json);
            }
        }

        private void colorPicker_Click(object sender, EventArgs e)
        {
            int r = colorPicker.SelectedColor.R;
            int g = colorPicker.SelectedColor.G;
            int b = colorPicker.SelectedColor.B;
            lr = r;
            lg = g;
            lb = b;

            colorpanel.BackColor = Color.FromArgb(r, g, b);

            if (_mqttClient.IsConnected)
            {
                string json = JsonConvert.SerializeObject(new
                {
                    Id = stripId,
                    Operation = "rgb",
                    R = r,
                    G = g,
                    B = b
                });
                _mqttClient.PublishAsync(topicToPublishPixel, json);
            }
        }

        private void setMinButton_Click(object sender, EventArgs e)
        {
            if (_mqttClient.IsConnected)
            {
                string json = JsonConvert.SerializeObject(new
                {
                    Id = (int)deviceId.Value,
                    Operation = "min",
                    Value = (int)(minDimValue.Value)
                });
                _mqttClient.PublishAsync(topicToPublishLed, json);
            }
        }

        private void setMaxButton_Click(object sender, EventArgs e)
        {
            if (_mqttClient.IsConnected)
            {
                string json = JsonConvert.SerializeObject(new
                {
                    Id = (int)deviceId.Value,
                    Operation = "max",
                    Value = (int)(maxDimValue.Value)
                });
                _mqttClient.PublishAsync(topicToPublishLed, json);
            }
        }
    }
}
