using System;

namespace tictactoe
{
    internal class Game
    {
        public Player p1;
        public Player p2;

        public Board board = new Board();

        private bool gameover = false;


        public Game()
        {
            string marker = "";
            string other = "";
            while (marker != "x" && marker != "o")
            {
                Console.WriteLine("Choose a marker for Player 1 ('x' or 'o')");
                marker = Console.ReadLine();
            }

            other = marker == "x" ? "o" : "x";

            p1 = new Player(marker);
            p2 = new Player(other);
            p1.turn = true;

            // Start game loop
            Run();
        }

        public void Run()
        {
            Player current;
            while (gameover == false)
            {
                current = p1.turn == true ? p1 : p2;
                Console.WriteLine($"It is {current._marker}'s turn");
                board.DisplayBoard();
                Console.WriteLine("Which space would you like to play in(numbers 1 - 9 on the numberpad represent the grid)");
                int markLocation = Convert.ToInt32(Console.ReadLine());

                if (board.Hit(current._marker, markLocation))
                {
                    if (board.CheckForWin(current._marker))
                    {
                        gameover = true;
                        board.DisplayBoard();
                        Console.WriteLine($"{current._marker} won the game!");
                        break;
                    }
                    if (p1.turn)
                    {
                        p1.turn = false;
                        p2.turn = true;
                    }
                    else
                    {
                        p2.turn = false;
                        p1.turn = true;
                    }
                }
                else
                {
                    Console.WriteLine("Space already occupied. Please try again.");
                }
            }

        }
    }
}
