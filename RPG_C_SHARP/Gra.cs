using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace RPG_C_SHARP
{
    public enum STAN { WYGRANA, UCIECZKA, PORAZKA };


    class Gra : IMenu
    {
        Gracz gracz;
        // spis wszystkich lokalizacji w grze
        List<Lokalizacja> lokalizacje = new List<Lokalizacja>();

        void StworzGracza()
        {
            Console.Clear();
            Console.WriteLine("Stworz nowa postac");
            Console.Write("Imie Twojego bohatera brzmi: ");

            string nazwa = Console.ReadLine();

            Ekwipunek ekwipunek = new Ekwipunek();

            // dodajemy do ekwipunku miecz z odpowiednimy statysykami
            ekwipunek.przedmioty.Add(new Przedmiot("Miecz", new Statystyki(0, 1, 0, 0, 0)));

            // wywolujemy konstruktor gracza podajac odpowiednie parametry
            gracz = new Gracz(nazwa, new Statystyki(25, 3, 3, 1, 1), ekwipunek);
            Console.Clear();  // czyscimy ekran

            Console.WriteLine("Postac stworzona! Witaj " + gracz.Nazwa + "!");
            InputHandler.NacisnijKlawisz();

        }

        void StworzLokalizacje()
        {
            lokalizacje.Add(new Lokalizacja("Krypta",
        "Na samym srodku sciezki, dostrzegasz schody prowadzace w dol. Wyczuwasz potezna, mroczna, aure bijaca z czelusci tej sciezki. Krzewy i drzewa zdaja sie byc obumarle, a w zasiegu wzroku gesto scieli sie truchlo martwych zwierzat i rozsypane kosci",
        new Szkielet("Szkielet", new Statystyki(10, 4, 3, 0, 5)),
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

        void WybierzDroge()
        {
            for (int i = 0; i < lokalizacje.Count; i++)
            {
                Console.Write(i + ") ");
                lokalizacje[i].Informacja();
                Console.WriteLine();
            }

            Console.WriteLine("Dotarles do rozwidlenia " + lokalizacje.Count + " sciezek, gdzie tym razem poprowadzi Cie przeznaczenie? ");

            // wykorzystujemy dolaczona funkcje, posylamy maxymalna ilosc lokalizacji do wyboru, funkcja zwraca wybor gracza
            int wybor = InputHandler.WybierzOpcje(lokalizacje.Count - 1);
            Console.Clear();

            STAN wynik = lokalizacje[wybor].WejdzDoLokalizacji(gracz);
            WybierzDzialanieWyniku(wynik, wybor);
        }

        void WybierzDzialanieWyniku(STAN wynik, int wybor)
        {
            switch (wynik)
            {
                case STAN.WYGRANA:
                    {
                        Console.WriteLine("(Wygrana) Zabijalem juz za mniej!");

                        InputHandler.NacisnijKlawisz();
                        // zdobylismy ta lokalizacje juz, wiec usuwamy ja z listy aby wiecej nie pokazywala nam sie
                        // przy wyborze sciezki
                        lokalizacje.RemoveAt(wybor);

                        // zwiekszamy poziom gracza po wygranej walce
                        gracz.ZwiekszPoziom();
                        ZapiszDane(); // automatyczny zapis
                        SprawdzWarunkiUkonczeniaGry();
                        break;
                    }
                case STAN.UCIECZKA:
                    {
                        Console.WriteLine("Udalo Ci sie bezpiecznie zawrocic");
                        InputHandler.NacisnijKlawisz();
                        break;
                    }
                case STAN.PORAZKA:
                    Console.WriteLine("(Przegrana) Mniam mniam, powiedzial potwor jedzacy Twoje zwloki");
                    Wyjscie();
                    break;
                default:
                    break;
            }
            Menu();
        }

        void SprawdzWarunkiUkonczeniaGry()
        {
            if (lokalizacje.Count == 0)
            {
                Console.WriteLine("Doszedles do konca swojej podrozy udalo Ci sie pokonac wszystkich przeciwnikow oraz wladce wyspy!");
                Wyjscie();// wyjscie z apki
            }
        }
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("1) Panel bohatera");
            Console.WriteLine("2) Udaj sie w droge");
            Console.WriteLine("3) Wyjdz z gry");

            int wybor = InputHandler.WybierzOpcje(3, 1);
            Console.Clear();
            switch (wybor)
            {
                case 1:
                    gracz.Menu();
                    break;
                case 2:
                    WybierzDroge();
                    break;
                default:
                    Wyjscie(); // definytywnie wychodzimy z gry
                    break;
            }

            Menu(); // zawsze wracamy do menu glownego, no chyba ze wybierzemy wyjscie z gry
        }

        public void RozpocznijGre()
        {
            //  zmien_kolor_txt(ZOLTY); // kolorujemy tekst od tej pory na zolto
            Console.WriteLine("1) Stworz nowa postac");
            Console.WriteLine("2) Wczytaj gre");
            Console.WriteLine("3) Wyjscie z gry");

            int wybor = InputHandler.WybierzOpcje(3, 1);

            switch (wybor)
            {
                case 1:
                    StworzGracza();
                    StworzLokalizacje();
                    ZapiszDane();
                    break;
                case 2:
                    WczytajDane();
                    break;
                default:
                    Wyjscie();
                    break;
            }
            Menu();
        }

        void Wyjscie()
        {
            ZapiszDane();
            InputHandler.NacisnijKlawisz();
            Environment.Exit(0);
        }

        public void WczytajDane()
        {
            //  otwarcie strumienia 
            FileStream strumienDanych = new FileStream("C:\\Zapisy_RPG\\gra.txt", FileMode.Open);

            // deserializacja 
            BinaryFormatter formatter = new BinaryFormatter();
            gracz = (Gracz)formatter.Deserialize(strumienDanych);
            lokalizacje = (List<Lokalizacja>)formatter.Deserialize(strumienDanych);
            strumienDanych.Close();

            Console.Clear();
            Console.WriteLine("Wczytano poprawnie dane!");
            InputHandler.NacisnijKlawisz();
        }

        public void ZapiszDane()
        {
            // tworzymy folder
            if (!Directory.Exists("C:\\Zapisy_RPG"))
                Directory.CreateDirectory("C:\\Zapisy_RPG");

            FileStream strumienDanych;

            // utworzenie pliku, który będzie zawierał strumienie danych
            strumienDanych = new FileStream("C:\\Zapisy_RPG\\gra.txt",
                FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();
            // próba serializacji
            formatter.Serialize(strumienDanych, gracz);
            formatter.Serialize(strumienDanych, lokalizacje);
            // zamknięcie strumienia
            strumienDanych.Close();

            Console.WriteLine("Zapisano poprawnie dane!");
            InputHandler.NacisnijKlawisz();
        }
    }
}
