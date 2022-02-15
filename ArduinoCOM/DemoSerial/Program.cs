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

                byte slaveId = 1;
                ushort outputAddress = 2;   // this is the address of the first output of the plc
                ushort inputAddress = 0;    // this is the address of the first input of the plc
                ushort numRegisters = 2;


               //slv  fun    address     data     checksum
              //0x01 0x05  0x00 0xFA  0xFF 0x00  0x0B 0xAC









            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
            

        }
    }
}
