using ModBusManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LedStrip
{
    public partial class Form1 : Form
    {
        int r;
        int g;
        int b;

        //TSerialManager serialport;
        SerialPort serialport;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                serialport = new SerialPort("COM5", 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
                serialport.Open();
                serialport.DataReceived += GetResponseModbus;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void GetResponseModbus(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        byte[] response = TModBusSerial.GetMessage(serialport);

                        // 1. Function code 
                        // 4. Dimmer value
                        // 6. Min dimmer value
                        // 8. Max dimmer value

                        if (response.Length > 0)                    // response not empty
                        {
                            switch (response[1])
                            {
                                case 4:
                                    
                                    break;

                                case 132:

                                    break;

                                default:
                                    break;
                            }


                        }
                        else if (response.Length == 0)
                        {
                            // CRC CORUPT
                        }

                    }));
                }
            }
            catch (Exception err)
            {
                Console.WriteLine($"Error:  {err.Message}");
            }
        }


        private void bigLabel1_Click(object sender, EventArgs e)
        {
        }

        private void colorPicker_Click(object sender, EventArgs e)
        {
            r = colorPicker.SelectedColor.R;
            g = colorPicker.SelectedColor.G;
            b = colorPicker.SelectedColor.B;
            colorPanel.BackColor = Color.FromArgb(r, g, b);

            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, 206, r);
            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, 207, g);
            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, 208, b);
        }
        

        private void airButton1_Click(object sender, EventArgs e)
        {

        }

        private void airButton2_Click(object sender, EventArgs e)
        {
            if (serialport.IsOpen)
            {
                TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, 206, 0);
                TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, 207, 0);
                TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, 208, 0);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (serialport.IsOpen)
            {
                TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, 209, (int)trackBar1.Value);
            }
        }

        private void colorDialog_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            r = colorDialog1.Color.R;
            g = colorDialog1.Color.G;
            b = colorDialog1.Color.B;
            int w = (int)(colorDialog1.Color.GetBrightness()*240);

            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, 206, r);
            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, 207, g);
            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, 208, b);
            TModBusSerial.SendMessageWrite(serialport, (byte)1, (byte)0x06, 209, w);
            colorPanel.BackColor = Color.FromArgb(r, g, b);
        }
    }
}
