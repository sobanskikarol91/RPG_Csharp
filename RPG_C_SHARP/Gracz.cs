using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C_SHARP
{
    class Gracz : Postac
    {
        Ekwipunek ekwipunek = new Ekwipunek();
        Gracz(string nazwa, Statystyki statystyki, Ekwipunek ekwipunek) : base(nazwa, statystyki)
        {
            this.statystyki = statystyki;
            this.ekwipunek = ekwipunek;
        }

        protected override int Atak()
        {
            return 1;
        }

      public void menu()
        {
            Console.WriteLine("1) Statystyki gracza");
            Console.WriteLine("2) Przegladaj ekwipunek");
            Console.WriteLine("3) Powrot");

            int wybor = InputHandler.WybierzOpcje(3, 1);

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
                        ekwipunek.menu();
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
