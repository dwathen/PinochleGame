using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PinochleGame
{
    public class Player
    {
        public string FirstName { get; set; }
        public Dictionary<string, List<string>> Hand { get; set; }

        public Player()
        {

        }

        public Player(string firstName, Dictionary<string, List<string>> hand)
        {
            FirstName = firstName;
            Hand = hand;
            OrderHand();
        }

        public void OrderHand()
        {
            Dictionary<string, List<string>> tempHand = new Dictionary<string, List<string>>();
            tempHand.Add("Hearts", new List<string>());
            tempHand.Add("Clubs", new List<string>());
            tempHand.Add("Diamonds", new List<string>());
            tempHand.Add("Spades", new List<string>());

            foreach (KeyValuePair<string, List<string>> suit in Hand)
            {
                tempHand[suit.Key].AddRange(OrderCards(suit.Value));
            }

            Hand = tempHand;
        }

        public List<string> OrderCards(List<string> suit)
        {
            List<string> orderedCards = new List<string>();

            for (int i = 0; i < suit.Count(x => x.Contains("ACE")); i++)
                orderedCards.Add("ACE");

            for (int i = 0; i < suit.Count(x => x.Contains("TEN")); i++)
                orderedCards.Add("TEN");

            for (int i = 0; i < suit.Count(x => x.Contains("KING")); i++)
                orderedCards.Add("KING");

            for (int i = 0; i < suit.Count(x => x.Contains("QUEEN")); i++)
                orderedCards.Add("QUEEN");

            for (int i = 0; i < suit.Count(x => x.Contains("JACK")); i++)
                orderedCards.Add("JACK");

            for (int i = 0; i < suit.Count(x => x.Contains("NINE")); i++)
                orderedCards.Add("NINE");

            return orderedCards;
        }
    }
}
