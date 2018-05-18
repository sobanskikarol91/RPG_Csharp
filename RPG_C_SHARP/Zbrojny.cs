using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C_SHARP
{
    [Serializable]
    class Zbrojny : Przeciwnik
    {
       public Zbrojny(string nazwa, Statystyki statystyki) : base(nazwa, statystyki) { }
    }
}
