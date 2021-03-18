using System;
using System.Collections.Generic;

namespace PinochleGame
{
    static class Deck
    {
        private static Random rng = new Random();

        public static List<string> InitializeDeck()
        {
            List<string> deck = new List<string>
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

            deck = Shuffle<string>(deck);

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
    }
}
