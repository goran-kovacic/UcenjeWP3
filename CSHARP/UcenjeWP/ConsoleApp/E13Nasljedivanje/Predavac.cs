using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.E13Nasljedivanje
{
    internal class Predavac:Osoba
    {
        public string? Iban { get; set; }
        public override string ToString()
        {
            return Ime + " " + Prezime + ": " + Iban;
        }
    }
}
