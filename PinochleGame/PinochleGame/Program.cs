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
                foreach (Player player in Game.Players)
                    player.PrintHand();

                Game.BidRound();

                Game.ChooseTrump();

                Game.PassRound();

                Game.CalculateMeld();

                Game.UpdateController(Game.BidWinner);

                Game.PlayTricks();

                Team bidTeam = Game.GetTeamWithPlayer(Game.BidWinner);
                Team otherTeam = Game.GetOtherTeamWithPlayer(Game.BidWinner);

                if (bidTeam.RoundPoints < Game.Bid)
                {
                    bidTeam.GamePoints -= Game.Bid;
                }
                else
                {
                    bidTeam.GamePoints += bidTeam.RoundPoints;
                }

                otherTeam.GamePoints += otherTeam.RoundPoints;

                if (bidTeam.GamePoints >= 150)
                    Game.IsPlaying = false;
                else if (otherTeam.GamePoints >= 150)
                    Game.IsPlaying = false;
                else
                    Game.StartNewRound();
            }
        }
    }
}
