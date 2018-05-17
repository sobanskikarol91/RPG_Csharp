﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C_SHARP
{
    class Gra : IMenu, IPlik
    {
        Gracz gracz;
        // spis wszystkich lokalizacji w grze
        List<Lokalizacja> lokalizacje = new List<Lokalizacja>();

        public enum STAN { WYGRANA, UCIECZKA, PORAZKA };

        void StworzGracza()
        {
            Console.WriteLine("Stworz nowa postac");
            Console.WriteLine("Imie Twojego bohatera brzmi: ");
            string nazwa = Console.ReadLine();

            Ekwipunek ekwipunek = new Ekwipunek();

            // dodajemy do ekwipunku miecz z odpowiednimy statysykami
            ekwipunek.przedmioty.Add(new Przedmiot("Miecz", new new Statystyki(0, 1, 0, 0, 0)));

            // wywolujemy konstruktor gracza podajac odpowiednie parametry
            gracz = new Gracz(nazwa, new new Statystyki(25, 3, 3, 1, 1), ekwipunek);
            Console.Clear();  // czyscimy ekran

            Console.WriteLine("Postac stworzona! Witaj " + gracz.Nazwa + "!");
        }

        void StworzLokalizacje()
        {
            lokalizacje.Add(new Lokalizacja("Krypta",
        "Na samym srodku sciezki, dostrzegasz schody prowadzace w dol. Wyczuwasz potezna, mroczna, aure bijaca z czelusci tej sciezki. Krzewy i drzewa zdaja sie byc obumarle, a w zasiegu wzroku gesto scieli sie truchlo martwych zwierzat i rozsypane kosci",
        Szkielet("Szkielet", new Statystyki(10, 4, 3, 0, 5)),
        new Przedmiot("Helm", new Statystyki(0, 0, 0, 1, 0))));

            lokalizacje.Add(new Lokalizacja("Las",
                "Patrzac na polnocny zachod, dostrzegasz gesty las. Drzewa sa poranione i ociekajace zywica. Masz wrazenie jakby ktos niedawno ostrzyl sobie na nich pazury.",
               new Wilk("Wilk", new Statystyki(10, 3, 6, 0, 1)),
                new Przedmiot("Topor", new Statystyki(0, 0, 1, 0, 0))));

            lokalizacje.Add(new Lokalizacja("Trakt",
                "Spogladajac na polnocny wschod widzisz martwego czlowieka, ktory lezy we wlasnej krwi, praktycznie bez odzienia. Na trawie dostrzegasz slady walki oraz rozerwany, mieszek zlota. ",
               new Bandyta("Bandyta", new Statystyki(10, 5, 5, 1, 1)),
                new Przedmiot("Zbroja", new Statystyki(0, 0, 0, 2, 0))));

            lokalizacje.Add(new Lokalizacja("Pobojowisko",
                "Na Zachodzie dostrzegasz wydeptane na drodze glebokie slady po ludzkich butach. Jednego jestes pewien, ktos bardzo obladowany musial udac sie ta droga.",
              new Zbrojny("Zbrojny", new Statystyki(10, 6, 2, 2, 1)),
              new Przedmiot("Naszyjnik", new Statystyki(0, 2, 2, 0, 0))));

            lokalizacje.Add(new Lokalizacja("Zamek",
                "Daleko na polnocy dostrzegasz ogromne ruiny, ktore kiedys musialy byc czescia zamku. Choc piekno i potega tego budynku dawno miely, masz wrazenie, ze to miejsce nie jest do konca opustoszale.",
              new Wladca("Wladca", new Statystyki(10, 8, 5, 3, 6)),
              new Przedmiot("Kamien-teleportacyjny", new Statystyki(0, 0, 0, 0, 0))));
        }
        void WybierzDroge() { }
        void WybierzDzialanieWyniku(STAN wynik, int wybor) { }

        void SprawdzWarunkiUkonczeniaGry() { }
        public void Menu()
        {
            throw new NotImplementedException();
        }

        public void RozpocznijGre() { }
        void Wyjscie()
        {

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