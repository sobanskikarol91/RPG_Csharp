using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C_SHARP
{
    [Serializable]  // pozwala na zapis danych klasy do pliku
    class Statystyki
    {
        public int Zycie { get; set; }
        public int Sila { get; set; }
        public int Zrecznosc { get; set; }
        public int Obrona { get; set; }
        public int Poziom { get; set; }

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

        public static Statystyki operator +(Statystyki a, Statystyki b)
        {
            return new Statystyki(a.Zycie + b.Zycie, a.Sila + b.Sila, a.Zrecznosc + b.Zrecznosc, a.Obrona + b.Obrona, 0); // 0 bo poziomow nie dodajemy
        }
    }
}
