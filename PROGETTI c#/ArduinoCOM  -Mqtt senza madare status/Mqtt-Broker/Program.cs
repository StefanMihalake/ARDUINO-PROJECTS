using MQTTnet;
using MQTTnet.Server;
using Serilog;
using System;
using System.Text;

namespace Mqtt_Broker
{
    class Program
    {
        static void Main(string[] args)
        {
            MqttServerOptionsBuilder options = new MqttServerOptionsBuilder()
                .WithDefaultEndpoint()
                .WithDefaultEndpointPort(707)
                .WithConnectionValidator(OnNewConnection)
                .WithApplicationMessageInterceptor(OnNewMessage);


            IMqttServer mqttServer = new MqttFactory().CreateMqttServer();

            mqttServer.StartAsync(options.Build()).GetAwaiter().GetResult();
            Console.WriteLine("BROKER LISTENING...");
            Console.ReadLine();
        }

        private static void OnNewMessage(MqttApplicationMessageInterceptorContext context)
        {
            var payload = context.ApplicationMessage?.Payload == null ? null : Encoding.UTF8.GetString(context.ApplicationMessage?.Payload);
            Console.WriteLine($"Messaggio: {payload}");

            //Log.Logger.Information(
            //    "MessageId: {MessageCounter} - TimeStamp: {TimeStamp} -- Message: ClientId = {clientId}, Topic = {topic}, Payload = {payload}, QoS = {qos}, Retain-Flag = {retainFlag}",
            //    MessageCounter,
            //    DateTime.Now,
            //    context.ClientId,
            //    context.ApplicationMessage?.Topic,
            //    payload,
            //    context.ApplicationMessage?.QualityOfServiceLevel,
            //    context.ApplicationMessage?.Retain);
        }

        private static void OnNewConnection(MqttConnectionValidatorContext context)
        {
            //Log.Logger.Information(
            //        "New connection: ClientId = {clientId}, Endpoint = {endpoint}, CleanSession = {cleanSession}",
            //        context.ClientId,
            //        context.Endpoint,
            //        context.CleanSession);
        }
    }
}
