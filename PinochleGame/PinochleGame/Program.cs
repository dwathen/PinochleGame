using System;
using System.Collections.Generic;

namespace PinochleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.InitializeGame();

            foreach (Player player in Game.Players)
                Game.PrintHand(player);

            while (Game.IsPlaying)
            {
                Game.BidRound();
            }
        }
    }
}
