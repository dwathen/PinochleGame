using System;
using System.Collections.Generic;

namespace PinochleGame
{
    enum Cards
    {
        // Hearts
        AceOfHearts1,
        AceOfHearts2,
        TenOfHearts1,
        TenOfHearts2,
        KingOfHearts1,
        KingOfHearts2,
        QueenOfHearts1,
        QueenOfHearts2,
        JackOfHearts1,
        JackOfHearts2,
        NineOfHearts1,
        NineOfHearts2,

        // Clubs
        AceOfClubs1,
        AceOfClubs2,
        TenOfClubs1,
        TenOfClubs2,
        KingOfClubs1,
        KingOfClubs2,
        QueenOfClubs1,
        QueenOfClubs2,
        JackOfClubs1,
        JackOfClubs2,
        NineOfClubs1,
        NineOfClubs2,

        // Diamonds,
        AceOfDiamonds1,
        AceOfDiamonds2,
        TenOfDiamonds1,
        TenOfDiamonds2,
        KingOfDiamonds1,
        KingOfDiamonds2,
        QueenOfDiamonds1,
        QueenOfDiamonds2,
        JackOfDiamonds1,
        JackOfDiamonds2,
        NineOfDiamonds1,
        NineOfDiamonds2,

        // Spades
        AceOfSpades1,
        AceOfSpades2,
        TenOfSpades1,
        TenOfSpades2,
        KingOfSpades1,
        KingOfSpades2,
        QueenOfSpades1,
        QueenOfSpades2,
        JackOfSpades1,
        JackOfSpades2,
        NineOfSpades1,
        NineOfSpades2
    }

    static class Deck
    {
        private static Random rng = new Random();
        public static List<Cards> pointerCards = new List<Cards>()
        {
            Cards.AceOfClubs1, Cards.AceOfClubs2, Cards.AceOfDiamonds1, Cards.AceOfDiamonds2, 
            Cards.AceOfHearts1, Cards.AceOfHearts2, Cards.AceOfSpades1, Cards.AceOfSpades2,

            Cards.TenOfClubs1, Cards.TenOfClubs2, Cards.TenOfDiamonds1, Cards.TenOfDiamonds2,
            Cards.TenOfHearts1, Cards.TenOfHearts2, Cards.TenOfSpades1, Cards.TenOfSpades2,

            Cards.KingOfClubs1, Cards.KingOfClubs2, Cards.KingOfDiamonds1, Cards.KingOfDiamonds2,
            Cards.KingOfHearts1, Cards.KingOfHearts2, Cards.KingOfSpades1, Cards.KingOfSpades2
        };

        public static List<int> InitializeDeck()
        {
            List<int> deck = new List<int>();

            for (int i = 0; i < 48; i++)
            {
                deck.Add(i);
            }

            return deck;
        }

        public static string DetermineSuit(int card)
        {
            if (card < 12)
                return "Hearts";
            else if (card < 24)
                return "Clubs";
            else if (card < 36)
                return "Diamonds";
            else
                return "Spades";
        }

        public static int DeterminePointValue(int card)
        {


            return 0;
        }

        public static void Shuffle<T>(List<T> list)
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
        }
    }
}
