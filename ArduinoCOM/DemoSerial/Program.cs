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
            //TSerialManager sPort = new TSerialManager("COM5", 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);



            //try
            //{
            //    sPort.Open();

            //    byte slaveId = 1;
            //    ushort outputAddress = 2;   // this is the address of the first output of the plc
            //    ushort inputAddress = 0;    // this is the address of the first input of the plc
            //    ushort numRegisters = 2;

            //    // Compute the MODBUS RTU CRC
            //    UInt16 ModRTU_CRC(byte[] buf, int len)
            //    {
            //        UInt16 crc = 0xFFFF;

            //        for (int pos = 0; pos < len; pos++)
            //        {
            //            crc ^= (UInt16)buf[pos];          // XOR byte into least sig. byte of crc

            //            for (int i = 8; i != 0; i--)
            //            {    // Loop over each bit
            //                if ((crc & 0x0001) != 0)
            //                {      // If the LSB is set
            //                    crc >>= 1;                    // Shift right and XOR 0xA001
            //                    crc ^= 0xA001;
            //                }
            //                else                            // Else LSB is not set
            //                    crc >>= 1;                    // Just shift right
            //            }
            //        }
            //        // Note, this number has low and high bytes swapped, so use it accordingly (or swap bytes)
            //        return crc;
            //    }



            //    //slv  fun    address     data     checksum
            //    //0x01 0x05  0x00 0xFA  0xFF 0x00  0x0B 0xAC




            int i = 250;
            string hex = i.ToString("X");
            Console.WriteLine(hex);
            Console.ReadLine();






            //}
            //catch (ArgumentException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //Console.ReadLine();


        }
    }
}
