using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C_SHARP
{
    abstract class Przeciwnik : Postac
    {
       public Przeciwnik(string nazwa, Statystyki statystyki) : base(nazwa, statystyki) { }

        public override int Atak()
        {
            throw new NotImplementedException();
        }
    }
}
