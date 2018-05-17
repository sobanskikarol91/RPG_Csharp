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

        public Gracz(string nazwa, Statystyki statystyki, Ekwipunek ekwipunek) : base(nazwa, statystyki)
        {
            this.Statystyki = statystyki;
            this.ekwipunek = ekwipunek;
        }

        public override int Atak()
        {
            return 1;
        }

        public void OtrzymujePrzedmiot(Przedmiot przedmiot) { }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("1) Statystyki gracza");
            Console.WriteLine("2) Przegladaj ekwipunek");
            Console.WriteLine("3) Powrot");

            switch (InputHandler.WybierzOpcje(3, 1))
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
