using NUnit.Framework;
using PinochleGame;
using System.Collections.Generic;

namespace PinochleGameTesting
{
    public class PlayerTesting
    {
        [Test]
        public void OrderCardsTesting()
        {
            // Arrange
            Player player = new Player();
            List<string> suit = new List<string>() { "NINE", "KING", "ACE", "JACK", "TEN", "ACE" };
            List<string> expected = new List<string>() { "ACE", "ACE", "TEN", "KING", "JACK", "NINE" };

            // Act
            List<string> actual = player.OrderCards(suit);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OrderHandTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "JACK", "ACE", "KING", "NINE", "QUEEN", "QUEEN" });
            hand.Add("Clubs", new List<string>() { "JACK", "ACE" });
            hand.Add("Diamonds", new List<string>() { "ACE", "QUEEN" });
            hand.Add("Spades", new List<string>() { "NINE", "TEN" });
            Player player = new Player("Daniel", hand);
            Dictionary<string, List<string>> expected = new Dictionary<string, List<string>>();
            expected.Add("Hearts", new List<string>() { "ACE", "KING", "QUEEN", "QUEEN", "JACK", "NINE" });
            expected.Add("Clubs", new List<string>() { "ACE", "JACK" });
            expected.Add("Diamonds", new List<string>() { "ACE", "QUEEN" });
            expected.Add("Spades", new List<string>() { "TEN", "NINE" });

            // Act
            player.OrderHand();

            // Assert
            Assert.AreEqual(expected, player.Hand);
        }
    }
}
