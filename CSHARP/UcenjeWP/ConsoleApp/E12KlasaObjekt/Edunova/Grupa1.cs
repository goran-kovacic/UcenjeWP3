using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.E12KlasaObjekt.Edunova
{
    internal class Grupa
    {
        public int? Sifra { get; set; }
        public string? Naziv { get; set; }
        public Smjer? Smjer { get; set; }

        public DateTime? DatumPocetka { get; set; }

        public int? MaxPolaznika { get; set; }

        public Predavac? Predavac { get; set; }
    }
}
