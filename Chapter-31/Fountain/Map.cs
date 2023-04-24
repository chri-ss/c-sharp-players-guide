using System;

namespace Fountain
{
    internal class Map
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public Tile[,] TileMap { get; set; }

        public Map(int min, int max)
        {
            Min = min;
            Max = max;
            TileMap = new Tile[Min, Max];

            (int, int) rnd = GetRandomTile();

            for (int i = 0; i < TileMap.GetLength(0); i++)
            {
                for (int j = 0; j < TileMap.GetLength(1); j++)
                {
                    TileMap[i, j] = new Tile(i, j);
                    if(i == rnd.Item1 && j == rnd.Item2)
                    {
                        TileMap[i, j].fountain = true;
                    }
                }
            }
        }

        public void DisplayMap()
        {
            string row = "";

            for (int i = 0; i < TileMap.GetLength(0); i++)
            {
                for (int j = 0; j < TileMap.GetLength(1); j++)
                {
                    //Console.WriteLine(TileMap[i, j]);
                    row += $"({TileMap[i, j].X}, {TileMap[i, j].Y}) |";
                }
                Console.WriteLine(row + "\n");
                row = "";
            }
        }

        public (int, int) GetRandomTile()
        {
            Random rnd = new Random();
            int x = rnd.Next(0, TileMap.GetLength(0));
            int y = rnd.Next(0, TileMap.GetLength(1));

            return (x, y);
        }
    }
}
