using MQTTnet;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Client.Subscribing;
using MQTTnet.Extensions.ManagedClient;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MqttClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates a new client
            MqttClientOptionsBuilder builder = new MqttClientOptionsBuilder()
                                                    .WithClientId("Dev.To")
                                                    .WithTcpServer("localhost", 707);

            // Create client options objects
            ManagedMqttClientOptions options = new ManagedMqttClientOptionsBuilder()
                                    .WithAutoReconnectDelay(TimeSpan.FromSeconds(60))
                                    .WithClientOptions(builder.Build())
                                    .Build();

            // Creates the client object
            IManagedMqttClient _mqttClient = new MqttFactory().CreateManagedMqttClient();

            // Subscribe to a topic
            _mqttClient.SubscribeAsync("dev.to/topic/json", 0); 

            _mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(ReceivedMessage);
                
            // Set up handlers
            _mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(OnConnected);
            _mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(OnDisconnected);
            _mqttClient.ConnectingFailedHandler = new ConnectingFailedHandlerDelegate(OnConnectingFailed);

            // Starts a connection with the Broker
            _mqttClient.StartAsync(options).GetAwaiter().GetResult();

            // Send a new message to the broker every second
            while (true)
            {
                string json = JsonConvert.SerializeObject(new { comand = "ciao" });
                _mqttClient.PublishAsync("dev.to/topic/json", json);

                Task.Delay(1000).GetAwaiter().GetResult();
            }
        }

        private static void ReceivedMessage(MqttApplicationMessageReceivedEventArgs context)
        {
            var payload = context.ApplicationMessage?.Payload == null ? null : Encoding.UTF8.GetString(context.ApplicationMessage?.Payload);

            Console.WriteLine($"Mesaggio mandato e ricevuto: {payload}");
        }

        private static void OnConnectingFailed(ManagedProcessFailedEventArgs obj)
        {
            Console.WriteLine("Successfully connected.");
        }

        private static void OnDisconnected(MqttClientDisconnectedEventArgs obj)
        {
            Console.WriteLine("Couldn't connect to broker.");
        }

        private static void OnConnected(MqttClientConnectedEventArgs obj)
        {
            Console.WriteLine("Successfully disconnected.");
        }
    }
}
