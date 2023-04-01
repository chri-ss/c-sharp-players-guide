using System;

namespace tictactoe
{
    internal class Player
    {
        private string _marker = "";

        public Player(string marker)
        {
            _marker = marker;
        }

        public void Mark()
        {
            Console.WriteLine(_marker);
        }
    }
}
