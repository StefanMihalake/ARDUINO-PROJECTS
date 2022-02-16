using SerialManager;
using System;
using System.Collections.Generic;

namespace ModBusManager
{
    public static class TModBusSerial
    {
        public static ushort calcCRC(byte[] buff)
        {
            ushort crc = 0xFFFF;
            for (int i = 0; i < buff.Length; i++)
            {
                crc = (ushort)(crc ^ buff[i]);
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
            return crc;
        }

        public static byte[] sendMessageRead(TSerialManager serialPort, int address, int code, int startAddress, int numAddress)
        {
            if (code <= 0x04)
            {
                string hexAddress = (address % 256).ToString("X2");
                string hexCode = (code % 256).ToString("X2");
                string hexStartAddress1 = (startAddress / 256).ToString("X2");
                string hexStartAddress2 = (startAddress % 256).ToString("X2");
                string hexNumAddress1 = (numAddress / 256).ToString("X2");
                string hexNumAddress2 = (numAddress % 256).ToString("X2");

                List<byte> hexComandRead = new List<byte>
            {
                Byte.Parse(hexAddress, System.Globalization.NumberStyles.HexNumber),
                Byte.Parse(hexCode, System.Globalization.NumberStyles.HexNumber),
                Byte.Parse(hexStartAddress1, System.Globalization.NumberStyles.HexNumber),
                Byte.Parse(hexStartAddress2, System.Globalization.NumberStyles.HexNumber),
                Byte.Parse(hexNumAddress1, System.Globalization.NumberStyles.HexNumber),
                Byte.Parse(hexNumAddress2, System.Globalization.NumberStyles.HexNumber)
            };

                ushort crc = calcCRC(hexComandRead.ToArray());

                int crc1 = (char)(crc / 256);
                int crc2 = (char)(crc % 256);

                byte hexCrc1 = Byte.Parse(crc1.ToString("X2"), System.Globalization.NumberStyles.HexNumber);
                byte hexCrc2 = Byte.Parse(crc2.ToString("X2"), System.Globalization.NumberStyles.HexNumber);

                hexComandRead.Add(hexCrc2);
                hexComandRead.Add(hexCrc1);

                serialPort.Write(hexComandRead.ToArray(), 0, hexComandRead.Count);

                return hexComandRead.ToArray();
            }
            return new byte[0];
        }

        public static byte[] sendMessageWrite(TSerialManager serialPort, int address, int code, int startAddress, int value)
        {
            if (code > 0x04 && code <= 0x06)
            {
                string hexAddress = (address % 256).ToString("X2");
                string hexCode = (code % 256).ToString("X2");
                string hexStartAddress1 = (startAddress / 256).ToString("X2");
                string hexStartAddress2 = (startAddress % 256).ToString("X2");
                string hexVal1 = (value / 256).ToString("X2");
                string hexVal2 = (value % 256).ToString("X2");

                List<byte> hexComandRead = new List<byte>
                {
                    Byte.Parse(hexAddress, System.Globalization.NumberStyles.HexNumber),
                    Byte.Parse(hexCode, System.Globalization.NumberStyles.HexNumber),
                    Byte.Parse(hexStartAddress1, System.Globalization.NumberStyles.HexNumber),
                    Byte.Parse(hexStartAddress2, System.Globalization.NumberStyles.HexNumber),
                    Byte.Parse(hexVal1, System.Globalization.NumberStyles.HexNumber),
                    Byte.Parse(hexVal2, System.Globalization.NumberStyles.HexNumber)
                };

                ushort crc = calcCRC(hexComandRead.ToArray());

                int crc1 = (char)(crc / 256);
                int crc2 = (char)(crc % 256);

                byte hexCrc1 = Byte.Parse(crc1.ToString("X2"), System.Globalization.NumberStyles.HexNumber);
                byte hexCrc2 = Byte.Parse(crc2.ToString("X2"), System.Globalization.NumberStyles.HexNumber);

                hexComandRead.Add(hexCrc2);
                hexComandRead.Add(hexCrc1);

                serialPort.Write(hexComandRead.ToArray(), 0, hexComandRead.Count);

                return hexComandRead.ToArray();
            }
            return new byte[0];
        }

        //public static byte[] getMessage(TSerialManager serialPort, int cod, int numAdd)
        //{
        //    var tStart = DateTime.Now;
        //    bool recivedCheck = false;
        //    while ((DateTime.Now - tStart).TotalMilliseconds < 400)
        //    {
        //        if (serialPort.recived)
        //        {
        //            recivedCheck = true;
        //            List<byte> response = new List<byte>();
        //            int length;
        //            if (cod <= 0x02)
        //            {
        //                if (numAdd % 8 == 0)
        //                {
        //                    length = 3 + numAdd / 8 + 2;
        //                }
        //                else
        //                {
        //                    length = 3 + numAdd / 8 + 1 + 2;
        //                }
        //            }
        //            else if (cod <= 0x04)
        //            {
        //                length = 3 + numAdd * 2 + 2;

        //            }
        //            else if (cod <= 0x06)
        //            {
        //                length = 8;
        //            }
        //            else
        //            {
        //                length = 0;
        //            }
        //            for (int i = 0; i < length; i++)
        //            {
        //                byte lettura = (byte)serialPort.ReadByte();
        //                response.Add(lettura);
        //                if (i == 1)
        //                {
        //                    if ((lettura & 0x80) == 0x80)
        //                    {
        //                        length = 5;
        //                    }
        //                }
        //            }
        //            ushort crcResponse = calcCRC(response.ToArray());
        //            if (crcResponse == 0)
        //            {
        //                return response.ToArray();
        //            }
        //        }
        //    }
        //    if (!recivedCheck)
        //    {
        //        //Console.WriteLine("no message");
        //    }
        //    return new byte[1];
        //}

        //public static List<int> InterpreterMessage(byte[] response, byte[] requestToSend, int numAdd)
        //{
        //    List<int> data = new List<int>();
        //    if (response.Length > 1)
        //    {
        //        if (response[0] == requestToSend[0])
        //        {
        //            if (response[1] == requestToSend[1])
        //            {
        //                int dataLength;
        //                if ((response[1] == 0x01) || (response[1] == 0x02))
        //                {
        //                    //Console.WriteLine("Risposta ricevuta alla richiesta " + response[1]);
        //                    dataLength = response[2];
        //                    int valToAdd = numAdd;
        //                    string finalValues = "";
        //                    for (int i = 3; i < 3 + dataLength; i++)
        //                    {
        //                        string value;
        //                        string value2 = "";
        //                        value = Convert.ToString(response[i], 2);
        //                        for (int j = value.Length - 1; j >= 0; j--)
        //                        {
        //                            value2 += value[j];
        //                        }
        //                        if (valToAdd > 8)
        //                        {
        //                            while (value2.Length < 8)
        //                            {
        //                                value2 += "0";
        //                            }
        //                            valToAdd -= 8;
        //                        }
        //                        finalValues += value2;
        //                    }

        //                    while (finalValues.Length < numAdd)
        //                    {
        //                        finalValues += '0';
        //                    }

        //                    for (int i = 0; i < finalValues.Length; i++)
        //                    {
        //                        if (finalValues[i] == '1')
        //                        {
        //                            data.Add(1);
        //                            //Console.WriteLine("1");
        //                        }
        //                        else
        //                        {
        //                            data.Add(0);
        //                            //Console.WriteLine("0");
        //                        }
        //                    }
        //                }
        //                else if (response[1] == 0x03 || response[1] == 0x04)
        //                {
        //                    //Console.WriteLine("Risposta ricevuta alla richiesta " + response[1]);
        //                    dataLength = response[2];
        //                    data.Clear();
        //                    for (int i = 3; i < 3 + dataLength; i += 2)
        //                    {
        //                        int value = response[i] * 256 + response[i + 1];
        //                        data.Add(value);
        //                        //Console.WriteLine(value);
        //                    }
        //                }
        //                else if (response[1] == 0x05 || response[1] == 0x06)
        //                {
        //                    //Console.WriteLine("Risposta ricevuta alla scrittura " + response[1]);
        //                    bool check = true;
        //                    for (int i = 0; i < response.Length; i++)
        //                    {
        //                        if (response[i] != requestToSend[i])
        //                        {
        //                            check = false;
        //                        }
        //                    }
        //                    if (check == true)
        //                    {
        //                        //Console.WriteLine("scrittura avvenuta");
        //                        data.Add(1);
        //                    }
        //                    else
        //                    {
        //                        //Console.WriteLine("errore nella scrittura");
        //                    }
        //                }
        //                else
        //                { }
        //            }
        //            else if (response[1] == (requestToSend[1] + 0x80))
        //            {
        //                //Console.WriteLine("Errore di ricezione della richiesta");
        //                switch (response[2])
        //                {
        //                    case 0x01:
        //                        //Console.WriteLine("ILLEGAL FUNCTION");
        //                        break;
        //                    case 0x02:
        //                        //Console.WriteLine("ILLEGAL DATA ADDRESS ");
        //                        break;
        //                    case 0x03:
        //                        //Console.WriteLine("ILLEGAL DATA VALUE");
        //                        break;
        //                    case 0x04:
        //                        //Console.WriteLine("SERVER DEVICE FAILURE");
        //                        break;
        //                    default:
        //                        //Console.WriteLine("ANOTHER ERROR");
        //                        break;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        //Console.WriteLine("Nessuna risposta ricevuta");
        //    }
        //    return data;
        //}

        public static List<int> getMessage(TSerialManager serialPort, byte[] requestToSend, int cod, int numAdd)
        {
            var tStart = DateTime.Now;
            bool recivedCheck = false;
            List<byte> response = new List<byte>();
            List<int> data = new List<int>();

            while ((DateTime.Now - tStart).TotalMilliseconds < 400)
            {
                if (serialPort.recived)
                {
                    recivedCheck = true;
                    
                    int length;
                    if (cod <= 0x02)
                    {
                        if (numAdd % 8 == 0)
                        {
                            length = 3 + numAdd / 8 + 2;
                        }
                        else
                        {
                            length = 3 + numAdd / 8 + 1 + 2;
                        }
                    }
                    else if (cod <= 0x04)
                    {
                        length = 3 + numAdd * 2 + 2;

                    }
                    else if (cod <= 0x06)
                    {
                        length = 8;
                    }
                    else
                    {
                        length = 0;
                    }
                    for (int i = 0; i < length; i++)
                    {
                        byte lettura = (byte)serialPort.ReadByte();
                        response.Add(lettura);
                        if (i == 1)
                        {
                            if ((lettura & 0x80) == 0x80)
                            {
                                length = 5;
                            }
                        }
                    }
                    ushort crcResponse = calcCRC(response.ToArray());
                    if (crcResponse == 0)
                    {
                        //return response.ToArray();

                        byte[] res = response.ToArray();
                        if (res.Length > 1)
                        {
                            if (res[0] == requestToSend[0])
                            {
                                if (res[1] == requestToSend[1])
                                {
                                    int dataLength;
                                    if ((res[1] == 0x01) || (res[1] == 0x02))
                                    {
                                        //Console.WriteLine("Risposta ricevuta alla richiesta " + response[1]);
                                        dataLength = res[2];
                                        int valToAdd = numAdd;
                                        string finalValues = "";
                                        for (int i = 3; i < 3 + dataLength; i++)
                                        {
                                            string value;
                                            string value2 = "";
                                            value = Convert.ToString(res[i], 2);
                                            for (int j = value.Length - 1; j >= 0; j--)
                                            {
                                                value2 += value[j];
                                            }
                                            if (valToAdd > 8)
                                            {
                                                while (value2.Length < 8)
                                                {
                                                    value2 += "0";
                                                }
                                                valToAdd -= 8;
                                            }
                                            finalValues += value2;
                                        }

                                        while (finalValues.Length < numAdd)
                                        {
                                            finalValues += '0';
                                        }

                                        for (int i = 0; i < finalValues.Length; i++)
                                        {
                                            if (finalValues[i] == '1')
                                            {
                                                data.Add(1);
                                                //Console.WriteLine("1");
                                            }
                                            else
                                            {
                                                data.Add(0);
                                                //Console.WriteLine("0");
                                            }
                                        }
                                    }
                                    else if (res[1] == 0x03 || res[1] == 0x04)
                                    {
                                        //Console.WriteLine("Risposta ricevuta alla richiesta " + response[1]);
                                        dataLength = res[2];
                                        data.Clear();
                                        for (int i = 3; i < 3 + dataLength; i += 2)
                                        {
                                            int value = res[i] * 256 + res[i + 1];
                                            data.Add(value);
                                            //Console.WriteLine(value);
                                        }
                                    }
                                    else if (res[1] == 0x05 || res[1] == 0x06)
                                    {
                                        //Console.WriteLine("Risposta ricevuta alla scrittura " + response[1]);
                                        bool check = true;
                                        for (int i = 0; i < res.Length; i++)
                                        {
                                            if (res[i] != requestToSend[i])
                                            {
                                                check = false;
                                            }
                                        }
                                        if (check == true)
                                        {
                                            //Console.WriteLine("scrittura avvenuta");
                                            data.Add(1);
                                        }
                                        else
                                        {
                                            //Console.WriteLine("errore nella scrittura");
                                        }
                                    }
                                    else
                                    { }
                                }
                                else if (res[1] == (requestToSend[1] + 0x80))
                                {
                                    //Console.WriteLine("Errore di ricezione della richiesta");
                                    switch (res[2])
                                    {
                                        case 0x01:
                                            //Console.WriteLine("ILLEGAL FUNCTION");
                                            break;
                                        case 0x02:
                                            //Console.WriteLine("ILLEGAL DATA ADDRESS ");
                                            break;
                                        case 0x03:
                                            //Console.WriteLine("ILLEGAL DATA VALUE");
                                            break;
                                        case 0x04:
                                            //Console.WriteLine("SERVER DEVICE FAILURE");
                                            break;
                                        default:
                                            //Console.WriteLine("ANOTHER ERROR");
                                            break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            //Console.WriteLine("Nessuna risposta ricevuta");
                        }
                        //return data;
                    }
                }
            }
            if (!recivedCheck)
            {
                //Console.WriteLine("no message");
            }
            //return new byte[1];
            return data;
        }
    }
}
