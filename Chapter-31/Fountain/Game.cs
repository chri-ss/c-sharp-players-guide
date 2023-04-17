using System;

namespace Fountain
{
    internal class Game
    {
        public Map map;
        public Tile current { get; private set; }

        private bool fountainActive = false;

        public Game()
        {
            map = new Map(4, 4);
            current = map.TileMap[0, 0];
            map.TileMap[0, 2].fountain = true;
        }

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
            while (true)
            {
                if (current.X == 0 && current.Y == 0)
                {
                    Console.WriteLine("You see light coming from the cavern entrance.");
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

                Console.WriteLine($"You are in the room at (Row={current.X} Column={current.Y})\n" +
                    $"Enter a cardinal direction ('n', 's', 'e', or 'w') to move or 'x' to enable the fountain, if present.");

                string direction = Console.ReadLine();

                Move(direction);
                Console.WriteLine($"({current.X}, {current.Y})");
            }
        }
    }
}
