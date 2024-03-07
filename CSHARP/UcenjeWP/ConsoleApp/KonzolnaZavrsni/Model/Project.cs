using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.KonzolnaZavrsni.Model
{
    internal class Project : Entity
    {
        public string ProjectName { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public bool Completed { get; set; }
        public TimeOnly? TotalPrintTime { get; set; }
        public int? TotalPrintCount { get; set; }
        public decimal? TotalCost { get; set; }
        public string? ProjectDescription { get; set; }
        public List<Part> PartsInProject { get; set; }

        public override string ToString()
        {
            return ProjectName + " - Started: " + CreationDate + 
                ", Completion date: " 
                +( CompletionDate==null ? "Work in progress" : CompletionDate.ToString());
        }
    }
}
