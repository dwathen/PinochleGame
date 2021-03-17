using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PinochleGame
{
    public static class CalculatePoints
    {

        public static int CalculateTrickPoints(List<string> pile, int trickNumber)
        {
            int points = 0;

            if (trickNumber == 25)
                points++;

            foreach (string card in pile)
            {
                if (card == "ACE" || card == "TEN" || card == "KING")
                    points++;
            }

            return points;
        }

        public static int CalculateMeld(Dictionary<string, List<string>> hand, string trump)
        {
            int points = 0;

            if (HasDoubleRun(hand, trump))
                points += 150;
            else if (HasRun(hand, trump))
            {
                if (HasDoubleMarriage(hand, trump))
                    points += 45;
                else if (CountKings(hand[trump]) == 2 || CountQueens(hand[trump]) == 2)
                    points += 17;
                else
                    points += 15;
            }

            if (HasDoubleAcesRound(hand))
                points += 100;
            else if (HasAcesRound(hand))
                points += 10;

            if (HasDoubleKingsRound(hand))
                points += 80;
            else if (HasKingsRound(hand))
                points += 8;

            if (HasDoubleQueensRound(hand))
                points += 60;
            else if (HasQueensRound(hand))
                points += 6;

            if (HasDoubleJacksRound(hand))
                points += 40;
            else if (HasJacksRound(hand))
                points += 4;

            if (HasDoublePinochle(hand))
                points += 30;
            else if (HasPinochle(hand))
                points += 4;

            foreach (KeyValuePair<string, List<string>> suit in hand)
            {
                if (HasDoubleMarriage(hand, suit.Key))
                {
                    if (suit.Key == trump)
                    {
                        if (!HasDoubleRun(hand, suit.Key) && !HasRun(hand, suit.Key))
                            points += 30;
                    }
                    else
                        points += 4;
                }
                else if (HasMarriage(hand, suit.Key))
                {
                    if (suit.Key == trump)
                    {
                        if (!HasDoubleRun(hand, suit.Key) && !HasRun(hand, suit.Key))
                            points += 4;
                    }
                    else
                        points += 2;
                }
            }

            if (HasDoubleNines(hand, trump))
                points += 2;
            else if (HasDoubleNines(hand, trump))
                points += 1;

            return points;
        }

        public static bool HasDoubleRun(Dictionary<string, List<string>> hand, string suit)
        {
            if (CountAces(hand[suit]) == 2 && CountTens(hand[suit]) == 2 &&
                CountKings(hand[suit]) == 2 && CountQueens(hand[suit]) == 2 &&
                CountJacks(hand[suit]) == 2)
                return true;

            return false;
        }

        public static bool HasRun(Dictionary<string, List<string>> hand, string suit)
        {
            if (CountAces(hand[suit]) > 0 && CountTens(hand[suit]) > 0 &&
                CountKings(hand[suit]) > 0 && CountQueens(hand[suit]) > 0 &&
                CountJacks(hand[suit]) > 0)
                return true;

            return false;
        }

        public static bool HasDoubleAcesRound(Dictionary<string, List<string>> hand)
        {
            if (CountAces(hand["Hearts"]) == 2 && CountAces(hand["Clubs"]) == 2 &&
                CountAces(hand["Diamonds"]) == 2 && CountAces(hand["Spades"]) == 2)
                return true;

            return false;
        }

        public static bool HasAcesRound(Dictionary<string, List<string>> hand)
        {
            if (CountAces(hand["Hearts"]) > 0 && CountAces(hand["Clubs"]) > 0 &&
                CountAces(hand["Diamonds"]) > 0 && CountAces(hand["Spades"]) > 0)
                return true;

            return false;
        }

        public static bool HasDoubleKingsRound(Dictionary<string, List<string>> hand)
        {
            if (CountKings(hand["Hearts"]) == 2 && CountKings(hand["Clubs"]) == 2 &&
                CountKings(hand["Diamonds"]) == 2 && CountKings(hand["Spades"]) == 2)
                return true;

            return false;
        }

        public static bool HasKingsRound(Dictionary<string, List<string>> hand)
        {
            if (CountKings(hand["Hearts"]) > 0 && CountKings(hand["Clubs"]) > 0 &&
                CountKings(hand["Diamonds"]) > 0 && CountKings(hand["Spades"]) > 0)
                return true;

            return false;
        }

        public static bool HasDoubleQueensRound(Dictionary<string, List<string>> hand)
        {
            if (CountQueens(hand["Hearts"]) == 2 && CountQueens(hand["Clubs"]) == 2 &&
                CountQueens(hand["Diamonds"]) == 2 && CountQueens(hand["Spades"]) == 2)
                return true;

            return false;
        }

        public static bool HasQueensRound(Dictionary<string, List<string>> hand)
        {
            if (CountQueens(hand["Hearts"]) > 0 && CountQueens(hand["Clubs"]) > 0 &&
                CountQueens(hand["Diamonds"]) > 0 && CountQueens(hand["Spades"]) > 0)
                return true;

            return false;
        }

        public static bool HasDoubleJacksRound(Dictionary<string, List<string>> hand)
        {
            if (CountJacks(hand["Hearts"]) == 2 && CountJacks(hand["Clubs"]) == 2 &&
                CountJacks(hand["Diamonds"]) == 2 && CountJacks(hand["Spades"]) == 2)
                return true;

            return false;
        }

        public static bool HasJacksRound(Dictionary<string, List<string>> hand)
        {
            if (CountJacks(hand["Hearts"]) > 0 && CountJacks(hand["Clubs"]) > 0 &&
                CountJacks(hand["Diamonds"]) > 0 && CountJacks(hand["Spades"]) > 0)
                return true;

            return false;
        }

        public static bool HasDoublePinochle(Dictionary<string, List<string>> hand)
        {
            if (CountQueens(hand["Spades"]) == 2 &&
                CountJacks(hand["Diamonds"]) == 2)
                return true;

            return false;
        }

        public static bool HasPinochle(Dictionary<string, List<string>> hand)
        {
            if (CountQueens(hand["Spades"]) > 0 &&
                CountJacks(hand["Diamonds"]) > 0)
                return true;

            return false;
        }

        public static bool HasDoubleMarriage(Dictionary<string, List<string>> hand, string suit)
        {
            if (CountKings(hand[suit]) == 2 && CountQueens(hand[suit]) == 2)
                return true;

            return false;
        }

        public static bool HasMarriage(Dictionary<string, List<string>> hand, string suit)
        {
            if (CountKings(hand[suit]) > 0 && CountQueens(hand[suit]) > 0)
                return true;

            return false;
        }

        public static bool HasDoubleNines(Dictionary<string, List<string>> hand, string suit)
        {
            if (CountNines(hand[suit]) == 2)
                return true;

            return false;
        }

        public static bool HasNine(Dictionary<string, List<string>> hand, string suit)
        {
            if (CountNines(hand[suit]) > 0)
                return true;

            return false;
        }

        public static int CountAces(List<string> hand)
        {
            if (hand.Contains("ACE"))
            {
                return hand.Count(str => str.Contains("ACE"));
            }

            return 0;
        }

        public static int CountTens(List<string> hand)
        {
            if (hand.Contains("TEN"))
            {
                return hand.Count(str => str.Contains("TEN"));
            }

            return 0;
        }

        public static int CountKings(List<string> hand)
        {
            if (hand.Contains("KING"))
            {
                return hand.Count(str => str.Contains("KING"));
            }

            return 0;
        }

        public static int CountQueens(List<string> hand)
        {
            if (hand.Contains("QUEEN"))
            {
                return hand.Count(str => str.Contains("QUEEN"));
            }

            return 0;
        }

        public static int CountJacks(List<string> hand)
        {
            if (hand.Contains("JACK"))
            {
                return hand.Count(str => str.Contains("JACK"));
            }

            return 0;
        }

        public static int CountNines(List<string> hand)
        {
            if (hand.Contains("NINE"))
            {
                return hand.Count(str => str.Contains("NINE"));
            }

            return 0;
        }

        public static bool IsPointer(int card)
        {
            if ()

            return false;
        }
    }
}
