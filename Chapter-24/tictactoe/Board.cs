using System;

namespace tictactoe
{
    internal class Board
    {
        private string[,] board = new string[3, 3] { { " ", " ", " " }, { " ", " ", " " }, { " ", " ", " " } };

        public void DisplayBoard()
        {
            string line;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                line = "";
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (j != board.GetLength(1) - 1)
                    {
                        line += $" {board[i, j]} |";
                    }
                    else
                    {
                        line += $"{board[i, j]}";
                    }

                }
                Console.WriteLine(line);
                if (i != board.GetLength(0) - 1)
                {
                    Console.WriteLine("---+---+---");
                }
            }
        }
    }
}
