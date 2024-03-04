using ConsoleApp.E17KonzolnaAplikacija.Model;

namespace ConsoleApp.E17KonzolnaAplikacija

{
    internal class ObradaPolaznik
    {
        public List<Polaznik> Polaznici { get; }

        public ObradaPolaznik() 
        { 
            Polaznici = new List<Polaznik>();
            if (Pomocno.dev)
            {
                TestniPodaci();
            }
        }

        public void PrikaziIzbornik()
        {
           
            Console.WriteLine("Izbornik za rad s polaznicima");
            Console.WriteLine("1. Pregled postojećih polaznika");
            Console.WriteLine("2. Unos novog polaznika");
            Console.WriteLine("3. Promjena postojećeg polaznika");
            Console.WriteLine("4. Brisanje polaznika");
            Console.WriteLine("5. Povratak na glavni izbornik");
            switch (Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika polaznika: ",
                "Odabir mora biti 1-5", 1, 5))
            {
                
                case 1:
                    Console.Clear();
                    PregledPolaznika();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UcitajPolaznika();
                    Console.Clear();
                    PregledPolaznika();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjenaPolaznika();
                    Console.Clear();
                    PregledPolaznika();
                    PrikaziIzbornik();
                    break;
                case 4:
                    BrisanjePolaznika();
                    Console.Clear();
                    PregledPolaznika();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Gotov rad s polaznicima");
                    break;
            }
        }

        private void PromjenaPolaznika()
        {
            PregledPolaznika();
            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj polaznika: ", "Nije dobar odabir", 1, Polaznici.Count());
            var p = Polaznici[index - 1];

            int novaSifra = Pomocno.promijeniCijeliBroj("Unesite šifra polaznika (" + p.Sifra + "): ",
                "Unos mora biti pozitivni cijeli broj");
            while(Polaznici.Exists(polazn => polazn.Sifra == novaSifra && polazn != p)) 
            {
                Console.WriteLine("Postojeca sifra, unesi novu");
                novaSifra = Pomocno.promijeniCijeliBroj("Unesite šifra polaznika (" + p.Sifra + "): ",
                "Unos mora biti pozitivni cijeli broj");
            }
            p.Sifra = novaSifra == 0 ? p.Sifra : novaSifra;
            Console.WriteLine();

            string novoIme = Pomocno.PromijeniString("Unesi ime polaznika (" + p.Ime + "): ", "Ime obavezno");
            p.Ime = novoIme == "" ? p.Ime : novoIme;
            Console.WriteLine();

            string novoPrezime = Pomocno.PromijeniString("Unesi Prezime polaznika (" + p.Prezime + "): ", "Prezime obavezno");
            p.Prezime = novoPrezime == "" ? p.Prezime : novoPrezime;
            Console.WriteLine();

            string noviEmail = Pomocno.PromijeniString("Unesi Email polaznika (" + p.Email + "): ", "Email obavezno");
            p.Email = noviEmail == "" ? p.Email : noviEmail;
            Console.WriteLine();

            string noviOIB = Pomocno.PromijeniString("Unesi OIB polaznika (" + p.Oib + "): ", "OIB obavezno");
            p.Oib = noviOIB == "" ? p.Oib : noviOIB;
        }

        private void BrisanjePolaznika()
        {
            PregledPolaznika();
            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj polaznika: ", "Nije dobar odabir", 1, Polaznici.Count());
            Polaznici.RemoveAt(index - 1);
        }

        public void PregledPolaznika()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("---- Polaznici ----");
            Console.WriteLine("------------------");
            int b = 1;
            Polaznici.ForEach(pol => Console.WriteLine("{0}. {1}", b++, pol));
            Console.WriteLine("------------------");
        }

        private void UcitajPolaznika()
        {
            var p = new Polaznik();

            int sifra = Pomocno.ucitajCijeliBroj("Unesite šifra polaznika: ",
                "Unos mora biti pozitivni cijeli broj");
            while(Polaznici.Exists(pol => pol.Sifra == sifra))
            {
                Console.WriteLine("Postojeca sifra, unesi novu");
                sifra = Pomocno.ucitajCijeliBroj("Unesite šifra polaznika: ",
                "Unos mora biti pozitivni cijeli broj");
            }
            
            p.Ime = Pomocno.UcitajString("Unesi ime polaznika: ", "Ime obavezno");
            p.Prezime = Pomocno.UcitajString("Unesi Prezime polaznika: ", "Prezime obavezno");
            p.Email = Pomocno.UcitajString("Unesi Email polaznika: ", "Email obavezno");
            p.Oib = Pomocno.UcitajString("Unesi OIB polaznika: ", "OIB obavezno");
            Polaznici.Add(p);

        }

        private void TestniPodaci()
        {

            for(int i=0;i<20; i++) {
                string name = Faker.Name.First();
                string lastName = Faker.Name.Last();
                Polaznici.Add(new Polaznik
                {
                    Sifra = i+1,                    
                    Ime = name,
                    Prezime = lastName,
                    Email = name.ToLower() + "." + lastName.ToLower() + "@" + Faker.Internet.DomainName(),
                    Oib = Faker.Identification.SocialSecurityNumber()
                });
            }

            //Polaznici.Add(new Polaznik
            //{
            //    Sifra = 1,
            //    Ime = "Ana",
            //    Prezime="Gal",
            //    Email="agal@gmail.com",
            //    Oib="33736472822"
            //});

            //Polaznici.Add(new Polaznik
            //{
            //    Sifra = 2,
            //    Ime = "Marija",
            //    Prezime = "Zimska",
            //    Email = "mzimska@gmail.com",
            //    Oib = "33736472821"
            //});
        }
    }
}
