using MQTTnet;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Extensions.ManagedClient;
using Newtonsoft.Json;
using System;
using System.Text;
using ModBusManager;
using CommunicationArduinoModbusMqtt.Modbus;
using System.Collections.Generic;
using CommunicationArduinoModbusMqtt.Mqtt;
using System.IO.Ports;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Mqtt_ArduinoModbusWorcker
{
    class Program
    {
        static SerialPort serialport;
        static IManagedMqttClient _mqttClient;
        static bool workerArduino;


        static void Main(string[] args)
        {
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
            List<TLed> leds = new List<TLed>() {led1, led2, led3 };
            List<TLedStrip> ledStrips = new List<TLedStrip>() { ledStrip };


            // ARDUINO SLAVE ID
            byte slaveid = 1;

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

            serialport = new SerialPort("COM5", 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);     // create serialPort connection
            serialport.DataReceived += GetResponseModbus;                                // if any response pass it to delegate method 


            try
            {
                serialport.Open();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }


            try
            {
                //new Thread(() =>
                //{
                    workerArduino = true;
                    while (workerArduino)
                    {
                        MqttClientOptionsBuilder builder = new MqttClientOptionsBuilder()
                                .WithClientId("ClientWorker")
                                .WithTcpServer("localhost", 707);

                        // Create client options objects
                        ManagedMqttClientOptions options = new ManagedMqttClientOptionsBuilder()
                                                .WithAutoReconnectDelay(TimeSpan.FromSeconds(60))
                                                .WithClientOptions(builder.Build())
                                                .Build();

                        // Creates the client object
                        _mqttClient = new MqttFactory().CreateManagedMqttClient();


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
                //}).Start();
            }
            catch (Exception)
            {
                Console.WriteLine("error");
            }
            

             void OnConnectingFailed(ManagedProcessFailedEventArgs obj)
            {
                Console.WriteLine("Successfully disconnected.");
            }

             void OnDisconnected(MqttClientDisconnectedEventArgs obj)
            {
                Console.WriteLine("Couldn't connect to broker.");
            }

             void OnConnected(MqttClientConnectedEventArgs obj)
            {
                Console.WriteLine("Successfully connected.");
                _mqttClient.SubscribeAsync("Mosaico/UffProgrammazione/PrimePc11/Arduino/Set/#");
            }

             void ReceivedMessage(MqttApplicationMessageReceivedEventArgs context)
            {
                // Modbus on/off
                int commandOn = 0xFF00;

                // Mqtt led strip
                int On = 0;
                int Off = 0;

                int ledminDimWrite = 0;
                int ledmaxDimWrite = 0;
                int leddimWrite = 0;

                int leddimRead = 0;
                int ledminDimRead = 0;
                int ledmaxDimRead = 0;


                int R = 0;
                int G = 0;
                int B = 0;
                int pixelbrighness = 0;

                int lr = 129;
                int lg = 56;
                int lb = 0;

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
                                break;
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
                                TModBusSerial.SendMessageWrite(serialport, slaveid, WriteSingleCoil, On, commandOn);
                            }
                            break;
                        case "off":
                            if (serialport.IsOpen)
                            {
                                TModBusSerial.SendMessageWrite(serialport, slaveid, WriteSingleCoil, Off, commandOn);
                            }
                            break;
                        case "dim":
                            if (serialport.IsOpen)
                            {
                                TModBusSerial.SendMessageWrite(serialport, slaveid, WriteSingleRegiste, leddimWrite, val * 255 / 100);
                            }
                            break;
                        case "min":
                            if (serialport.IsOpen)
                            {
                                TModBusSerial.SendMessageWrite(serialport, slaveid, WriteSingleRegiste, ledminDimWrite, val * 255 / 100);
                            }
                            break;
                        case "max":
                            if (serialport.IsOpen)
                            {
                                TModBusSerial.SendMessageWrite(serialport, slaveid, WriteSingleRegiste, ledmaxDimWrite, val * 255 / 100);
                            }
                            break;
                        default:
                            break;
                    }
                }
                if (isledstrip)
                {
                    switch (op)
                    {
                        case "on":
                            if (serialport.IsOpen)
                            {
                                TModBusSerial.SendMessageWrite(serialport, slaveid, (byte)0x06, R, lr);
                                TModBusSerial.SendMessageWrite(serialport, slaveid, (byte)0x06, G, lg);
                                TModBusSerial.SendMessageWrite(serialport, slaveid, (byte)0x06, B, lb);
                            }
                            break;

                        case "off":
                            if (serialport.IsOpen)
                            {
                                TModBusSerial.SendMessageWrite(serialport, slaveid, (byte)0x06, R, 0);
                                TModBusSerial.SendMessageWrite(serialport, slaveid, (byte)0x06, G, 0);
                                TModBusSerial.SendMessageWrite(serialport, slaveid, (byte)0x06, B, 0);
                            }
                            break;

                        case "rgb":
                            if (serialport.IsOpen)
                            {
                                TModBusSerial.SendMessageWrite(serialport, slaveid, (byte)0x06, R, jsonCommand.R);
                                TModBusSerial.SendMessageWrite(serialport, slaveid, (byte)0x06, G, jsonCommand.G);
                                TModBusSerial.SendMessageWrite(serialport, slaveid, (byte)0x06, B, jsonCommand.B);
                            }
                            lr = jsonCommand.R;
                            lg = jsonCommand.G;
                            lb = jsonCommand.B;
                            break;

                        case "brightness":
                            if (serialport.IsOpen)
                            {
                                TModBusSerial.SendMessageWrite(serialport, slaveid, (byte)0x06, ledStrip.BrightnessWriteReg, jsonCommand.Value);
                            }
                            break;

                        default:
                            break;
                    }
                }

            }
        }

        private static void GetResponseModbus(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                byte[] response = TModBusSerial.GetMessage(serialport);     // response from modbus

                JObject items = Separator(response);                            // parse response in json and send to mqtt topic

                string varString = JsonConvert.SerializeObject(items);      // strig for controlling length

                
            }
            catch (Exception err)
            {
                Console.WriteLine($"Error:  {err.Message}");
            }
        }

        private static JObject Separator(byte[] response)                                      // separate the response in items 
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
    }
}
