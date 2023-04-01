using System;

namespace tictactoe
{
    internal class Game
    {
        public Player p1;
        public Player p2;

        public Board board = new Board();

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
            p1.Mark();
            p2.Mark();
            board.DisplayBoard();
        }
    }
}
