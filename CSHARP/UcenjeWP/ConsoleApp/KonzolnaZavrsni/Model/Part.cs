using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.KonzolnaZavrsni.Model
{
    internal class Part : Entity
    {
        public string? PartName { get; set; }
        public decimal? Cost { get; set; }
        public TimeOnly? PrintTime { get; set; }
        public Project? Project { get; set; }
        public List<PrintFile> FilesInPart { get; set; }
        public List<PrintJob> JobsInPart { get; set; }
        public override string ToString()

        {            
            return PartName + ", Project: " + (Project?.ProjectName ?? "not assigned to a project") ;
        }

    }
}
