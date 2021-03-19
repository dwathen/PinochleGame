using System;
using System.Collections.Generic;

namespace PinochleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.InitializeGame();

            while (Game.IsPlaying)
            {
                Game.BidRound();
            }
        }
    }
}
