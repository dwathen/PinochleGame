using System;
using System.Collections.Generic;

namespace PinochleGame
{
    public static class Deck
    {
        private static Random rng = new Random();

        public static Stack<string> InitializeDeck()
        {
            List<string> cards = new List<string>()
            {
                "HACE",
                "HACE",
                "HTEN",
                "HTEN",
                "HKING",
                "HKING",
                "HQUEEN",
                "HQUEEN",
                "HJACK",
                "HJACK",
                "HNINE",
                "HNINE",

                "CACE",
                "CACE",
                "CTEN",
                "CTEN",
                "CKING",
                "CKING",
                "CQUEEN",
                "CQUEEN",
                "CJACK",
                "CJACK",
                "CNINE",
                "CNINE",

                "DACE",
                "DACE",
                "DTEN",
                "DTEN",
                "DKING",
                "DKING",
                "DQUEEN",
                "DQUEEN",
                "DJACK",
                "DJACK",
                "DNINE",
                "DNINE",

                "SACE",
                "SACE",
                "STEN",
                "STEN",
                "SKING",
                "SKING",
                "SQUEEN",
                "SQUEEN",
                "SJACK",
                "SJACK",
                "SNINE",
                "SNINE"
            };

            cards = Shuffle<string>(cards);

            Stack<string> deck = new Stack<string>(cards);

            return deck;
        }

        public static List<T> Shuffle<T>(List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }

        public static Dictionary<string, List<string>> CreateHandForPlayer(List<string> cards)
        {
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();

            hand.Add("Hearts", new List<string>());
            hand.Add("Clubs", new List<string>());
            hand.Add("Diamonds", new List<string>());
            hand.Add("Spades", new List<string>());

            foreach (string card in cards)
                hand[Rules.DetermineSuit(card)].Add(card.Substring(1));

            return hand;
        }
    }
}
