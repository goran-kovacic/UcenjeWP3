using ConsoleApp.KonzolnaZavrsni.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.KonzolnaZavrsni.Controller
{
    internal class PrintFilesController
    {
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public int Version { get; set; }
        public Part Part { get; set; }

        public override string ToString()
        {
            return Part.PartName + " (" + FileType + ")" + " v" + Version ;
        }
    }
}
