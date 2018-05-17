using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C_SHARP
{
    class Przedmiot
    {
        string nazwa;
        public bool Wyposazony { get; set; }
        public Statystyki Statystyki { get; }
        //Okno okno;

        Przedmiot(string nazwa, Statystyki statystyki)
        {
            this.nazwa = nazwa;
            Statystyki = statystyki;
        }

        public void Informacja()
        {

        }
    }
}
