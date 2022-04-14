using MQTTnet;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Extensions.ManagedClient;
using Newtonsoft.Json;
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
    public partial class MqttClientWinForm : Form
    {
        MqttClientOptionsBuilder builder;
        ManagedMqttClientOptions options;
        IManagedMqttClient _mqttClient;
        
        // password list
        List<string> passwords = new List<string>() { "pass", "ciao" };
        
        bool worker = false;
        // Topics
        string topicToPublishLed = "Mosaico/UffProgrammazione/Prime11/Arduino/Set/Led";
        string topicToPublishPixel = "Mosaico/UffProgrammazione/Prime11/Arduino/Set/LedStrip";

        // Last color set
        int lr;
        int lg;
        int lb;

        public MqttClientWinForm()
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
                            //_mqttClient.SubscribeAsync("Mosaico/UffProgrammazione/Prime11/Arduino/Status/Led");

                            Console.ReadLine();
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
            

        }

        private void OnConnectingFailed(ManagedProcessFailedEventArgs obj)
        {
            Console.WriteLine("Successfully disconnected.");
            connectionStatusLabel.Text = "Successfully disconnected.";
        }

        private void OnDisconnected(MqttClientDisconnectedEventArgs obj)
        {
            Console.WriteLine("Couldn't connect to broker.");
            connectionStatusLabel.Text = "Couldn't connect to broker.";
        }

        private void OnConnected(MqttClientConnectedEventArgs obj)
        {
            Console.WriteLine("Successfully connected.");
            connectionStatusLabel.Text = "Successfully connected.";
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
                    value = (int)dimNum.Value
                });
                _mqttClient.PublishAsync(topicToPublishLed, json);
            }
        }

        private void DisableCommand()
        {
            setMinButton.Visible = false;
            setMaxButton.Visible = false;
            setMinNumeric.Visible = false;
            setMaxNumeric.Visible = false;
            logOutButton.Visible = false;
            passErrorLabel.Visible = false;
            connectionStatusLabel.Text = "";
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (passwords.Contains(passwordTextbox.Text))
            {
                setMinButton.Visible = true;
                setMaxButton.Visible = true;
                setMinNumeric.Visible = true;
                setMaxNumeric.Visible = true;
                logOutButton.Visible = true;
                passErrorLabel.Visible = true;

                passwordTextbox.Visible = false;
                loginButton.Visible = false;
                passLabel.Visible = false;
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
            setMinNumeric.Visible = false;
            setMaxNumeric.Visible = false;
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
                    Id = (int)deviceId.Value,
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
                    Id = (int)deviceId.Value,
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
                    Id = (int)deviceId.Value,
                    Operation = "brightness",
                    Value = (int)pixelBrightnessNum.Value
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

            colorPanel.BackColor = Color.FromArgb(r, g, b);

            if (_mqttClient.IsConnected)
            {
                string json = JsonConvert.SerializeObject(new
                {
                    Id = (int)deviceId.Value,
                    Operation = "rgb",
                    R = r,
                    G = g,
                    B = b
                });
                _mqttClient.PublishAsync(topicToPublishPixel, json);
            }
        }
    }
}
