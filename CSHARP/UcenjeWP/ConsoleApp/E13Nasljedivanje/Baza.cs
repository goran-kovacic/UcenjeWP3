using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.E13Nasljedivanje
{
    internal class Baza
    {
        public Baza(string Naziv)
        {
            this.Naziv = Naziv;
        }

        public string Naziv { get; set; }
    }
}
