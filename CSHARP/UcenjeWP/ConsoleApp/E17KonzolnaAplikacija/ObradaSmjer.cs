using ConsoleApp.E17KonzolnaAplikacija.Model;

namespace ConsoleApp.E17KonzolnaAplikacija
{
    internal class ObradaSmjer
    {
        public List<Smjer> Smjerovi { get; }

        public ObradaSmjer()
        {
            Smjerovi = new List<Smjer>();
            if (Pomocno.dev)
            {
                TestniPodaci();
            }
        }

        public void PrikaziIzbornik()
        {
            
            Console.WriteLine("Izbornik za rad s smjerovima");
            Console.WriteLine("1. Pregled postojećih smjerova");
            Console.WriteLine("2. Unos novog smjera");
            Console.WriteLine("3. Promjena postojećeg smjera");
            Console.WriteLine("4. Brisanje smjera");
            Console.WriteLine("5. Povratak na glavni izbornik");
            switch (Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika smjera: ",
                "Odabir mora biti 1-5", 1, 5))
            {
                case 1:
                    Console.Clear();
                    PrikaziSmjerove();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNovogSmjera();
                    Console.Clear();
                    PrikaziSmjerove();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjenaSmjera();
                    Console.Clear();
                    PrikaziSmjerove();
                    PrikaziIzbornik();
                    break;
                case 4:
                    BrisanjeSmjera();
                    Console.Clear();
                    PrikaziSmjerove();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Gotov rad s smjerovima");
                    break;
            }
        }

        private void PromjenaSmjera()
        {
            PrikaziSmjerove();
            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj smjera: ", "Nije dobar odabir", 1, Smjerovi.Count()) - 1;
            var s = Smjerovi[index];

            int novaSifra = Pomocno.promijeniCijeliBroj("Unesite šifru smjera (" + s.Sifra + ") (Enter za nastavak): ",
                "Unos mora biti pozitivni cijeli broj");

            while (Smjerovi.Exists(smjer => smjer.Sifra == novaSifra && smjer != s))
            {
                Console.WriteLine("Postojeca sifra, unesi novu");
                novaSifra = Pomocno.promijeniCijeliBroj("Unesite šifru smjera (" + s.Sifra + ") (Enter za nastavak): ",
            "Unos mora biti pozitivni cijeli broj");
            }
            s.Sifra = novaSifra == 0 ? s.Sifra : novaSifra;
            Console.WriteLine();

            string naziv = Pomocno.PromijeniString("Unesite naziv smjera (" + s.Naziv + "): ",
                "Unos obavezan");
            s.Naziv = naziv == "" ? s.Naziv : naziv;
            Console.WriteLine();

            int trajanje = Pomocno.promijeniCijeliBroj("Unesite trajanje smjera u satima (" + s.Trajanje + "): ",
                "Unos mora biti cijeli pozitivni broj");
            s.Trajanje = trajanje == 0 ? s.Trajanje : trajanje;
            Console.WriteLine();

            decimal cijena = Pomocno.promijeniDecimalniBroj("Unesite cijenu (. za decimalni dio) (" + s.Cijena + "): ", "Neispravan unos");
            s.Cijena = cijena == 0 ? s.Cijena : cijena;
            Console.WriteLine();

            decimal upisnina = Pomocno.promijeniDecimalniBroj("Unesi upisninu (. za decimalni dio) (" + s.Upisnina + "): ", "Neispravan unos");
            s.Upisnina = upisnina == 0 ? s.Upisnina : upisnina;
            Console.WriteLine();

            string verificiran = Pomocno.UcitajBoolAliString("Smjer verificiran? Da, ne ili bilo sto drugo za prekid (" + (s.Verificiran ? "da" : "ne") + "): ", "");
            if(verificiran == "da")
            {
                s.Verificiran = true;
            }else if(verificiran == "ne")
            {
                s.Verificiran= false;
            }else if (verificiran == "")
            {
                s.Verificiran = s.Verificiran;
            }
        }

        private void BrisanjeSmjera()
        {
            PrikaziSmjerove();
            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj smjera: ", "Nije dobar odabir", 1, Smjerovi.Count());
            Smjerovi.RemoveAt(index - 1);
        }

        private void UnosNovogSmjera()
        {
            var s = new Smjer();

            int sifra = Pomocno.ucitajCijeliBroj("Unesite šifra smjera: ",
                "Unos mora biti pozitivni cijeli broj");
            while(Smjerovi.Exists(smjer => smjer.Sifra == sifra))
            {
                Console.WriteLine("Postojeca sifra, unesi novu");
                sifra = Pomocno.ucitajCijeliBroj("Unesite šifra smjera: ",
                "Unos mora biti pozitivni cijeli broj");
            }
            
            s.Naziv = Pomocno.UcitajString("Unesite naziv smjera: ",
                "Unos obavezan");
            s.Trajanje = Pomocno.ucitajCijeliBroj("Unesite trajanje smjera u satima: ",
                "Unos mora biti cijeli pozitivni broj");
            s.Cijena = Pomocno.ucitajDecimalniBroj("Unesite cijenu (. za decimalni dio): ", "Unos mora biti pozitivan broj");
            s.Upisnina = Pomocno.ucitajDecimalniBroj("Unesi upisninu (. za decimalni dio): ", "Unos mora biti pozitivan broj");
            s.Verificiran = Pomocno.ucitajBool("Smjer verificiran? Da ili bilo što drugo za ne: ");
            Smjerovi.Add(s);

        }

        public void PrikaziSmjerove()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("---- Smjerovi ----");
            Console.WriteLine("------------------");
            int b = 1;
            Smjerovi.ForEach(smjer => Console.WriteLine("{0}. {1}", b++, smjer));            
            Console.WriteLine("------------------");
        }

        private void TestniPodaci()
        {

            Smjerovi.Add(new Smjer
            {
                Sifra = 1,
                Naziv = "Web programiranje",
                Trajanje = 250,
                Cijena = 1000,
                Upisnina = 50,
                Verificiran = true
            });

            // dodaj smjer
            Smjerovi.Add(new Smjer
            {
                Sifra = 2,
                Naziv = "Java programiranje",
                Trajanje = 130,
                Cijena = 1000,
                Upisnina = 50,
                Verificiran = true
            });
            // završilo dodavanje smjera


            // dodaj smjer
            Smjerovi.Add(new Smjer
            {
                Sifra = 3,
                Naziv = "Serviser",
                Trajanje = 130,
                Cijena = 1000,
                Upisnina = 50,
                Verificiran = true
            });
            // završilo dodavanje smjera



        }
    }
}
