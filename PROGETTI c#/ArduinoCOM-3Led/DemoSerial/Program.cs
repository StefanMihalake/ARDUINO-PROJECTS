using SerialManager;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;

namespace DemoSerial
{
    class Program
    {
        static void Main(string[] args)
        {
            TSerialManager sPort = new TSerialManager("COM5", 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);



            try
            {
                sPort.Open();

                while (sPort.IsOpen)
                {
                    Console.Write("Message: ");
                    string a = Console.ReadLine();
                    sPort.WriteLine(a);
                    Console.WriteLine("Tasto invio per inserire un'altro messaggio");
                    Console.ReadLine();
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
            //List<string> m = new List<string>();


            //    string message = "id 1 50";
            //    string[] subs = message.Split(' ');
            //    foreach (var sub in subs)
            //    {
            //        m.Add(sub);
            //    }

            //string[] mess = m.ToArray();
            //string type = mess[0].ToString();
            //int id = int.Parse(mess[1]);
            //int brightness = int.Parse(mess[2]);
            //Console.WriteLine($"type: {type}, id: {id}, brightness: {brightness} ");

        }
    }
}
