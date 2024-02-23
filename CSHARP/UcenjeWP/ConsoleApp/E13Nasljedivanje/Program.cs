using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.E13Nasljedivanje
{
    internal class Program
    {
        public Program()
        {
            Primjer2();
        }

        private void Primjer2()
        {
            OsobaImpl osoba = new OsobaImpl();
            osoba.Ime = "luka";
            Console.WriteLine(osoba.GetType());
        }
        private void Primjer4()
        {
            Polaznik p1 = new() { Ime = "Iva" };
            Polaznik p2 = new() { Ime = "Iva" };

            Console.WriteLine(p1 == p2); // što će ispisati

            Console.WriteLine(p1.GetHashCode());
            Console.WriteLine(p2.GetHashCode());           

        }
    }
}

    
