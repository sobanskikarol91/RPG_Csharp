using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C_SHARP
{
    class Ekwipunek
    {
        public List<Przedmiot> przedmioty { get; set; }
        void Przegladaj()
        {
            Console.WriteLine("***Ekwipunek***");

            if (przedmioty.Count == 0)
                Console.WriteLine("Ekwipunek jest pusty");
            else
            {
                for (int i = 0; i < przedmioty.Count; i++)
                {
                    Console.WriteLine("============");
                    Console.WriteLine(i + ")");
                    przedmioty[i].Informacja();
                    Console.WriteLine(" ============ ");
                }
            }

        }

        List<Przedmiot> AktywnePrzedmioty()
        {
            List<Przedmiot> aktywne = new List<Przedmiot>();

            for (int i = 0; i < przedmioty.Count; i++)
            {
                if (przedmioty[i].Wyposazony == false) continue;
                aktywne.Add(przedmioty[i]);
            }

            return aktywne;
        }

        Statystyki ObliczBonusyPrzedmiotow()
        {
            Statystyki suma = new Statystyki();
            List<Przedmiot> aktywnePrzedmioty = AktywnePrzedmioty();

            foreach (Przedmiot przedmiot in aktywnePrzedmioty)
            {
                suma += przedmiot.Statystyki;
            }
        }
    }
}
