using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.E13Nasljedivanje
{
    internal class PolaznikPrimjer:Osoba
    {
        public PolaznikPrimjer():base() { }

        public PolaznikPrimjer(string ime, string prezime, string brojUgovora):base(ime, prezime)
        {
            this.brojUgovora=brojUgovora;
        }

        public string? brojUgovora { get; set; }
        public override string ToString()
        {
            return base.ToString() + ": " + brojUgovora;
        }

    }
}
