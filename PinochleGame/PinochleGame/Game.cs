using System;
using System.Collections.Generic;
using System.Text;

namespace PinochleGame
{
    public static class Game
    {
        public static List<Player> Players { get; set; }
        public static List<Team> Teams { get; set; }
        public static List<string> PlayPile { get; set; }
        public static Stack<string> Cards { get; set; }
        public static Player Dealer { get; set; }
        public static string Trump { get; set; }
        public static bool IsPlaying { get; set; }
        public static int Bid { get; set; }

        public static void InitializeGame()
        {
            Cards = Deck.InitializeDeck();
            Players = new List<Player>();
            Teams = new List<Team>();

            Teams.Add(new Team());
            Teams.Add(new Team());

            List<List<string>> playerCards = new List<List<string>>();
            playerCards.Add(new List<string>());
            playerCards.Add(new List<string>());
            playerCards.Add(new List<string>());
            playerCards.Add(new List<string>());

            for (int i = 0; i < 12; i++)
            {
                playerCards[0].Add(Cards.Pop());
                playerCards[1].Add(Cards.Pop());
                playerCards[2].Add(Cards.Pop());
                playerCards[3].Add(Cards.Pop());
            }

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Please name player number " + (i + 1));

                Players.Add(new Player(Console.ReadLine(), Deck.CreateHandForPlayer(playerCards[i])));

                if (i % 2 == 0)
                    Teams[0].AddPlayer(Players[i]);
                else
                    Teams[1].AddPlayer(Players[i]);
            }

            IsPlaying = true;
            Bid = 0;
            Dealer = Players[0];
        }

        public static void BidRound()
        {
            bool isBidding = true;
            bool[] playerPassed = new bool[] { false, false, false, false };
            int playerIndex = Players.IndexOf(Dealer);
            int nextPlayerIndex;
            string currentPlayer;
            string openMessage = "Would you like to open the bid at 25 (y/n)?";
            string bidMessage = "Would you like to bid higher than " + Bid + " (y/n)?";

            while (isBidding)
            {
                currentPlayer = Players[playerIndex].FirstName;

                if (Bid == 0)
                    Console.WriteLine("It is " + currentPlayer + "'s turn. " + openMessage);
                else
                    Console.WriteLine("It is " + currentPlayer + "'s turn. " + bidMessage);

                Console.WriteLine();

                if (Console.ReadLine().ToUpper() == "Y")
                {
                    if (Bid == 0)
                        Bid = 25;
                    else
                    {
                        Console.WriteLine("What would you like to bid? (Must be higher than " + Bid + ")");
                        Bid = int.Parse(Console.ReadLine());
                        bidMessage = "Would you like to bid higher than " + Bid + " (y/n)?";
                    }
                }
                else
                {
                    Console.WriteLine(currentPlayer + " has passed.");
                    playerPassed[playerIndex] = true;
                }

                nextPlayerIndex = GetNextValidPlayerIndex(playerPassed, playerIndex);

                if (nextPlayerIndex == -1)
                {
                    isBidding = false;
                }
                else
                    playerIndex = nextPlayerIndex;

                if (LastPlayer(playerPassed) && Bid != 0)
                    isBidding = false;
            }
        }

        public static int GetNextValidPlayerIndex(bool[] playerPassed, int playerIndex)
        {
            bool isInvalid = true;
            int startingIndex = playerIndex;

            while (isInvalid)
            {
                if (playerIndex == 3)
                    playerIndex = 0;
                else
                    playerIndex++;

                if (playerIndex == startingIndex)
                    return -1;

                if (playerPassed[playerIndex] == false)
                    isInvalid = false;
            }

            return playerIndex;
        }

        public static bool LastPlayer(bool[] playerPassed)
        {
            int numberOfPlayersPassed = 0;

            foreach (bool playerPass in playerPassed)
            {
                if (playerPass)
                    numberOfPlayersPassed++;
            }

            if (numberOfPlayersPassed == 3)
                return true;
            else
                return false;
        }

        public static void PrintHand(Player player)
        {
            Console.WriteLine(player.FirstName + "'s hand");

            foreach (KeyValuePair<string, List<string>> suit in player.Hand)
            {
                Console.WriteLine(suit.Key);

                foreach (string card in suit.Value)
                {
                    Console.WriteLine(card);
                }

                Console.WriteLine();
            }
        }
    }
}
