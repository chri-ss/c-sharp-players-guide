using System;

namespace Fountain
{
    internal class Game
    {
        public Map map;
        public Tile current { get; private set; }

        private bool fountainActive = false;
        private bool win;
        private bool lose;

        public void Move(string direction)
        {
            switch (direction)
            {
                case "n":
                    // move north
                    if (current.X > 0 && current.X <= map.TileMap.GetLength(0) - 1)
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
                    if (current.Y >= 0 && current.Y < map.TileMap.GetLength(1) - 1)
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
                    if (current.X >= 0 && current.X < map.TileMap.GetLength(1) - 1)
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
                    if (current.Y > 0 && current.Y <= map.TileMap.GetLength(0) - 1)
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
                        map = new Map(4);
                        break;
                    case "m":
                        map = new Map(6);
                        break;
                    case "l":
                        map = new Map(8);
                        break;
                    default:
                        Console.WriteLine("Not a valid map size. Try again.");
                        break;
                }
            }

            //map.DisplayMap();
            current = map.TileMap[0, 0];

            win = false;
            lose = false;
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
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("You see light coming from the cavern entrance.");
                    }
                }
                if (current.fountain)
                {
                    if (fountainActive)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("You hear dripping in this room. The fountain of objects is here!");
                    }
                }
                if (current.pitAdjacent)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("You feel a draft. There is a pit in a nearby room");
                }
                if (current.pit)
                {
                    lose = true;
                }

                Console.ForegroundColor = ConsoleColor.White;

                if (win || lose)
                {
                    string response = "";

                    while (response != null)
                    {
                        // if you are more than one game deep
                        if (response == "y")
                        {
                            break;
                        }
                        if (win)
                        {
                            Console.WriteLine("The fountain of objects has been reactivated, and you have escaped with your life!");
                        }
                        else if (lose)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You fall down a pit. Game over!");
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Play again? (y/n)");
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
    }
}
