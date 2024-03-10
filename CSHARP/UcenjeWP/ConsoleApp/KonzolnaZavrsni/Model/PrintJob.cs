using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.KonzolnaZavrsni.Model
{
    internal class PrintJob : Entity
    {
        public decimal Cost { get; set; }
        public int PrintTime { get; set; }
        public bool Result { get; set; }
        public decimal Volume { get; set; }
        public Material Material { get; set; }
        public Printer Printer { get; set; }
        public Part Part { get; set; }
    }
}
