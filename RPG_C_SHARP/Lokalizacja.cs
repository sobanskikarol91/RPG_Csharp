using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C_SHARP
{
    class Lokalizacja
    {
        string nazwa;
        string opis;
        Przeciwnik przeciwnik;
        Przedmiot przedmiot;

        public Lokalizacja(string nazwa, string opis, Przeciwnik przeciwnik, Przedmiot przedmiot)
        {
            this.nazwa = nazwa;
            this.opis = opis;
            this.przeciwnik = przeciwnik;
            this.przedmiot = przedmiot;
        }
    }
}
