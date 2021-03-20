using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PinochleGame
{
    public static class Rules
    {
        public static List<string> DeterminePlay(Dictionary<string, List<string>> hand, List<string> pile, string trump)
        {
            List<string> cardsToPlay = new List<string>();
            bool isTrumped = false;

            foreach (string card in pile)
            {
                if (DetermineSuit(card) == trump)
                    isTrumped = true;
            }

            if (pile.Count == 0)
            {
                foreach (KeyValuePair<string, List<string>> suit in hand)
                    cardsToPlay.AddRange(DetermineCards(suit.Value, new List<string>(), suit.Key));
            }
            else
            {
                List<string> higherCards = GetHigherCards(pile[DetermineHighestCard(pile, trump)].Substring(1));
                string suitLed = DetermineSuit(pile[0]);

                if (hand[trump].Count == 0 && hand[suitLed].Count == 0)
                {
                    foreach (KeyValuePair<string, List<string>> suit in hand)
                        cardsToPlay.AddRange(DetermineCards(suit.Value, suit.Key));
                }
                else if (hand[suitLed].Count > 0)
                {
                    if (isTrumped && suitLed != trump)
                        cardsToPlay.AddRange(DetermineCards(hand[suitLed], suitLed));
                    else
                        cardsToPlay.AddRange(DetermineCards(hand[suitLed], higherCards, suitLed));
                }
                else if (hand[suitLed].Count == 0 && hand[trump].Count > 0)
                    cardsToPlay.AddRange(DetermineCards(hand[trump], higherCards, trump));
            }

            return cardsToPlay;
        }

        public static List<string> DetermineCards(List<string> hand, List<string> higherCards, string suit)
        {
            List<string> cardsToPlay = new List<string>();

            foreach (string card in higherCards)
            {
                for (int i = 0; i < hand.Count(str => str.Contains(card)); i++)
                    cardsToPlay.Add(suit.Substring(0, 1) + card);
            }

            if (cardsToPlay.Count == 0 || higherCards.Count == 0)
            {
                for (int i = 0; i < hand.Count; i++)
                    cardsToPlay.Add(suit.Substring(0, 1) + hand[i]);

                return cardsToPlay;
            }
            else
                return cardsToPlay;
        }

        public static List<string> DetermineCards(List<string> hand, string suit)
        {
            List<string> cardsToPlay = new List<string>();

            for (int i = 0; i < hand.Count; i++)
                cardsToPlay.Add(suit.Substring(0, 1) + hand[i]);

            return cardsToPlay;
        }

        public static int DetermineHighestCard(List<string> pile, string trump)
        {
            int indexOfHighestCard = 0;
            string highestCard = pile[0];
            string startSuit = DetermineSuit(pile[0]);
            

            foreach (string card in pile)
            {
                string suit = DetermineSuit(card);

                if (card == pile[indexOfHighestCard])
                    continue;
                else if (suit == startSuit && startSuit != trump)
                {
                    if (DetermineSuit(highestCard) != trump)
                    {
                        highestCard = suit.Substring(0, 1) + DetermineHighestCardInSuit(highestCard.Substring(1), card.Substring(1));
                        indexOfHighestCard = pile.IndexOf(highestCard);
                    }
                }
                else if (suit == trump && DetermineSuit(highestCard) == trump)
                {
                    highestCard = suit.Substring(0, 1) + DetermineHighestCardInSuit(highestCard.Substring(1), card.Substring(1));
                    indexOfHighestCard = pile.IndexOf(highestCard);
                }
                else if (suit == trump && DetermineSuit(highestCard) != trump)
                {
                    highestCard = card;
                    indexOfHighestCard = pile.IndexOf(highestCard);
                }
            }

            return indexOfHighestCard;
        }

        public static string DetermineHighestCardInSuit(string highCard, string compareCard)
        {
            switch(highCard)
            {
                case "ACE":
                    return highCard;
                case "TEN":
                    if (compareCard == "ACE")
                        return compareCard;
                    else
                        return highCard;
                case "KING":
                    if (compareCard == "ACE" || compareCard == "TEN")
                        return compareCard;
                    else
                        return highCard;
                case "QUEEN":
                    if (compareCard == "ACE" || compareCard == "TEN" || compareCard == "KING")
                        return compareCard;
                    else
                        return highCard;
                case "JACK":
                    if (compareCard == "NINE" || compareCard == "JACK")
                        return highCard;
                    else
                        return compareCard;
                case "NINE":
                    if (compareCard == "NINE")
                        return highCard;
                    else
                        return compareCard;
                default:
                    return highCard;
            }
        }

        public static List<string> GetHigherCards(string highCard)
        {
            List<string> higherCards = new List<string>();
            switch(highCard)
            {
                case "ACE":
                    break;
                case "TEN":
                    higherCards.Add("ACE");
                    break;
                case "KING":
                    higherCards.Add("ACE");
                    higherCards.Add("TEN");
                    break;
                case "QUEEN":
                    higherCards.Add("ACE");
                    higherCards.Add("TEN");
                    higherCards.Add("KING");
                    break;
                case "JACK":
                    higherCards.Add("ACE");
                    higherCards.Add("TEN");
                    higherCards.Add("KING");
                    higherCards.Add("QUEEN");
                    break;
                case "NINE":
                    higherCards.Add("ACE");
                    higherCards.Add("TEN");
                    higherCards.Add("KING");
                    higherCards.Add("QUEEN");
                    higherCards.Add("JACK");
                    break;
            }

            return higherCards;
        }

        public static string DetermineSuit(string card)
        {
            switch (card.Substring(0, 1))
            {
                case "H":
                    return "Hearts";
                case "C":
                    return "Clubs";
                case "D":
                    return "Diamonds";
                case "S":
                    return "Spades";
                default:
                    return "";
            }
        }
    }
}
