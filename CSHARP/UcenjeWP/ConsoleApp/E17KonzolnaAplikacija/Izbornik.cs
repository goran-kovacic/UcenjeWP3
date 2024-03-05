

using ConsoleApp.E17KonzolnaAplikacija.Model;

namespace ConsoleApp.E17KonzolnaAplikacija
{
    internal class Izbornik
    {
        public ObradaSmjer ObradaSmjer { get; }
        public ObradaPolaznik ObradaPolaznik { get; }

        private ObradaGrupa ObradaGrupa;
        public ObradaPredavac ObradaPredavac { get; }

        public Izbornik() 
        {
            
            Pomocno.dev = true;
            ObradaSmjer = new ObradaSmjer();
            ObradaPolaznik = new ObradaPolaznik();
            ObradaPredavac = new ObradaPredavac(); 
            ObradaGrupa =new ObradaGrupa(this);
            UpdateTestniPodaciZaSmjer();
            
            //PozdravnaPoruka();
            PrikaziIzbornik();
        }

        private void UpdateTestniPodaciZaSmjer()
        {
            foreach (Smjer smjer in ObradaSmjer.Smjerovi)
            {
                string nazivSmjera = smjer.Naziv;
                List<Grupa> grupe = new List<Grupa>();
                foreach (Grupa grupa in ObradaGrupa.Grupe)
                {
                    if(grupa.Smjer.Naziv == nazivSmjera)
                    {
                        grupe.Add(grupa);
                    }
                }
                smjer.GrupeUSmjeru = grupe;
            }
        }

        private void PozdravnaPoruka()
        {
            Console.WriteLine("*************************************");
            Console.WriteLine("***** Edunova Console APP v 1.0 *****");
            Console.WriteLine("*************************************");
        }

        private void PrikaziIzbornik()
        {
            Console.Clear();
            PozdravnaPoruka();
            Console.WriteLine("Glavni izbornik");
            Console.WriteLine("1. Smjerovi");
            Console.WriteLine("2. Polaznici");
            Console.WriteLine("3. Grupe");
            Console.WriteLine("4. Predavaci");
            Console.WriteLine("5. IZLAZ");
            
            switch (Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika: ",
                "Odabir mora biti 1 - 6.", 1, 6))
            {
                case 1:
                    Console.Clear();
                    ObradaSmjer.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 2:
                    Console.Clear();
                    ObradaPolaznik.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 3:
                    Console.Clear();
                    ObradaGrupa.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 4:
                    Console.Clear();
                    ObradaPredavac.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Hvala na korištenju, doviđenja");
                    break;
                
                //case 5:
                //    ConsoleHelper.SetConsoleFont("Times New Roman", 40);
                //    PrikaziIzbornik();
                //    break;
                //case 6:
                //    ConsoleHelper.SetConsoleFont("Arial", 50);
                //    PrikaziIzbornik();
                //    break;
            }
        }
    }
}
