﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C_SHARP
{
    class Kostka
    {
        private int min, max;
        Kostka(int min, int max) { this.min = min; this.max = max; }
        int Losuj()
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}