﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C_SHARP
{
    class Program
    {
        static void Main(string[] args)
        {
            Statystyki s = new Statystyki(2,2,2,2,2);
            s.Informacja();

            Console.Read();
        }
    }
}
