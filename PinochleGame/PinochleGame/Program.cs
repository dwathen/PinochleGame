using System;
using System.Collections.Generic;

namespace PinochleGame
{
    class Program
    {
        public static List<string> Deck { get; set; }
        public static Random rng = new Random();

        static void Main(string[] args)
        {
            InitializeDeck();
            Console.WriteLine("This is Pinochle.");
        }

        static void InitializeDeck()
        {
            Deck.Add("HACE");
            Deck.Add("HACE");
            Deck.Add("HTEN");
            Deck.Add("HTEN");
            Deck.Add("HKING");
            Deck.Add("HKING");
            Deck.Add("HQUEEN");
            Deck.Add("HQUEEN");
            Deck.Add("HJACK");
            Deck.Add("HJACK");
            Deck.Add("HNINE");
            Deck.Add("HNINE");

            Deck.Add("CACE");
            Deck.Add("CACE");
            Deck.Add("CTEN");
            Deck.Add("CTEN");
            Deck.Add("CKING");
            Deck.Add("CKING");
            Deck.Add("CQUEEN");
            Deck.Add("CQUEEN");
            Deck.Add("CJACK");
            Deck.Add("CJACK");
            Deck.Add("CNINE");
            Deck.Add("CNINE");

            Deck.Add("DACE");
            Deck.Add("DACE");
            Deck.Add("DTEN");
            Deck.Add("DTEN");
            Deck.Add("DKING");
            Deck.Add("DKING");
            Deck.Add("DQUEEN");
            Deck.Add("DQUEEN");
            Deck.Add("DJACK");
            Deck.Add("DJACK");
            Deck.Add("DNINE");
            Deck.Add("DNINE");

            Deck.Add("SACE");
            Deck.Add("SACE");
            Deck.Add("STEN");
            Deck.Add("STEN");
            Deck.Add("SKING");
            Deck.Add("SKING");
            Deck.Add("SQUEEN");
            Deck.Add("SQUEEN");
            Deck.Add("SJACK");
            Deck.Add("SJACK");
            Deck.Add("SNINE");
            Deck.Add("SNINE");
        }

        static void Shuffle<T>(List<T> list)
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
