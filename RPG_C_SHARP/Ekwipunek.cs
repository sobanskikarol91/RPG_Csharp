using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C_SHARP
{
    [Serializable]
    class Ekwipunek : IMenu
    {
        public Ekwipunek()
        {
            przedmioty = new List<Przedmiot>();
        }

        public List<Przedmiot> przedmioty { get; set; }

        void Przegladaj()
        {
            Console.Clear();
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
                    Console.WriteLine("============ ");
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

       public Statystyki ObliczBonusyPrzedmiotow()
        {
            Statystyki suma = new Statystyki();
            List<Przedmiot> aktywnePrzedmioty = AktywnePrzedmioty();

            foreach (Przedmiot przedmiot in aktywnePrzedmioty)
                suma += przedmiot.Statystyki;

            return suma;
        }

        public void Menu()
        {
            Przegladaj();

            Console.WriteLine(przedmioty.Count + ") Exit");
            Console.WriteLine("Wybierz numer przedmiotu");

            int wyborPrzedmiotu = InputHandler.WybierzOpcje(przedmioty.Count);

            if (wyborPrzedmiotu == przedmioty.Count) return;
            else
            {
                Console.Clear();
                Console.WriteLine("Co chcesz zrobic?");
                Console.WriteLine("1) Zaloz przedmiot");
                Console.WriteLine("2) Zdejmij przedmiot");
                Console.WriteLine("3 Zamknij Ekwipunek");

                switch (InputHandler.WybierzOpcje(3))
                {
                    case 1:
                        {
                            przedmioty[wyborPrzedmiotu].Wyposazony = true;
                            Console.WriteLine("Przedmiot zalozony!");
                            break;
                        }
                    case 2:
                        {
                            przedmioty[wyborPrzedmiotu].Wyposazony = false;
                            Console.WriteLine("Przedmiot zdjety!");
                            break;
                        }
                    default:
                        return;
                }
            }
            InputHandler.NacisnijKlawisz();
            Menu();
        }
    }
}
