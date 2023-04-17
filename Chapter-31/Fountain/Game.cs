using System;

namespace Fountain
{
    internal class Game
    {
        public Map map;
        public Tile current { get; private set; }

        public Game()
        {
            map = new Map(4, 4);
            current = map.TileMap[0, 0];
        }

        public void Move(int direction)
        {
            switch (direction)
            {
                case 0:
                    // move north
                    if (current.X > 0 && current.X <= 3)
                    {
                        current = map.TileMap[current.X - 1, current.Y];
                    }
                    else
                    {
                        Console.WriteLine("Invalid movement");
                    }
                    break;

                case 1:
                    // move right
                    if (current.Y >= 0 && current.Y < 3)
                    {
                        current = map.TileMap[current.X, current.Y + 1];
                    }
                    else
                    {
                        Console.WriteLine("Invalid movement");
                    }
                    break;

                case 2:
                    // move south
                    if (current.X >= 0 && current.X < 3)
                    {
                        current = map.TileMap[current.X + 1, current.Y];
                    }
                    else
                    {
                        Console.WriteLine("Invalid movement");
                    }
                    break;

                case 3:
                    // move left
                    if (current.Y > 0 && current.Y <= 3)
                    {
                        current = map.TileMap[current.X, current.Y - 1];
                    }
                    else
                    {
                        Console.WriteLine("Invalid movement");
                    }
                    break;
            }
        }
    }
}
