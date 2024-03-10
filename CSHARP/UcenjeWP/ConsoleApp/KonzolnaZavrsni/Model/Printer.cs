using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.KonzolnaZavrsni.Model
{
    internal class Printer : Entity
    {
        public int FepCount { get; set; }
        public string Manufacturer { get; set; }
        public string PrinterName { get; set; }
        public  int PrinterTime { get; set; }
        public PrintJob PrintJobs { get; set; }

        public override string ToString()
        {
            return PrinterName + " (" + Manufacturer + "), Printer time: "
                + (PrinterTime==null ? 0 : PrinterTime)
                + ", Fep count: " + (FepCount == null ? 0 : FepCount);
        }
    }
}
