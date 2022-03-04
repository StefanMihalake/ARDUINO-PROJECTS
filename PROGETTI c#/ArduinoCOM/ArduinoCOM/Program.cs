using SerialManager;
using System;
using System.IO.Ports;
using System.Threading;

namespace ArduinoCOM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Arduino Emulator";
            Console.WriteLine("Press to quit...");

            TSerialManager sPort = new TSerialManager("COM20", 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);

            ManualResetEvent mRe = new ManualResetEvent(false);


            try
            {
                sPort.Open();
                Console.WriteLine("PORT OPEN");
                


                    if (sPort.IsOpen)
                    {
                        sPort.DataReceived += Ciao;
                    }
                    else
                    {
                        Console.WriteLine($"ERROR PORT {sPort.PortName}");
                    }
                


            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadLine();

        }

        private static void Ciao(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serialPort = sender as SerialPort;
            if (serialPort != null)
            {
                Console.WriteLine("RECEIVED");
                string message = serialPort.ReadTo("&");
                Console.WriteLine(message);
                Thread.Sleep(500);
                serialPort.WriteLine($"ECHO:  {message}&");
            }
        }
    }
    
}
