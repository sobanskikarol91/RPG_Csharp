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
        public void Informacje()
        {
            Console.WriteLine(nazwa);
            statystyki.Informacja();
        }
        protected abstract int Atak();

        protected int ModyfikatorObrazen()
        {
            Kostka kostka = new Kostka(1, 3);
            return kostka.Losuj();
        }
    }
}
