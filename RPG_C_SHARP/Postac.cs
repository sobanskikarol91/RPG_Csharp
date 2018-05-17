using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C_SHARP
{
    abstract class Postac
    {
        protected string nazwa { get; }
        protected Statystyki statystyki { get; set; }

        public Postac(string nazwa, Statystyki statystyki) { }
        protected abstract int Atak();
        void Informacje() { }
        void ModyfikatorObrazen() { }
    }
}
