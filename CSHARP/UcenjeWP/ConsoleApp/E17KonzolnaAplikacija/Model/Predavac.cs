﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.E17KonzolnaAplikacija.Model
{
    internal class Predavac : Entitet
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string IBAN { get; set; }
        public string OIB { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return Ime + " " + Prezime + ", " + Email;
        }
    }
}
