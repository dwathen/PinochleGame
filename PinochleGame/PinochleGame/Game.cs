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
        public static Player BidWinner { get; set; }
        public static Player Controller { get; set; }
        public static string Trump { get; set; }
        public static bool IsPlaying { get; set; }
        public static int Bid { get; set; }

        public static void InitializeGame()
        {
            Players = new List<Player>();
            Teams = new List<Team>();

            Teams.Add(new Team());
            Teams.Add(new Team());

            List<List<string>> playerCards = SetupCardsToDeal();

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

        public static void StartNewRound()
        {
            List<List<string>> playerCards = SetupCardsToDeal();

            for (int i = 0; i < 4; i++)
                Players[i].DealNewHand(Deck.CreateHandForPlayer(playerCards[i]));

            foreach (Team team in Teams)
                team.RoundPoints = 0;

            Bid = 0;
            GetNextDealer();
        }

        public static void GetNextDealer()
        {
            if (Players.IndexOf(Dealer) == 3)
                Dealer = Players[0];
            else
                Dealer = Players[Players.IndexOf(Dealer) + 1];
        }

        public static List<List<string>> SetupCardsToDeal()
        {
            Cards = Deck.InitializeDeck();

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

            return playerCards;
        }

        public static void BidRound()
        {
            bool isBidding = true;
            bool[] playerPassed = new bool[] { false, false, false, false };
            int playerIndex;
            int nextPlayerIndex;
            string currentPlayer;
            string openMessage = "Would you like to open the bid at 25 (y/n)?";
            string bidMessage = "Would you like to bid higher than 25 (y/n)?";

            if (Players.IndexOf(Dealer) == 3)
                playerIndex = 0;
            else
                playerIndex = Players.IndexOf(Dealer) + 1;

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
                    BidWinner = Players[playerIndex];
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
                {
                    isBidding = false;
                }
            }
        }

        public static void PassRound()
        {
            Team team = GetTeamWithPlayer(BidWinner);

            PassCardsToPartner(team.GetTeammate(BidWinner), BidWinner);

            PassCardsToPartner(BidWinner, team.GetTeammate(BidWinner));
        }

        public static Team GetTeamWithPlayer(Player player)
        {
            foreach (Team team in Teams)
            {
                if (team.HasPlayer(player))
                    return team;
            }

            return new Team();
        }

        public static Team GetOtherTeamWithPlayer(Player player)
        {
            foreach (Team team in Teams)
            {
                if (!team.HasPlayer(player))
                    return team;
            }

            return new Team();
        }

        public static void PassCardsToPartner(Player passingPlayer, Player receivingPlayer)
        {
            List<string> cardsPassed = ChooseCardsToPass(passingPlayer.Hand);

            receivingPlayer.AddCardsToHand(cardsPassed);
            passingPlayer.RemoveCardsFromHand(cardsPassed);
        }

        public static List<string> ChooseCardsToPass(Dictionary<string, List<string>> hand)
        {
            List<string> cardsToPass = new List<string>();

            for (int i = 0; i < 4; i++)
            {
                int j = 1;

                foreach (KeyValuePair<string, List<string>> suit in hand)
                {
                    Console.WriteLine(suit.Key);
                    foreach (string card in suit.Value)
                    {
                        Console.WriteLine(j + card);
                        j++;
                    }
                }

                cardsToPass.Add(GetCardFromIndex(hand, int.Parse(Console.ReadLine())));
            }

            return cardsToPass;
        }

        public static string ChooseCardToPlay(List<string> hand)
        {
            int j = 1;

            foreach (string card in hand)
            {
                Console.WriteLine(j + card);
                j++;
            }

            return hand[int.Parse(Console.ReadLine()) - 1];
        }

        public static string GetCardFromIndex(Dictionary<string, List<string>> hand, int index)
        {
            string cardToReturn = "";

            if (index <= hand["Hearts"].Count)
            {
                cardToReturn = "H" + hand["Hearts"][index - 1];
            }
            else if (index - hand["Hearts"].Count <= hand["Clubs"].Count)
            {
                index = index - hand["Hearts"].Count;
                cardToReturn = "C" + hand["Clubs"][index - 1];
            }
            else if (index - hand["Hearts"].Count - hand["Clubs"].Count <= hand["Diamonds"].Count)
            {
                index = index - (hand["Hearts"].Count + hand["Clubs"].Count);
                cardToReturn = "D" + hand["Diamonds"][index - 1];
            }
            else if (index - hand["Hearts"].Count - hand["Clubs"].Count - hand["Diamonds"].Count <= hand["Spades"].Count)
            {
                index = index - (hand["Hearts"].Count + hand["Clubs"].Count + hand["Diamonds"].Count);
                cardToReturn = "S" + hand["Spades"][index - 1];
            }

            return cardToReturn;
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

        public static void ChooseTrump()
        {
            Console.WriteLine(BidWinner.FirstName + " has won the bid. What do you choose for trump?");

            Console.WriteLine("1. Hearts\n2. Clubs\n3. Diamonds\n4. Spades");

            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Trump = "Hearts";
                    break;
                case 2:
                    Trump = "Clubs";
                    break;
                case 3:
                    Trump = "Diamonds";
                    break;
                case 4:
                    Trump = "Spades";
                    break;
            }
        }

        public static void CalculateMeld()
        {
            foreach (Player player in Players)
            {
                int points = Points.CalculateMeld(player.Hand, Trump);

                GetTeamWithPlayer(player).RoundPoints += points;

                Console.WriteLine(player.FirstName + " melded " + points + " points.\n\n");
            }
        }

        public static void UpdateController(Player player)
        {
            Controller = player;
        }

        public static void PlayTricks()
        {
            int trickNumber = 1;

            while (Controller.HasCards())
            {
                int[] playerOrder = DeterminePlayerOrder();
                PlayPile = new List<string>();

                for (int i = 0; i < 4; i++)
                {
                    Player curPlayer = Players[playerOrder[i]];

                    if (i == 0)
                        Console.WriteLine("It is now " + curPlayer.FirstName + "'s turn to lead. Please choose a card to play.\n\n");
                    else
                        Console.WriteLine("It's " + curPlayer.FirstName + "'s turn. Please choose a card.\n\n");

                    string playCard = ChooseCardToPlay(Rules.DeterminePlay(curPlayer.Hand, PlayPile, Trump));

                    PlayPile.Add(playCard);
                    curPlayer.RemoveCardFromHand(playCard);
                }

                UpdateController(Players[playerOrder[Rules.DetermineHighestCard(PlayPile, Trump)]]);
                GetTeamWithPlayer(Controller).RoundPoints += Points.CalculateTrickPoints(PlayPile, trickNumber);
                trickNumber++;
            }
        }

        public static int[] DeterminePlayerOrder()
        {
            int[] playerOrder = new int[4];
            int playerIndex = Players.IndexOf(Controller);

            for (int i = 0; i < 4; i++)
            {
                playerOrder[i] = playerIndex;

                if (playerIndex == 3)
                    playerIndex = 0;
                else
                    playerIndex++;
            }

            return playerOrder;
        }
    }
}
