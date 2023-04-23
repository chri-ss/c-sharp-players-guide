using System;
using System.Drawing;

namespace Fountain
{
    internal class Game
    {
        public Map map;
        public Tile current { get; private set; }

        private bool fountainActive = false;
        private bool win;

        public void Move(string direction)
        {
            switch (direction)
            {
                case "n":
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

                case "e":
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

                case "s":
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

                case "w":
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

                case "x":
                    if (current.fountain)
                    {
                        fountainActive = true;
                        Console.WriteLine("You've activated the fountain of objects!");
                    }
                    else
                    {
                        Console.WriteLine("There is no fountain in this room.");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid direction");
                    break;
            }
        }

        public void Run()
        {
            // Choose map size
            string size = "";
            while (size != "s" && size != "m" && size != "l")
            {
                Console.WriteLine("Enter a size for the map (s: 4x4, m: 6x6, l: 8x8)");
                size = Console.ReadLine();

                switch (size)
                {
                    case "s":
                        map = new Map(4, 4);
                        break;
                    case "m":
                        map = new Map(6, 6);
                        break;
                    case "l":
                        map = new Map(8, 8);
                        break;
                    default:
                        Console.WriteLine("Not a valid map size. Try again.");
                        break;
                }
            }

            map.DisplayMap();
            current = map.TileMap[0, 0];
            (int, int) fountainCoords = GetRandomTile(map);
            map.TileMap[fountainCoords.Item1, fountainCoords.Item2].fountain = true;

            win = false;
            fountainActive = false;
            while (true)
            {
                if (current.X == 0 && current.Y == 0)
                {
                    if (fountainActive)
                    {
                        win = true;
                    }
                    else
                    {
                        Console.WriteLine("You see light coming from the cavern entrance.");
                    }
                }
                if (current.fountain)
                {
                    if (fountainActive)
                    {
                        Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
                    }
                    else
                    {
                        Console.WriteLine("You hear dripping in this room. The fountain of objects is here!");
                    }
                }

                if (win)
                {
                    string response = "";

                    while (response != null)
                    {
                        // if you are more than one game deep
                        if (response == "y")
                        {
                            break;
                        }

                        Console.WriteLine("The fountain of objects has been reactivated, and you have escaped with your life!");
                        Console.WriteLine("PLay again? (y/n)");
                        response = Console.ReadLine();
                        if (response == "y")
                        {
                            Run();
                        }
                        else if (response == "n")
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    break;
                }

                Console.WriteLine($"You are in the room at (Row={current.X} Column={current.Y})\n" +
                        $"Enter a cardinal direction ('n', 's', 'e', or 'w') to move or 'x' to enable the fountain, if present.");

                string direction = Console.ReadLine();

                Move(direction);
                Console.WriteLine($"({current.X}, {current.Y})");
            }
        }

        public (int, int) GetRandomTile(Map map)
        {
            Random rnd = new Random();
            int x = rnd.Next(0, map.TileMap.GetLength(0));
            int y = rnd.Next(0, map.TileMap.GetLength(1));

            return (x, y);
        }
    }
}
