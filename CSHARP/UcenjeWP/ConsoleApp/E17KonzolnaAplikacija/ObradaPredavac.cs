using ConsoleApp.E13Nasljedivanje;
using ConsoleApp.E17KonzolnaAplikacija.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.E17KonzolnaAplikacija
{
    internal class ObradaPredavac
    {

        public List<Predavac> Predavaci { get; }
        private Izbornik Izbornik;

        public ObradaPredavac(Izbornik izbornik):this()
        {
            this.Izbornik=izbornik;
           
        }

        public ObradaPredavac()
        {
            Predavaci = new List<Predavac>();
            if (Pomocno.dev)
            {
                TestniPodaci();
            }
        }

        public void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad s predavacima");
            Console.WriteLine("1. Pregled postojećih predavaca");
            Console.WriteLine("2. Unos novog predavaca");
            Console.WriteLine("3. Promjena postojećeg predavaca");
            Console.WriteLine("4. Brisanje predavaca");
            Console.WriteLine("5. Povratak na glavni izbornik");
            switch(Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika: ",
                "Odabir mora biti od 1 do 5", 1, 5))
            {
                case 1:
                    Console.Clear();
                    PrikaziPredavace();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNovogPredavaca();
                    Console.Clear();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjenaPredavaca();
                    Console.Clear();
                    PrikaziIzbornik();
                    break;
                case 4:
                    BrisanjePredavac();
                    Console.Clear();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Gotov rad s predavacima");
                    break;
            }
        }

        private void BrisanjePredavac()
        {
            PrikaziPredavace();
            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj predavaca: ", "Nije dobar unos", 1, Predavaci.Count());
            Predavaci.RemoveAt(index-1);
        }

        private void PromjenaPredavaca()
        {
            PrikaziPredavace();
            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj predavaca: ", "Nije dobar odabir", 1, Predavaci.Count());
            Predavac p = Predavaci[index - 1];
            p.Ime = Pomocno.UcitajString("Unesi ime predavaca (" + p.Ime + "): ", "Ime obavezno");
            p.Prezime = Pomocno.UcitajString("Unesi Prezime predavaca (" + p.Prezime + "): ", "Prezime obavezno");
            p.Email = Pomocno.UcitajString("Unesi Email predavaca (" + p.Email + "): ", "Email obavezno");
            p.OIB = Pomocno.UcitajString("Unesi OIB predavaca (" + p.OIB + "): ", "OIB obavezno");
            p.IBAN = Pomocno.UcitajString("Unesi IBAN predavaca(" + p.IBAN + "): ", "IBAN obavezno");
        }

        private void UnosNovogPredavaca()
        {
            Predavac p = new Predavac();
            p.Sifra = Pomocno.ucitajCijeliBroj("Unesi sifru predavaca: ", "Unos mora biti pozitivan broj");
            p.Ime = Pomocno.UcitajString("Unesi ime: ", "Ime obavezno");
            p.Prezime = Pomocno.UcitajString("Unesi Prezime predavaca: ", "Prezime obavezno");
            p.Email = Pomocno.UcitajString("Unesi Email predavaca: ", "Email obavezno");
            p.OIB = Pomocno.UcitajString("Unesi OIB predavaca: ", "OIB obavezno");
            p.IBAN = Pomocno.UcitajString("Unesi IBAN predavaca: ", "OIB obavezno");
            Predavaci.Add(p);
        }

        public void PrikaziPredavace()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("---- Predavaci ----");
            Console.WriteLine("-------------------");
            int counter = 1;
            foreach(Predavac p in Predavaci)
            {
                Console.WriteLine("{0}. {1}", counter++, p);
            }
            Console.WriteLine("-------------------");
        }

        private void TestniPodaci()
        {
            Predavaci.Add(new Predavac()
            {
                Ime = "Pero",
                Prezime = "Peric",
                Email = "email@email.com",
                IBAN = "HR1234567890",
                OIB = "1234567890",
                Sifra = 1
            });
        }
    }
}
