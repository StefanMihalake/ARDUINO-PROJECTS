using MQTTnet;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Extensions.ManagedClient;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MqttClient2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates a new client
            MqttClientOptionsBuilder builder = new MqttClientOptionsBuilder()
                                                    .WithClientId("Dev.To2")
                                                    .WithTcpServer("localhost", 707);

            // Create client options objects
            ManagedMqttClientOptions options = new ManagedMqttClientOptionsBuilder()
                                    .WithAutoReconnectDelay(TimeSpan.FromSeconds(60))
                                    .WithClientOptions(builder.Build())
                                    .Build();

            // Creates the client object
            IManagedMqttClient _mqttClient = new MqttFactory().CreateManagedMqttClient();



            _mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(ReceivedMessage);

            // Set up handlers
            _mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(OnConnected);
            _mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(OnDisconnected);
            _mqttClient.ConnectingFailedHandler = new ConnectingFailedHandlerDelegate(OnConnectingFailed);



            // Starts a connection with the Broker
            _mqttClient.StartAsync(options).GetAwaiter().GetResult();

            // Subscribe to a topic
            _mqttClient.SubscribeAsync("dev.to/topic/json", 0);

            Thread.Sleep(5000);

            // Send a new message to the broker every second
            string json = JsonConvert.SerializeObject(new { comand = "ciao da client 2" });
            _mqttClient.PublishAsync("dev.to/topic/json", json);

            Console.ReadLine();

        }

        private static void ReceivedMessage(MqttApplicationMessageReceivedEventArgs context)
        {
            var payload = context.ApplicationMessage?.Payload == null ? null : Encoding.UTF8.GetString(context.ApplicationMessage?.Payload);

            Console.WriteLine($"CLIENT 2: {payload}");
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
