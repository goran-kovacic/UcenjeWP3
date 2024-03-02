namespace ConsoleApp.E17KonzolnaAplikacija.Model
{
    internal class Grupa: Entitet
    {
        public string Naziv { get; set; }
        public Smjer Smjer { get; set; }
        public DateTime DatumPocetka { get; set; }
        public List<Polaznik> Polaznici { get; set; }
        public Predavac Predavac { get; set; }
    }
}
