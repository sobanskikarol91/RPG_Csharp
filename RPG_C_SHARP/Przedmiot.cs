using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C_SHARP
{
    class Przedmiot : IPlik
    {
        string nazwa;
        public bool Wyposazony { get; set; }
        public Statystyki Statystyki { get; }
        //Okno okno;

        public Przedmiot(string nazwa, Statystyki statystyki)
        {
            this.nazwa = nazwa;
            Statystyki = statystyki;
        }

        public void Informacja()
        {
            Console.WriteLine(nazwa + "  ");

            if (Wyposazony) Console.WriteLine("Wyposazony!");
            else Console.WriteLine("Nie Wyposazony");
        }

        public void WczytajDane()
        {
            throw new NotImplementedException();
        }

        public void ZapiszDane()
        {
            throw new NotImplementedException();
        }
    }
}
