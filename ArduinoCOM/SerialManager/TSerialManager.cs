using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SerialManager
{
    public class TSerialManager : System.IO.Ports.SerialPort
    {
        public bool recived { get; set; }

        public TSerialManager(string portName, int baudRate, System.IO.Ports.Parity parity, int dataBits, System.IO.Ports.StopBits stopBits)
            : base(portName, baudRate, parity, dataBits, stopBits)
        {
            this.DataReceived += TSerialManager_DataReceived;
        }

        private void TSerialManager_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Task.Run(() =>
            {
                SerialPort serialPort = sender as SerialPort;
                if (serialPort != null)
                {
                    recived = true;
                   
                }
            });
        }
    }
}
