﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesamientoBasico
{
    class Cordenada
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public Cordenada(int x, int y)
        {
            PosX = x;
            PosY = y;
        }

        public override string ToString()
        {
            return " x: " + PosX + " y: " + PosY;
        }
    }
}
