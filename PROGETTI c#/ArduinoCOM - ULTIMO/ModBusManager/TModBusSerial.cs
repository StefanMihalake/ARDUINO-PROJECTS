using SerialManager;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;

namespace ModBusManager
{
    public static class TModBusSerial
    {
        const int TimeCycle = 4;
        const int NCycles = 5;

        public static ushort calcCRC(byte[] buff)
        {
            ushort crc = 0xFFFF;
            for (int i = 0; i < buff.Length; i++)
            {
                crc = (ushort)(crc ^ buff[i]);      //for every byte that compose the request update the crc following the polynomials operation
                for (int j = 8; j > 0; j--)
                {
                    if ((crc & 1) != 0)
                    {
                        crc = (ushort)(crc >> 1);
                        crc = (ushort)(crc ^ 0xA001);
                    }
                    else
                    {
                        crc = (ushort)(crc >> 1);
                    }
                }
            }
            return crc;     //when che operation is over return the crc
        }

        public static byte[] SendMessageRead(SerialPort serialPort, byte address, byte code, int startAddress, int numAddress)
        {
            if (code <= 0x04)                                                           //if the code is a reading operation code
            {
                List<byte> hexComandRead = new List<byte>                               //compose the request
                {
                    address, 
                    code,
                    (byte)(startAddress>>8), 
                    (byte)(startAddress), 
                    (byte)(numAddress>>8), 
                    (byte)(numAddress), 
                };

                ushort crc = calcCRC(hexComandRead.ToArray());                          //calculate the crc


                hexComandRead.Add((byte)crc);
                hexComandRead.Add((byte)(crc>>8));                                      //and append the data of the crc to the request list

                if (serialPort.IsOpen)
                {
                    serialPort.Write(hexComandRead.ToArray(), 0, hexComandRead.Count);  //send the request to the slave specified
                }
                else                                                                    // test per far ripartire la connessione se si stacca il cavo
                {
                    //bool repeat = true;
                    //while (repeat)
                    //{
                    //    Thread.Sleep(5000);
                    //    string lastport = serialPort.PortName;
                    //    serialPort.Close();
                    //    //Thread.Sleep(5000);
                    //    string[] ports = SerialPort.GetPortNames();
                    //    foreach (string port in ports)
                    //    {
                    //        if (port == lastport)
                    //        {
                    //            serialPort.Open();
                    //            continue;
                    //        }
                    //    }
                    //    if (serialPort.IsOpen)
                    //    {
                    //        repeat = false;
                    //    }
                    //}
                }

                return hexComandRead.ToArray();                                         //returrn the request sent
            }
            return new byte[0];                                                         //if the code wasn't a reading opreation code retun en empty array
        }

        public static byte[] SendMessageWrite(SerialPort serialPort, byte address, byte code, int startAddress, int value)
        {
            if (code > 0x04 && code <= 0x06)                                            //if the code is a writing code operation
            {
                List<byte> hexComandWrite = new List<byte>                              //compose the request
                {
                    address,
                    code,
                    (byte)(startAddress>>8),
                    (byte)(startAddress),
                    (byte)(value>>8),
                    (byte)(value),
                };

                ushort crc = calcCRC(hexComandWrite.ToArray());                         //calculate the crc

                hexComandWrite.Add((byte)crc);                                          //append the first 8 bits of the crc to the request list
                hexComandWrite.Add((byte)(crc >> 8));                                   //append the the second 8 bits of the crc to the request list

                if (serialPort.IsOpen)
                {
                    serialPort.Write(hexComandWrite.ToArray(), 0, hexComandWrite.Count);    //send the request to the slave specified
                }

                return hexComandWrite.ToArray();                                        //returrn the request sent
            }
            return new byte[0];                                                         //if the code wasn't a writing opreation code retun en empty array
        }

        public static byte[] GetMessage(SerialPort serialPort)
        {
            int NumCycles = 0;
            int BytesToRead = 0;
            int LastBytesToRead = 0;

            while (NumCycles++ < NCycles)                                               // control that in the buffer is the same response 
            {

                BytesToRead = serialPort.BytesToRead;

                if (BytesToRead != LastBytesToRead)
                {
                    LastBytesToRead = BytesToRead;
                    NumCycles = 0;
                }

                Thread.Sleep(TimeCycle);
            }


            Byte[] Answer = new Byte[BytesToRead];
            serialPort.Read(Answer, 0, BytesToRead);

            ushort crcResponse = calcCRC(Answer);                                       // Calculate crc of the full message of response (crc included)

            if (crcResponse == 0)                                                       // If the result is 0 it means that the message hasn't been corrupted
            {
                return Answer;                                                          // If crc is 0 wich means the is ok return it
            }
            else
            {
                return new byte[0];                                                     // If crc is != 0 means the response is corrupt so return an empty array
            }
        }


    }
}
