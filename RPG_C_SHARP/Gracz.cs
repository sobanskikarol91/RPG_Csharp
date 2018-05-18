using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C_SHARP
{
    [Serializable]
    class Gracz : Postac, IMenu
    {
        Ekwipunek ekwipunek = new Ekwipunek();

        public Gracz(string nazwa, Statystyki Statystyki, Ekwipunek ekwipunek) : base(nazwa, Statystyki)
        {
            this.Statystyki = Statystyki;
            this.ekwipunek = ekwipunek;
        }

     public   void ZwiekszPoziom(int sila = 1, int zrecznosc = 1, int zycie = 10)
        {
            Console.Clear();
            Console.WriteLine( "********************************************" );
            Console.WriteLine( "NOWY POZIOM!" );
            Console.WriteLine( "sila  +" + sila + "   zrecznosc  +" + zrecznosc + "   zycie  +" + zycie );
            Console.WriteLine( "********************************************" );

            InputHandler.NacisnijKlawisz();

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
