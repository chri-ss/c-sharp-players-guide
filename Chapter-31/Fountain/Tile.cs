﻿using System;

namespace Fountain
{
    internal class Tile
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public bool fountain = false;
        public bool pit = false;
        public bool pitAdjacent = false;

        public Tile(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
