using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C_SHARP
{
    class Gracz : Postac, IMenu
    {
        Ekwipunek ekwipunek = new Ekwipunek();

        public Gracz(string nazwa, Statystyki Statystyki, Ekwipunek ekwipunek) : base(nazwa, Statystyki)
        {
            this.Statystyki = Statystyki;
            this.ekwipunek = ekwipunek;
        }

        void zwieksz_poziom(int sila, int zrecznosc, int zycie)
        {
           // zmien_kolor_txt(ZIELONY);
            Console.WriteLine( "********************************************" );
            Console.WriteLine( "NOWY POZIOM!" );
            Console.WriteLine( "sila  +" + sila + "   zrecznosc  +" + zrecznosc + "   zycie  +" + zycie );
            Console.WriteLine( "********************************************" );
            // zmien_kolor_txt(ZOLTY);

            Statystyki.Zrecznosc += zrecznosc;
            Statystyki.Sila += sila;
            Statystyki.Zycie += zycie;
            Statystyki.Poziom++;
        }

        public override int Atak()
        {
            return Statystyki.Sila + ModyfikatorObrazen() + ekwipunek.ObliczBonusyPrzedmiotow().Sila;
        }

        public void OtrzymujePrzedmiot(Przedmiot przedmiot) { }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("1) Statystyki gracza");
            Console.WriteLine("2) Przegladaj ekwipunek");
            Console.WriteLine("3) Powrot");

            int wybor = InputHandler.WybierzOpcje(3, 1);

            Console.Clear();
            switch (wybor)
            {

                case 1:
                    {
                        Informacje();
                        InputHandler.NacisnijKlawisz();
                        break;
                    }
                case 2:
                    {
                        ekwipunek.Menu();
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
