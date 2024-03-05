using ConsoleApp.E12KlasaObjekt.Edunova;

namespace ConsoleApp.E17KonzolnaAplikacija.Model
{
    internal class Smjer : Entitet
    {
        public string Naziv { get; set; }
        public int Trajanje { get; set; }
        public decimal Cijena { get; set; }
        public decimal Upisnina { get; set; }
        public bool Verificiran { get; set; }
        public List<Grupa>? GrupeUSmjeru { get; set; }

        public override string ToString()
        {
            return Naziv + " (" + Trajanje + ") Cijena: " + Cijena + ", Upisnina: " + Upisnina
            + ", Verificiran: " + (Verificiran ? "Da" : "Ne");
        }
    }

}
