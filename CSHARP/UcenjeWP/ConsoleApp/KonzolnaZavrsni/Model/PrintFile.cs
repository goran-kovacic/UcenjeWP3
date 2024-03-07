using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.KonzolnaZavrsni.Model
{
    internal class PrintFile : Entity
    {
        public string? FileComment { get; set; }
        public string? FilePath { get; set; }
        public string FileType { get; set; }
        public Part Part { get; set; }
        public int? FileVersion { get; set; }
    }
}
