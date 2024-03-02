﻿using ConsoleApp.E13Nasljedivanje;
using ConsoleApp.E17KonzolnaAplikacija.Model;

namespace ConsoleApp.E17KonzolnaAplikacija
{
    internal class ObradaGrupa
    {
        public List<Grupa> Grupe { get; }

        private Izbornik Izbornik;

        public ObradaGrupa(Izbornik izbornik) : this()
        {
            this.Izbornik = izbornik;
            if (Pomocno.dev)
            {
                TestniPodaci();
            }
        }

        public ObradaGrupa()
        {
            Grupe = new List<Grupa>();
        }

        private void TestniPodaci()
        {
            Grupe.Add(new Grupa()
            {
                Sifra = 1,
                Naziv = "WP3",
                Smjer = Izbornik.ObradaSmjer.Smjerovi[0],
                Polaznici = Izbornik.ObradaPolaznik.Polaznici.GetRange(0, 5),
                DatumPocetka = DateTime.Now,
                Predavac = Izbornik.ObradaPredavac.Predavaci[0]
            });
        }

        public void PrikaziIzbornik()
        {

            Console.WriteLine("Izbornik za rad s grupama");
            Console.WriteLine("1. Pregled postojećih grupa");
            Console.WriteLine("2. Unos nove grupe");
            Console.WriteLine("3. Promjena postojeće grupe");
            Console.WriteLine("4. Brisanje grupe");
            Console.WriteLine("5. Povratak na glavni izbornik");
            switch (Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika grupa: ",
                "Odabir mora biti 1-5", 1, 5))
            {
                case 1:
                    Console.Clear();
                    PrikaziGrupe();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNovogGrupe();
                    Console.Clear();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjenaGrupe();
                    Console.Clear();
                    PrikaziIzbornik();
                    break;
                case 4:
                    BrisanjeGrupe();
                    Console.Clear();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Gotov rad s grupama");
                    break;
            }
        }

        private void PromjenaGrupe()
        {
            PrikaziGrupe();
            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj grupe: ", "Nije dobar odabir", 1, Grupe.Count());
            var p = Grupe[index - 1];
            p.Sifra = Pomocno.ucitajCijeliBroj("Unesite šifra grupe (" + p.Sifra + "): ",
                "Unos mora biti pozitivni cijeli broj");
            p.Naziv = Pomocno.UcitajString("Unesite naziv grupe (" + p.Naziv + "): ",
                "Unos obavezan");
            Console.WriteLine("Trenutni smjer: {0}", p.Smjer.Naziv);
            p.Smjer = PostaviSmjer();
            Console.WriteLine("Trenutni polaznici:");
            Console.WriteLine("------------------");
            Console.WriteLine("---- Polaznici ----");
            Console.WriteLine("------------------");
            int b = 1;
            foreach (Polaznik polaznik in p.Polaznici)
            {
                Console.WriteLine("{0}. {1}", b++, polaznik);
            }
            Console.WriteLine("------------------");
            p.Polaznici = IzmjeniPolaznike(index - 1);
            p.Predavac = PostaviPredavaca();
        }

        private List<Polaznik> IzmjeniPolaznike(int index)
        {
            List<Polaznik> polaznici = Grupe[index].Polaznici;
            while (Pomocno.ucitajBool("Zelite li mijenjati polaznike? (da ili bilo sto drugo za ne): "))
            {                
                switch(Pomocno.ucitajBrojRaspon("Zelite li (1)dodati ili (2)obrisati polaznika? 0 za prekid: ", "Odabir mora biti 1,2 ili 0!",
                    1, 2, 0))
                {
                    case 1:
                        polaznici.Add(PostaviPolaznika());
                        break;
                    case 2:
                        ObrisiPolaznika(polaznici);
                        break;
                    case 0:                        
                        break;
                }
            }
            return polaznici;
        }

        private void ObrisiPolaznika(List<Polaznik> polaznici)
        {
            Console.WriteLine("------------------");
            Console.WriteLine("---- Polaznici ----");
            Console.WriteLine("------------------");
            int b = 1;
            foreach (Polaznik polaznik in polaznici)
            {
                Console.WriteLine("{0}. {1}", b++, polaznik);
            }
            Console.WriteLine("------------------");

            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj polaznika: ", "Nije dobar odabir", 1, Izbornik.ObradaPolaznik.Polaznici.Count());
            Console.Write("Jeste li sigurni da zelite obrisati polaznika {0}", polaznici[index - 1].Ime + " " + polaznici[index-1].Prezime);
            if (Pomocno.ucitajBool("? da ili bilo sto drugo za ne: "))
            {
                polaznici.RemoveAt(index - 1);
            }
            
        }

        private List<Polaznik> PostaviPolaznike()
        {
            List<Polaznik> polaznici = new List<Polaznik>();
            while (Pomocno.ucitajBool("Želite li dodati polaznike? (da ili bilo što drugo za ne): "))
            {
                polaznici.Add(PostaviPolaznika());
            }

            return polaznici;
        }

        private Polaznik PostaviPolaznika()
        {
            Izbornik.ObradaPolaznik.PregledPolaznika();
            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj polaznika: ", "Nije dobar odabir", 1, Izbornik.ObradaPolaznik.Polaznici.Count());
            return Izbornik.ObradaPolaznik.Polaznici[index - 1];
        }


        private Smjer PostaviSmjer()
        {
            Izbornik.ObradaSmjer.PrikaziSmjerove();
            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj smjera: ", "Nije dobar odabir", 1, Izbornik.ObradaSmjer.Smjerovi.Count());
            return Izbornik.ObradaSmjer.Smjerovi[index - 1];
        }

        private void BrisanjeGrupe()
        {
            PrikaziGrupe();
            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj grupe: ", "Nije dobar odabir", 1, Grupe.Count());
            Grupe.RemoveAt(index - 1);
        }

        private void UnosNovogGrupe()
        {
            var g = new Grupa();
            g.Sifra = Pomocno.ucitajCijeliBroj("Unesite šifra grupe: ",
                "Unos mora biti pozitivni cijeli broj");
            g.Naziv = Pomocno.UcitajString("Unesite naziv grupe: ",
                "Unos obavezan");
            g.Smjer = PostaviSmjer();
            g.Polaznici = PostaviPolaznike();
            g.DatumPocetka = Pomocno.ucitajDatum("Unesi datum grupe u formatu dd.MM.yyyy.", "Greška");
            g.Predavac = PostaviPredavaca();
            Grupe.Add(g);

        }

        private Predavac PostaviPredavaca()
        {
            Izbornik.ObradaPredavac.PrikaziPredavace();
            int index = Pomocno.ucitajBrojRaspon("Odaber redni broj predavaca (0 za prekid): ", "Nije dobar unos", 1, Izbornik.ObradaPredavac.Predavaci.Count(), 0);
            if (index == 0)
            {
                return null;
            }
            return Izbornik.ObradaPredavac.Predavaci[index - 1];
        }

        public void PrikaziGrupe()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("---- Grupe ----");
            Console.WriteLine("------------------");
            int b = 1;
            foreach (Grupa grupa in Grupe)
            {

                if (grupa.Predavac == null)
                {
                    Console.WriteLine("{0}. {1} ({2}, predavac: NEMA)", b++, grupa.Naziv, grupa.Smjer.Naziv);
                    foreach (Polaznik p in grupa.Polaznici)
                    {
                        Console.WriteLine("\t" + p);
                    }
                }
                else
                {

                    Console.WriteLine("{0}. {1} ({2}, predavac: {3})", b++, grupa.Naziv, grupa.Smjer.Naziv, grupa.Predavac.ToString());
                    foreach (Polaznik p in grupa.Polaznici)
                    {
                        Console.WriteLine("\t" + p);
                    }
                }
            }
            Console.WriteLine("------------------");
        }


    }
}