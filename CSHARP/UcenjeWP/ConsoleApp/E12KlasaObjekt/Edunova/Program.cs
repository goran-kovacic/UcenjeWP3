using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.E12KlasaObjekt.Edunova
{
    internal class Program
    {

        public static void Izvedi()
        {
            Osoba osoba = new Osoba();
            osoba.Prezime = "peric";

            osoba = new Osoba
            {
                Ime = "katja"
            };

            Osoba o = new()
            {
                Ime = "ivana"
            };

            var direktor = new Osoba() { Prezime = "kas" };
            var m = new Mjesto() { Naziv = "osijek" };

            direktor.Mjesto = m;


        }
    }
}
