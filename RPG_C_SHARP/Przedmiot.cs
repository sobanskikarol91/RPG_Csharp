using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C_SHARP
{
    [Serializable]
    class Przedmiot
    {
        public string Nazwa { get; set; }
        public bool Wyposazony { get; set; }
        public Statystyki Statystyki { get; }

        public Przedmiot(string nazwa, Statystyki statystyki)
        {
            Nazwa = nazwa;
            Statystyki = statystyki;
        }

        public void Informacja()
        {
            Console.WriteLine(Nazwa + "  ");

            if (Wyposazony) Console.WriteLine("Wyposazony!");
            else Console.WriteLine("Nie Wyposazony");

            Statystyki.Informacja();
        }
    }
}
