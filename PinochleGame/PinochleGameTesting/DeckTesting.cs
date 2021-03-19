using NUnit.Framework;
using PinochleGame;
using System.Collections.Generic;

namespace PinochleGameTesting
{
    public class DeckTesting
    {
        [Test]
        public void InitializeDeckTesting()
        {
            // Arrange
            List<string> cards = new List<string>
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
            Stack<string> initial = new Stack<string>(cards);

            // Act
            Stack<string> actual = Deck.InitializeDeck();

            // Assert
            Assert.AreNotEqual(initial, actual);
        }

        [Test]
        public void CreateHandTesting()
        {
            // Arrange
            List<string> cards = new List<string>() { "CACE", "HTEN", "SQUEEN", "SQUEEN", "DJACK", "CNINE", "SKING", "DQUEEN", "CKING", "HJACK", "HNINE", "DTEN" };
            Dictionary<string, List<string>> expected = new Dictionary<string, List<string>>();
            expected.Add("Hearts", new List<string>() { "TEN", "JACK", "NINE" });
            expected.Add("Clubs", new List<string>() { "ACE", "NINE", "KING" });
            expected.Add("Diamonds", new List<string>() { "JACK", "QUEEN", "TEN" });
            expected.Add("Spades", new List<string>() { "QUEEN", "QUEEN", "KING" });

            // Act
            Dictionary<string, List<string>> actual = Deck.CreateHandForPlayer(cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
