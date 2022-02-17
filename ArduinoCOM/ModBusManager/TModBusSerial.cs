using SerialManager;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ModBusManager
{
    public static class TModBusSerial
    {
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

        public static byte[] SendMessageRead(TSerialManager serialPort, int address, int code, int startAddress, int numAddress)
        {
            if (code <= 0x04)       //if the code is a reading operation code
            {
                string hexAddress = (address % 256).ToString("X2");
                string hexCode = (code % 256).ToString("X2");
                string hexStartAddress1 = (startAddress / 256).ToString("X2");
                string hexStartAddress2 = (startAddress % 256).ToString("X2");
                string hexNumAddress1 = (numAddress / 256).ToString("X2");
                string hexNumAddress2 = (numAddress % 256).ToString("X2");      //bring evry data that compose the request to it's hexadecimal value

                List<byte> hexComandRead = new List<byte>       //compose the request
                {
                    Byte.Parse(hexAddress, System.Globalization.NumberStyles.HexNumber),
                    Byte.Parse(hexCode, System.Globalization.NumberStyles.HexNumber),
                    Byte.Parse(hexStartAddress1, System.Globalization.NumberStyles.HexNumber),
                    Byte.Parse(hexStartAddress2, System.Globalization.NumberStyles.HexNumber),
                    Byte.Parse(hexNumAddress1, System.Globalization.NumberStyles.HexNumber),
                    Byte.Parse(hexNumAddress2, System.Globalization.NumberStyles.HexNumber)
                };

                ushort crc = calcCRC(hexComandRead.ToArray());      //calculate the crc

                int crc1 = (char)(crc / 256);
                int crc2 = (char)(crc % 256);

                byte hexCrc1 = Byte.Parse(crc1.ToString("X2"), System.Globalization.NumberStyles.HexNumber);
                byte hexCrc2 = Byte.Parse(crc2.ToString("X2"), System.Globalization.NumberStyles.HexNumber);        //bring the crc to it's hexadecimale value and than in byte

                hexComandRead.Add(hexCrc2);
                hexComandRead.Add(hexCrc1);     //and append the data of the crc to the request list

                serialPort.Write(hexComandRead.ToArray(), 0, hexComandRead.Count);      //send the request to the slave specified

                return hexComandRead.ToArray();     //returrn the request sent
            }
            return new byte[0];     //if the code wasn't a reading opreation code retun en empty array
        }

        public static byte[] SendMessageWrite(TSerialManager serialPort, int address, int code, int startAddress, int value)
        {
            if (code > 0x04 && code <= 0x06)        //if the code is a writing code operation
            {
                string hexAddress = (address % 256).ToString("X2");
                string hexCode = (code % 256).ToString("X2");
                string hexStartAddress1 = (startAddress / 256).ToString("X2");
                string hexStartAddress2 = (startAddress % 256).ToString("X2");
                string hexVal1 = (value / 256).ToString("X2");
                string hexVal2 = (value % 256).ToString("X2");      //bring evry data that compose the request to it's hexadecimal value

                List<byte> hexComandWrite = new List<byte>      //compose the request
            {
                Byte.Parse(hexAddress, System.Globalization.NumberStyles.HexNumber),
                Byte.Parse(hexCode, System.Globalization.NumberStyles.HexNumber),
                Byte.Parse(hexStartAddress1, System.Globalization.NumberStyles.HexNumber),
                Byte.Parse(hexStartAddress2, System.Globalization.NumberStyles.HexNumber),
                Byte.Parse(hexVal1, System.Globalization.NumberStyles.HexNumber),
                Byte.Parse(hexVal2, System.Globalization.NumberStyles.HexNumber)
            };

                ushort crc = calcCRC(hexComandWrite.ToArray());     //calculate the crc

                int crc1 = (char)(crc / 256);
                int crc2 = (char)(crc % 256);

                byte hexCrc1 = Byte.Parse(crc1.ToString("X2"), System.Globalization.NumberStyles.HexNumber);
                byte hexCrc2 = Byte.Parse(crc2.ToString("X2"), System.Globalization.NumberStyles.HexNumber);        //bring the crc to it's hexadecimale value and than in byte

                hexComandWrite.Add(hexCrc2);
                hexComandWrite.Add(hexCrc1);        //and append the data of the crc to the request list

                serialPort.Write(hexComandWrite.ToArray(), 0, hexComandWrite.Count);        //send the request to the slave specified

                return hexComandWrite.ToArray();        //returrn the request sent
            }
            return new byte[0];     //if the code wasn't a writing opreation code retun en empty array
        }

        public static byte[] GetMessage1(TSerialManager serialPort, int cod, int numAdd)
        {
            var tStart = DateTime.Now;      //register the when it started waiting for the response
            bool recivedCheck = false;
            while ((DateTime.Now - tStart).TotalMilliseconds < 400)     //if the time flowed is less tham 400ms
            {
                if (serialPort.recived)     //if has been recived a response
                {
                    recivedCheck = true;
                    List<byte> response = new List<byte>();
                    int length;
                    if (cod <= 0x02)        //if the code is a reading code of a single bit register
                    {
                        if (numAdd % 8 == 0)    //calculate it's length on base of the quantity of the register requested
                        {
                            length = 3 + numAdd / 8 + 2;
                        }
                        else
                        {
                            length = 3 + numAdd / 8 + 1 + 2;
                        }
                    }
                    else if (cod <= 0x04)       //if the code is a reading code of a 2 byte register
                    {
                        length = 3 + numAdd * 2 + 2;        //calcuate it's length on base of the quantity of register requested

                    }
                    else if (cod <= 0x06)       //if is a writing code
                    {
                        length = 8;     //it's request length is fixed
                    }
                    else
                    {
                        length = 0;     //if it's not a reading/writing request not read anithng
                    }
                    for (int i = 0; i < length; i++)
                    {
                        byte lettura = (byte)serialPort.ReadByte();     //read the number of byte specified before
                        response.Add(lettura);
                        if (i == 1)
                        {
                            if ((lettura & 0x80) == 0x80)       //if the response code action is in logic and with 0x80
                            {
                                length = 5;     //it's an error so rewrite it's length to 5 (fixed length of error response)
                            }
                        }
                    }
                    ushort crcResponse = calcCRC(response.ToArray());       //calculate crc of the full message of response (crc included)
                    if (crcResponse == 0)       //if the result is 0 it means that the message hasn't been corrupted
                    {
                        return response.ToArray();  //so return it
                    }
                }
            }
            if (!recivedCheck)      //if after 400ms no message has recived or the crc calculated is different than 0 (so the message is corrupted)
            { }
            return new byte[0];     //return an empty byte array
        }

        public static byte[] GetMessage(TSerialManager serialPort, int cod, int numAdd)
        {
            var tStart = DateTime.Now;      //register the when it started waiting for the response
            bool recivedCheck = false;
            while ((DateTime.Now - tStart).TotalMilliseconds < 500)     //if the time flowed is less tham 400ms
            {
                Thread.Sleep(200);
                int bytes = serialPort.BytesToRead;
                byte[] buffer = new byte[bytes];
                serialPort.Read(buffer, 0, bytes);

                ushort crcResponse = calcCRC(buffer);       //calculate crc of the full message of response (crc included)
                if (crcResponse == 0)       //if the result is 0 it means that the message hasn't been corrupted
                {
                    return buffer;  //so return it
                }
            }
            if (!recivedCheck)      //if after 400ms no message has recived or the crc calculated is different than 0 (so the message is corrupted)
            { }
            return new byte[0];     //return an empty byte array
        }

        public static List<int> InterpreterMessage(byte[] response, byte[] requestToSend, int numAdd)
        {
            List<int> data = new List<int>();
            if (response.Length > 1)        //if the response is longer than 1 byte
            {
                if (response[0] == requestToSend[0])        //the send correspond tho the destinatary of the request
                {
                    if (response[1] == requestToSend[1])        //and the code of the response is the same as the code of the request
                    {
                        int dataLength;
                        if ((response[1] == 0x01) || (response[1] == 0x02))     //if the response is a response to the reading bit action
                        {
                            //Console.WriteLine("Risposta ricevuta alla richiesta " + response[1]);
                            dataLength = response[2];
                            int valToAdd = numAdd;
                            string finalValues = "";
                            for (int i = 3; i < 3 + dataLength; i++)
                            {
                                string value;
                                string value2 = "";
                                value = Convert.ToString(response[i], 2);
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
                                finalValues += value2;      //compose the value of the esponse as a string
                            }

                            while (finalValues.Length < numAdd)
                            {
                                finalValues += '0';     //and add the ending 0 necessary to complete the response
                            }

                            for (int i = 0; i < finalValues.Length; i++)        //than compose the value response list
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
                        else if (response[1] == 0x03 || response[1] == 0x04)        //if the response is a response to the reading 2 byte action
                        {
                            //Console.WriteLine("Risposta ricevuta alla richiesta " + response[1]);
                            dataLength = response[2];
                            data.Clear();
                            for (int i = 3; i < 3 + dataLength; i += 2)
                            {
                                int value = response[i] * 256 + response[i + 1];
                                data.Add(value);        //compose the value of the response and add them to the value response list
                                //Console.WriteLine(value);
                            }
                        }
                        else if (response[1] == 0x05 || response[1] == 0x06)        //if the response is a response to a writing action
                        {
                            //Console.WriteLine("Risposta ricevuta alla scrittura " + response[1]);
                            bool check = true;
                            for (int i = 0; i < response.Length; i++)
                            {
                                if (response[i] != requestToSend[i])
                                {
                                    check = false;      //check if the response is the same as the request
                                }
                            }
                            if (check == true)
                            {
                                //Console.WriteLine("scrittura avvenuta");
                                data.Add(1);        //if so compose the response list with a 1
                            }
                            else
                            {
                                //Console.WriteLine("errore nella scrittura");
                            }
                        }
                        else
                        { }
                    }
                    else if (response[1] == (requestToSend[1] + 0x80))      //if the response is an error response 
                    {
                        //Console.WriteLine("Errore di ricezione della richiesta");
                        switch (response[2])        //throw an exception with the appropriated message
                        {
                            case 0x01:
                                //Console.WriteLine("ILLEGAL FUNCTION");
                                throw new Exception($"MODBUS ERROR: ILLEGAL FUNCTION 0X{requestToSend[1].ToString("X2")}");
                                break;
                            case 0x02:
                                //Console.WriteLine("ILLEGAL DATA ADDRESS ");
                                throw new Exception($"MODBUS ERROR: ILLEGAL DATA ADDRESS 0X{requestToSend[2].ToString("X2")}{requestToSend[3].ToString("X2")}");
                                break;
                            case 0x03:
                                //Console.WriteLine("ILLEGAL DATA VALUE");
                                throw new Exception($"MODBUS ERROR: ILLEGAL DATA VALUE");
                                break;
                            case 0x04:
                                //Console.WriteLine("SERVER DEVICE FAILURE");
                                throw new Exception($"MODBUS ERROR: SERVER DEVICE FAILURE");
                                break;
                            default:
                                //Console.WriteLine("ANOTHER ERROR");
                                throw new Exception($"MODBUS ERROR");
                                break;
                        }
                    }
                }
            }
            else        //if no response has been recived
            {
                throw new Exception($"MODBUS ERROR: NO RESPONSE RECIVED");      //throw an error with a message that report the fact
            }
            data.Add(response[1]);
            return data;        //return the data list with the value loaded during the function ora an empty list in case of error
        }
    }
}
