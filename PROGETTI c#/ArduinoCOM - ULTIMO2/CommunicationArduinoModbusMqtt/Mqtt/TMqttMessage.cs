using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationArduinoModbusMqtt.Mqtt
{
    public class TMqttMessage
    {
        public int Id { get; set; }
        public string Operation { get; set; }
        public int Value { get; set; }

        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
    }
}
