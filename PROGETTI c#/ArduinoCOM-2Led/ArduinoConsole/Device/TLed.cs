using System;
using System.Collections.Generic;
using System.Text;

namespace ArduinoConsole.Device
{
    public class TLed
    {
        public TLed(int id, bool adminrequire, int ledOnWriteCoil, int ledOffWriteCoil, int minWriteReg, int maxWriteReg, int dimWriteReg, int dimReadReg, int minReadReg, int maxReadReg)
        {
            Id = id;
            AdminRequire = adminrequire;
            LedOnWriteCoil = ledOnWriteCoil;
            LedOffWriteCoil = ledOffWriteCoil;
            MinWriteReg = minWriteReg;
            MaxWriteReg = maxWriteReg;
            DimWriteReg = dimWriteReg;
            DimReadReg = dimReadReg;
            MinReadReg = minReadReg;
            MaxReadReg = maxReadReg;
        }

        public int Id { get; set; }
        public bool AdminRequire { get; set; }
        // Write Coils
        public int LedOnWriteCoil { get; set; }
        public int LedOffWriteCoil { get; set; }
        // Write Registers
        public int MinWriteReg { get; set; }
        public int MaxWriteReg { get; set; }
        public int DimWriteReg { get; set; }
        // Read Registers
        public int DimReadReg { get; set; }
        public int MinReadReg { get; set; }
        public int MaxReadReg { get; set; }



    }
}
