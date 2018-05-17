using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C_SHARP
{
    class Statystyki : IPlik
    {
        public int Zycie { get; }
        public int Sila { get; }
        public int Zrecznosc { get; }
        public int Obrona { get; }
        public int Poziom { get; }

        public Statystyki() { }
        public Statystyki(int zycie, int sila, int zrecznosc, int obrona, int poziom)
        { Zycie = zycie; Sila = sila; Zrecznosc = zrecznosc; Obrona = obrona; Poziom = poziom; }

        public void Informacja()
        {
            Console.WriteLine("Poziom: " + Poziom);
            Console.WriteLine("Hp: " + Zycie);
            Console.WriteLine("Sila: " + Sila);
            Console.WriteLine("Obrona: " + Obrona);
            Console.WriteLine("Zrecznosc: " + Zrecznosc);
        }

        public void WczytajDane()
        {
            throw new NotImplementedException();
        }

        public void ZapiszDane()
        {
            throw new NotImplementedException();
        }

        public static Statystyki operator +(Statystyki a, Statystyki b)
        {
            return new Statystyki(a.Zycie + b.Zycie, a.Sila + b.Sila, a.Zrecznosc + b.Zrecznosc, a.Obrona + b.Obrona, 0); // 0 bo poziomow nie dodajemy
        }
    }
}
