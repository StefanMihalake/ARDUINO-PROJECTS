using System;
using System.Collections.Generic;
using System.Text;

namespace Mqtt_WinForm
{
    public class TLedStrip
    {
        public TLedStrip(int id, bool adminRequire, int rWriteReg, int gWriteReg, int bimWriteReg, int brightnessWriteReg)
        {
            Id = id;
            AdminRequire = adminRequire;
            RWriteReg = rWriteReg;
            GWriteReg = gWriteReg;
            BWriteReg = bimWriteReg;
            BrightnessWriteReg = brightnessWriteReg;
        }

        public int Id { get; set; }
        public bool AdminRequire { get; set; }
        // Write Registers
        public int RWriteReg { get; set; }
        public int GWriteReg { get; set; }
        public int BWriteReg { get; set; }
        public int BrightnessWriteReg { get; set; }
    }
}
