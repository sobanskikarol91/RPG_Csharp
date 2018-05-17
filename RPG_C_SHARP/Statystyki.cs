using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C_SHARP
{
    class Statystyki
    {
        int zycie, sila, zrecznosc, obrona, poziom;

        public Statystyki(int zycie, int sila, int zrecznosc, int obrona, int poziom)
        { this.zycie = zycie; this.sila = sila; this.zrecznosc = zrecznosc; this.obrona = obrona; this.poziom = poziom; }

        public void Informacja()
        {
            Console.WriteLine("Poziom: " + poziom);
            Console.WriteLine("Hp: " + zycie);
            Console.WriteLine("Sila: " + sila);
            Console.WriteLine("Obrona: " + obrona);
            Console.WriteLine("Zrecznosc: " + zrecznosc);
        }
    }
}
