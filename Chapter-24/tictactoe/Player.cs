using System;

namespace tictactoe
{
    internal class Player
    {
        public string _marker = "";
        public bool turn = false;

        public Player(string marker)
        {
            _marker = marker;
        }
    }
}
