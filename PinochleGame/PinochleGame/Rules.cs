using System;
using System.Collections.Generic;
using System.Text;

namespace PinochleGame
{
    public static class Rules
    {
        public static List<string> DeterminePlay(Dictionary<string, List<string>> hand, List<string> pile, string suitLed, string trump, bool isTrumped, string highestCard)
        {
            List<string> cardsToPlay = new List<string>();

            if (isTrumped)
            {
                if (hand[trump].Count == 0 && hand[suitLed].Count == 0)
                {
                    foreach (KeyValuePair<string, List<string>> suit in hand)
                    {
                        foreach (string card in suit.Value)
                            cardsToPlay.Add(suit.Key.Substring(0, 1) + card);
                    }
                }
                else if (hand[trump].Count == 0)
                {
                    foreach (string card in hand[suitLed])
                        cardsToPlay.Add(suitLed.Substring(0, 1) + card);
                }
                else
                {
                    foreach (string card in hand[trump])
                        cardsToPlay.Add(trump.Substring(0, 1) + card);
                }
            }
            else
            {
                if (hand[suitLed].Count == 0)
            }

            return cardsToPlay;
        }
    }
}
