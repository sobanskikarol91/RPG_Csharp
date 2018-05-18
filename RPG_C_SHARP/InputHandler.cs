using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C_SHARP
{
    class InputHandler
    {
        public static int WybierzOpcje(int max, int min = 0)
        {
            int wybor = 0;
            while (true)
            {
                wybor = Console.ReadKey().KeyChar - 48;

                if (wybor >= min && wybor <= max)
                    break;
                else
                {
                    Console.WriteLine(" Blednie wprowadzone dane");
                    NacisnijKlawisz();
                }
            }
            return wybor;
        }

        public static void NacisnijKlawisz()
        {
            Console.WriteLine("Nacisnij klawisz aby przejsc dalej...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
