using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C_SHARP
{
    [Serializable]
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

        public void Informacja()
        {
            Console.WriteLine(nazwa);
            Console.WriteLine("===============================");
            Console.WriteLine(opis);
        }

        public Przedmiot Przeszukanie()
        {
            Console.WriteLine("Przeszukujac lokalizacje natrafiasz na przedmiot jest to: " + przedmiot.Nazwa);

            return przedmiot;
        }

        public STAN WejdzDoLokalizacji(Gracz gracz)
        {
            int wybor;

            Console.WriteLine("Co chcesz zrobic?");
            Console.WriteLine("1) Przeszukaj lokalizacje");
            Console.WriteLine("2) Walcz ");
            Console.WriteLine("3) Zawroc ");

            wybor = InputHandler.WybierzOpcje(3, 1);
            Console.Clear();
            switch (wybor)
            {
                case 1:
                    {
                        Przedmiot znalezisko = Przeszukanie();
                        gracz.OtrzymujePrzedmiot(znalezisko);
                        Okno.StworzOkno(znalezisko.Nazwa); // tworzymy okno podajac nazwe obrazka, ktory ma byc wyswietlony
                        Console.WriteLine("Dodajesz przedmiot do ekwipunku.");
                        Console.WriteLine("Twoje odglosy, zbudzily straznika! ");
                        InputHandler.NacisnijKlawisz();
                        return MenuWyboruWalki(gracz);
                    }
                case 2:
                    return MenuWyboruWalki(gracz);
                default:
                    return STAN.UCIECZKA;
            }
        }

        STAN Walka(Gracz gracz)
        {
            Okno.StworzOkno(przeciwnik.Nazwa); // tworzymy okno podajac nazwe obrazka, ktory ma byc wyswietlony

            int zycie_potwora = przeciwnik.Statystyki.Zycie;
            int zycie_gracza = gracz.Statystyki.Zycie;

            // wykonuj dopoki jakis nie padnie
            while (zycie_potwora > 0 && zycie_gracza > 0)
            {
                int sila_potwory = przeciwnik.Atak();
                int sila_gracza = gracz.Atak();

                int obrona_potwora = przeciwnik.Statystyki.Obrona;
                int obrona_gracza = gracz.Statystyki.Obrona;

                int obrazenia_gracza = sila_gracza - obrona_potwora;
                int obrazenia_potwora = sila_potwory - obrona_gracza;

                Console.WriteLine("==============================================================");
                // zmien_kolor_txt(CZERWONY);
                Console.WriteLine("Sila potwora: " + sila_potwory);
                Console.WriteLine("Obrona potwora: " + obrona_potwora);
                Console.WriteLine("==============================================================");

                //zmien_kolor_txt(ZIELONY);
                Console.WriteLine("Sila " + gracz.Nazwa + " " + sila_gracza);
                Console.WriteLine("Obrona " + gracz.Nazwa + " " + obrona_gracza);
                //zmien_kolor_txt(ZOLTY);

                Console.WriteLine("==============================================================");
                // zmien_kolor_txt(SELEDYNOWY);

                zycie_potwora -= obrazenia_gracza;
                zycie_gracza -= obrazenia_gracza;

                Console.Write("Obrazenia: " + gracz.Nazwa + "  " + (sila_gracza - obrona_potwora) + " vs ");
                Console.WriteLine(obrazenia_potwora + "  Potwor");

                Console.Write("Zycie: " + gracz.Nazwa + "  " + zycie_gracza + " vs ");
                Console.WriteLine(zycie_potwora + "  Potwor");
                Console.WriteLine();
            }
            
            //zmien_kolor_txt(ZOLTY);

            if (zycie_potwora >= zycie_gracza)
                return STAN.PORAZKA;
            else
                return STAN.WYGRANA; // udalo sie wygrac wiec zwracamy taki stan
        }

        STAN MenuWyboruWalki(Gracz gracz)
        {
            Console.WriteLine("Na Twojej drodze staje: " + przeciwnik.Nazwa);
            Console.WriteLine("1) (Walka) Dobadz broni");
            Console.WriteLine("2) (Ucieczka) Wycofaj sie");

            int wybor = InputHandler.WybierzOpcje(2, 1);

            switch (wybor)
            {
                case 1:
                    {
                        Console.WriteLine("Postanowiles stanac do walki" );
                        return Walka(gracz); // zwracamy rezultat walki
                    }
                default:
                    {
                        if (ProbaUcieczki(gracz))
                            return STAN.UCIECZKA;
                        else
                        {
                            Console.WriteLine("Nie udalo Ci sie uciec, musisz stanac do walki " );
                            InputHandler.NacisnijKlawisz();
                            return Walka(gracz);  // zwracamy rezultat walki
                        }
                    }
            }
        }

        bool ProbaUcieczki(Gracz gracz)
        {
            int zrecznosc_potwora = przeciwnik.Statystyki.Zrecznosc;

            // gracz jest wskaznikiem wiec na obiekt klasy Gracz, wykorzystujemy '->' aby dostac sie do pola klasy
            int zrecznosc_gracza = gracz.Statystyki.Zrecznosc;
            Console.Clear();
            Console.WriteLine( "==============================================================" );
           // zmien_kolor_txt(CZERWONY);
            Console.WriteLine( "Zrecznosc potwora: " + zrecznosc_potwora );

            //zmien_kolor_txt(ZIELONY);
            Console.WriteLine( "Zrecznosc gracza:  " + zrecznosc_gracza );
           // zmien_kolor_txt(ZOLTY);
            Console.WriteLine( "==============================================================" );

            // gdy gracz ma wiecej zrecznosci zwracamy true
            return zrecznosc_gracza > zrecznosc_potwora;
        }
    }
}
