using ConsoleApp.E13Nasljedivanje;
using ConsoleApp.E17KonzolnaAplikacija.Model;
using System.Security.Cryptography;

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
                DatumPocetka = DateTime.Parse("2023-11-20 12:30:45"),
                Predavac = Izbornik.ObradaPredavac.Predavaci[0]
            });

            Grupe.Add(new Grupa()
            {
                Sifra = 3,
                Naziv = "WP2",
                Smjer = Izbornik.ObradaSmjer.Smjerovi[0],
                Polaznici = Izbornik.ObradaPolaznik.Polaznici.GetRange(6, 14),
                DatumPocetka = DateTime.Parse("2024-03-04 12:30:45"),
                Predavac = Izbornik.ObradaPredavac.Predavaci[0]
            });

            Grupe.Add(new Grupa()
            {
                Sifra = 2,
                Naziv = "JP28",
                Smjer = Izbornik.ObradaSmjer.Smjerovi[1],
                //Polaznici = Izbornik.ObradaPolaznik.Polaznici.GetRange(0, 5),
                DatumPocetka = DateTime.Parse("2024-05-30 12:30:45"),
                //Predavac = Izbornik.ObradaPredavac.Predavaci[0]
            });
        }

        public void PrikaziIzbornik()
        {

            Console.WriteLine("Izbornik za rad s grupama");
            Console.WriteLine("1. Pregled postojećih grupa");
            Console.WriteLine("2. Unos nove grupe");
            Console.WriteLine("3. Promjena postojeće grupe");
            Console.WriteLine("4. Brisanje grupe");
            Console.WriteLine("5. STATISTIKA");
            Console.WriteLine("6. Povratak na glavni izbornik");
            switch (Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika grupa: ",
                "Odabir mora biti 1-6", 1, 6))
            {
                case 1:
                    Console.Clear();
                    PrikaziGrupe();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNovogGrupe();
                    Izbornik.UpdateTestniPodaciZaSmjer();
                    Console.Clear();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjenaGrupe();
                    Izbornik.UpdateTestniPodaciZaSmjer();
                    Console.Clear();
                    PrikaziIzbornik();
                    break;
                case 4:
                    BrisanjeGrupe();
                    Izbornik.UpdateTestniPodaciZaSmjer();
                    Console.Clear();
                    PrikaziIzbornik();
                    break;
                case 5:
                    PrikaziStatistiku();
                    Console.Clear();
                    PrikaziIzbornik();
                    break;
                case 6:
                    Console.WriteLine("Gotov rad s grupama");
                    break;
            }
        }

        private void PrikaziStatistiku()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("---- Statistika ----");
            Console.WriteLine("--------------------");
            Console.WriteLine();
            UkupnoPolaznikaNaGrupama();
            ProsjekUGrupi();
            UkupanIznosPrihodaPoSmjerovima();
            ProsjecanIznosPrihodaPoPolazniku();
            PocetakGrupa();
            Console.ReadKey();
        }

        private void PocetakGrupa()
        {
            Grupa najranijaGrupa = Grupe.OrderBy(grupa => grupa.DatumPocetka).First();
            DateTime najranijiDatum = najranijaGrupa.DatumPocetka;
            string nazivNajranijeGrupe = najranijaGrupa.Naziv;

            Grupa najkasnijaGrupa = Grupe.OrderBy(grupa => grupa.DatumPocetka).Last();
            DateTime najkasnijiDatum = najkasnijaGrupa.DatumPocetka;
            string nazivNajkasnijeGrupe = najkasnijaGrupa.Naziv;

            //DateTime najranijiDatum = Grupe.Min(grupa => grupa.DatumPocetka);            
            //DateTime najkasnijiDatum = Grupe.Max(grupa => grupa.DatumPocetka);
            TimeSpan difference = najkasnijiDatum - najranijiDatum;

            Console.WriteLine($"Najraniji pocetak grupe: {najranijiDatum} ({nazivNajranijeGrupe})");
            Console.WriteLine($"Najkasniji pocetak grupe: {najkasnijiDatum} ({nazivNajkasnijeGrupe})");
            Console.WriteLine($"Razlika najranijeg i najkasnijeg pocetka grupe: {difference.TotalDays:0.##} dana");

            //foreach (Grupa grupa in Grupe)
            //{
            //    if(grupa.DatumPocetka == null)
            //    {
            //        continue;
            //    }
            //}
        }

        private void ProsjecanIznosPrihodaPoPolazniku()
        {
            int brojPolaznika = 0;
            decimal ukupniPrihod = 0;
            foreach(Grupa grupa in Grupe)
            {
                brojPolaznika += grupa.Polaznici?.Count() ?? 0;
                ukupniPrihod += (grupa.Smjer.Cijena + grupa.Smjer.Upisnina) * (grupa.Polaznici?.Count() ?? 0);
            }
            Console.WriteLine("Prosjecan iznos prihoda po polazniku: {0:c}", ukupniPrihod / (decimal)brojPolaznika);
        }

        private void UkupanIznosPrihodaPoSmjerovima()
        {
            decimal prihod;
            foreach (Smjer smjer in Izbornik.ObradaSmjer.Smjerovi)
            {
                prihod = 0;
                if (smjer.GrupeUSmjeru == null || smjer.GrupeUSmjeru.Count() == 0)
                {
                    Console.WriteLine("Prihod smjera {0}: Nema unesenih grupa", smjer.Naziv);
                    continue;
                }
                foreach(Grupa grupa in smjer.GrupeUSmjeru)
                {
                    int brojPolaznika = grupa.Polaznici?.Count() ?? 0;
                    prihod += (smjer.Upisnina + smjer.Cijena) * brojPolaznika;                    
                }
                Console.WriteLine("Prihod smjera {0}: {1:C}", smjer.Naziv, prihod);
            }
        }

        private void ProsjekUGrupi()
        {
            Console.Write("Prosječan broj polaznika u grupi: ");
            double prosjek;
            int broj = 0;
            foreach (var grupa in Grupe)
            {
                if (grupa.Polaznici == null || grupa.Polaznici.Count() == 0)
                {
                    broj += 0;
                }
                else
                {
                    broj += grupa.Polaznici.Count();
                }
            }
            Console.WriteLine("{0:0.##}", prosjek = (double)broj / Grupe.Count());
        }

        private void UkupnoPolaznikaNaGrupama()
        {
            Console.Write("Ukupno polaznika na svim grupama: ");
            int ukupnoPolaznika = 0;
            Grupe.ForEach(grupa => ukupnoPolaznika += (grupa.Polaznici == null ? 0 : grupa.Polaznici.Count()));
            Console.WriteLine(ukupnoPolaznika);
        }

        private void PromjenaGrupe()
        {
            PrikaziGrupe();
            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj grupe: ", "Nije dobar odabir", 1, Grupe.Count());
            var p = Grupe[index - 1];

            int novaSifra = Pomocno.promijeniCijeliBroj("Unesite šifra grupe (" + p.Sifra + "): ",
                "Unos mora biti pozitivni cijeli broj", "");
            while(Grupe.Exists(grup => grup.Sifra == novaSifra && grup != p)) 
            {
                Console.WriteLine("Postojeca sifra, unesi novu");
                novaSifra = Pomocno.promijeniCijeliBroj("Unesite šifra grupe (" + p.Sifra + "): ",
                "Unos mora biti pozitivni cijeli broj", "");
            }
            p.Sifra = novaSifra == 0 ? p.Sifra : novaSifra;


            string naziv = Pomocno.PromijeniString("Unesite naziv grupe (" + p.Naziv + "): ",
                "Unos obavezan");
            p.Naziv = naziv == "" ? p.Naziv : naziv;

            Console.WriteLine("Trenutni smjer: {0}", p.Smjer.Naziv);
            int indexSmjera = p.Smjer.Sifra;
            p.Smjer = PromijeniSmjer(indexSmjera-1);
            Console.WriteLine("Trenutni polaznici:");
            Console.WriteLine("------------------");
            Console.WriteLine("---- Polaznici ----");
            Console.WriteLine("------------------");
            int b = 1;
            if (p.Polaznici != null)
            {

                foreach (Polaznik polaznik in p.Polaznici)
                {
                    Console.WriteLine("{0}. {1}", b++, polaznik);
                }
            }
            Console.WriteLine("------------------");
            p.Polaznici = IzmjeniPolaznike(index - 1);
            if (p.Predavac != null)
            {
                int indexPredavaca = p.Predavac.Sifra;
                p.Predavac = PromijeniPredavaca(indexPredavaca - 1);
            }else if (p.Predavac == null)
            {
                p.Predavac = PostaviPredavaca();
            }
            
        }

        private List<Polaznik>? IzmjeniPolaznike(int index)
        {
            List<Polaznik> polaznici = Grupe[index].Polaznici;
            while (Pomocno.ucitajBool("Zelite li mijenjati polaznike? (da ili bilo sto drugo za ne): "))
            {                
                switch(Pomocno.ucitajBrojRaspon("Zelite li (1)dodati ili (2)obrisati polaznika? Enter za prekid: ", "Odabir mora biti 1,2 ili 0!",
                    1, 2, ""))
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

        private Smjer PromijeniSmjer(int indexSmjera)
        {
            Izbornik.ObradaSmjer.PrikaziSmjerove();
            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj smjera: ", "Nije dobar odabir", 1, Izbornik.ObradaSmjer.Smjerovi.Count(), "");
            if(index == 0)
            {
                return Izbornik.ObradaSmjer.Smjerovi[indexSmjera];
            }
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

            int sifra = Pomocno.ucitajCijeliBroj("Unesite šifra grupe: ",
                "Unos mora biti pozitivni cijeli broj");
            while(Grupe.Exists(gr => gr.Sifra == sifra))
            {
                Console.WriteLine("Postojeca sifra, unesi novu");
                sifra = Pomocno.ucitajCijeliBroj("Unesite šifra grupe: ",
                "Unos mora biti pozitivni cijeli broj");
            }
            
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
            int index = Pomocno.ucitajBrojRaspon("Odaber redni broj predavaca (enter za prekid): ", "Nije dobar unos", 1, Izbornik.ObradaPredavac.Predavaci.Count(), "");
            if (index == 0)
            {
                return null;
            }
            return Izbornik.ObradaPredavac.Predavaci[index - 1];
        }

        private Predavac PromijeniPredavaca(int indexPredavaca)
        {
            Izbornik.ObradaPredavac.PrikaziPredavace();
            int index = Pomocno.ucitajBrojRaspon("Odaber redni broj predavaca (enter za prekid): ", "Nije dobar unos", 1, Izbornik.ObradaPredavac.Predavaci.Count(), "");
            if(index == 0)
            {
                return Izbornik.ObradaPredavac.Predavaci[indexPredavaca];
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
                    if (grupa.Polaznici == null)
                    {
                        Console.WriteLine("\tGrupa nema polaznika");
                    }
                    else
                    {
                        foreach (Polaznik p in grupa.Polaznici)
                        {
                            Console.WriteLine("\t" + p);
                        }
                    }
                }
                else
                {

                    Console.WriteLine("{0}. {1} ({2}, predavac: {3})", b++, grupa.Naziv, grupa.Smjer.Naziv, grupa.Predavac.ToString());
                    if (grupa.Polaznici == null)
                    {
                        Console.WriteLine("\tGrupa nema polaznika");
                    }
                    else
                    {
                        foreach (Polaznik p in grupa.Polaznici)
                        {
                            Console.WriteLine("\t" + p);
                        }
                    }
                }
            }
            Console.WriteLine("------------------");
        }


    }
}
