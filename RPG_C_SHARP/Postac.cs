using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C_SHARP
{
    abstract class Postac
    {
        public string Nazwa { get; }
        public Statystyki Statystyki { get; set; }

        public Postac(string nazwa, Statystyki statystyki) { Nazwa = nazwa; Statystyki = statystyki; }
        public void Informacje()
        {
            Console.WriteLine(Nazwa);
            Statystyki.Informacja();
        }
        public abstract int Atak();

        protected int ModyfikatorObrazen()
        {
            Kostka kostka = new Kostka(1, 3);
            return kostka.Losuj();
        }
    }
}
