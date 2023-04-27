using System;

namespace Fountain
{
    internal class Map
    {
        public int Max { get; set; }

        public Tile[,] TileMap { get; set; }

        private int numPits;

        public Map(int max)
        {

            Max = max;
            TileMap = new Tile[Max, Max];

            if (max == 4)
            {
                numPits = 1;
            }
            else if (max == 6)
            {
                numPits = 2;
            }
            else if (max == 8)
            {
                numPits = 4;
            }
            else
            {
                numPits = 0;
            }

            (int, int) randomFountain = GetRandomTile();

            (int, int)[] randomPits = new (int, int)[numPits];

            for (int i = 0; i < numPits; i++)
            {
                randomPits[i] = GetRandomTile();
            }

            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < max; j++)
                {
                    TileMap[i, j] = new Tile(i, j);
                    if (i == randomFountain.Item1 && j == randomFountain.Item2)
                    {
                        TileMap[i, j].fountain = true;
                        Console.WriteLine($"f: {i}, {j}");
                    }

                    for (int k = 0; k < randomPits.Length; k++)
                    {
                        if (i == randomPits[k].Item1 && j == randomPits[k].Item2)
                        {
                            TileMap[i, j].pit = true;
                            Console.WriteLine($"p: {i}, {j}");
                        }
                    }
                }
            }

            for (int i = 0; i < randomPits.Length; i++)
            {
                checkForPitAdjacent(randomPits[i].Item1, randomPits[i].Item2);
            }
        }

        public void DisplayMap()
        {
            string row = "";

            for (int i = 0; i < TileMap.GetLength(0); i++)
            {
                for (int j = 0; j < TileMap.GetLength(1); j++)
                {
                    row += $"({TileMap[i, j].X}, {TileMap[i, j].Y}) |";
                }
                Console.WriteLine(row + "\n");
                row = "";
            }
        }

        private void checkForPitAdjacent(int x, int y)
        {
            for (int i = 0; i < TileMap.GetLength(0); i++)
            {
                for (int j = 0; j < TileMap.GetLength(1); j++)
                {
                    if (i >= x - 1 && i <= x + 1 && j >= y - 1 && j <= y + 1)
                    {
                        if (TileMap[i, j] != TileMap[x, y])
                        {
                            TileMap[i, j].pitAdjacent = true;
                            Console.WriteLine($"{i}, {j}");
                        }
                    }
                }
            }
        }

        private (int, int) GetRandomTile()
        {
            Random rnd = new Random();
            int x = rnd.Next(0, TileMap.GetLength(0));
            int y = rnd.Next(0, TileMap.GetLength(1));

            return (x, y);
        }
    }
}
