using NUnit.Framework;
using PinochleGame;
using System.Collections.Generic;

namespace PinochleGameTesting
{
    public class RulesTesting
    {
        [Test]
        public void DetermineSuitHeartTest()
        {
            // Arrange
            string card = "HKING";
            string expected = "Hearts";

            // Act
            string actual = Rules.DetermineSuit(card);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DetermineSuitClubTest()
        {
            // Arrange
            string card = "CJACK";
            string expected = "Clubs";

            // Act
            string actual = Rules.DetermineSuit(card);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DetermineSuitDiamondTest()
        {
            // Arrange
            string card = "DTEN";
            string expected = "Diamonds";

            // Act
            string actual = Rules.DetermineSuit(card);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DetermineSuitSpadeTest()
        {
            // Arrange
            string card = "SACE";
            string expected = "Spades";

            // Act
            string actual = Rules.DetermineSuit(card);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DetermineHighestCardInSuitEqual()
        {
            // Arrange
            string highestCard = "ACE";
            string compareCard = "ACE";
            string expected = "ACE";

            // Act
            string actual = Rules.DetermineHighestCardInSuit(highestCard, compareCard);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DetermineHighestCardInSuitHighCard()
        {
            // Arrange
            string highestCard = "ACE";
            string compareCard = "NINE";
            string expected = "ACE";

            // Act
            string actual = Rules.DetermineHighestCardInSuit(highestCard, compareCard);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DetermineHighestCardInCompareCard()
        {
            // Arrange
            string highestCard = "NINE";
            string compareCard = "ACE";
            string expected = "ACE";

            // Act
            string actual = Rules.DetermineHighestCardInSuit(highestCard, compareCard);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DetermineHighestCardInSuitTenAndNine()
        {
            // Arrange
            string highestCard = "NINE";
            string compareCard = "TEN";
            string expected = "TEN";

            // Act
            string actual = Rules.DetermineHighestCardInSuit(highestCard, compareCard);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DetermineHighestCardInSuitAceAndKing()
        {
            // Arrange
            string highestCard = "KING";
            string compareCard = "ACE";
            string expected = "ACE";

            // Act
            string actual = Rules.DetermineHighestCardInSuit(highestCard, compareCard);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DetermineHighestCardInSuitQueenAndJack()
        {
            // Arrange
            string highestCard = "QUEEN";
            string compareCard = "JACK";
            string expected = "QUEEN";

            // Act
            string actual = Rules.DetermineHighestCardInSuit(highestCard, compareCard);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DetermineHighestCardTwoEqual()
        {
            // Arrange
            List<string> pile = new List<string>() { "CACE", "CACE" };
            string trump = "Clubs";
            int expected = 0;

            // Act
            int actual = Rules.DetermineHighestCard(pile, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DetermineHighestCardFourEqual()
        {
            // Arrange
            List<string> pile = new List<string>() { "CACE", "HNINE", "CNINE", "CACE" };
            string trump = "Clubs";
            int expected = 0;

            // Act
            int actual = Rules.DetermineHighestCard(pile, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DetermineHighestCardWithTrump()
        {
            // Arrange
            List<string> pile = new List<string>() { "HACE", "HNINE", "HQUEEN", "CNINE" };
            string trump = "Clubs";
            int expected = 3;

            // Act
            int actual = Rules.DetermineHighestCard(pile, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DetermineHighestCardWithOffSuit()
        {
            // Arrange
            List<string> pile = new List<string>() { "DNINE", "HACE", "HACE", "HKING" };
            string trump = "Clubs";
            int expected = 0;

            // Act
            int actual = Rules.DetermineHighestCard(pile, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DetermineHighestCardAllSameSuitNotTrump()
        {
            // Arrange
            List<string> pile = new List<string>() { "DNINE", "DKING", "DJACK", "DNINE" };
            string trump = "Clubs";
            int expected = 1;

            // Act
            int actual = Rules.DetermineHighestCard(pile, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DetermineHighestCardAllTrump()
        {
            // Arrange
            List<string> pile = new List<string>() { "DNINE", "DNINE", "DKING", "DJACK" };
            string trump = "Diamonds";
            int expected = 2;

            // Act
            int actual = Rules.DetermineHighestCard(pile, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetHigherCardAceTesting()
        {
            // Arrange
            string highCard = "ACE";
            List<string> expected = new List<string>();

            // Act
            List<string> result = Rules.GetHigherCards(highCard);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetHigherCardTenTesting()
        {
            // Arrange
            string highCard = "TEN";
            List<string> expected = new List<string>() { "ACE" };

            // Act
            List<string> result = Rules.GetHigherCards(highCard);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetHigherCardKingTesting()
        {
            // Arrange
            string highCard = "KING";
            List<string> expected = new List<string>() { "ACE", "TEN" };

            // Act
            List<string> result = Rules.GetHigherCards(highCard);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetHigherCardQueenTesting()
        {
            // Arrange
            string highCard = "QUEEN";
            List<string> expected = new List<string>() { "ACE", "TEN", "KING" };

            // Act
            List<string> result = Rules.GetHigherCards(highCard);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetHigherCardJackTesting()
        {
            // Arrange
            string highCard = "JACK";
            List<string> expected = new List<string>() { "ACE", "TEN", "KING", "QUEEN" };

            // Act
            List<string> result = Rules.GetHigherCards(highCard);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetHigherCardNineTesting()
        {
            // Arrange
            string highCard = "NINE";
            List<string> expected = new List<string>() { "ACE", "TEN", "KING", "QUEEN", "JACK" };

            // Act
            List<string> result = Rules.GetHigherCards(highCard);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DetermineCardsNoHigherCardsTesting()
        {
            // Arrange
            List<string> hand = new List<string>() { "ACE", "TEN", "TEN", "QUEEN" };
            List<string> higherCards = Rules.GetHigherCards("ACE");
            string suit = "Hearts";
            List<string> expected = new List<string>() { "HACE", "HTEN", "HTEN", "HQUEEN" };

            // Act
            List<string> actual = Rules.DetermineCards(hand, higherCards, suit);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DetermineCardsWithHigherCardsTesting()
        {
            // Arrange
            List<string> hand = new List<string>() { "ACE", "TEN", "TEN", "QUEEN" };
            List<string> higherCards = Rules.GetHigherCards("KING");
            string suit = "Hearts";
            List<string> expected = new List<string>() { "HACE", "HTEN", "HTEN" };

            // Act
            List<string> actual = Rules.DetermineCards(hand, higherCards, suit);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DetermineCardsNoHigherCardsInHandTesting()
        {
            // Arrange
            List<string> hand = new List<string>() { "KING", "QUEEN", "QUEEN", "JACK" };
            List<string> higherCards = Rules.GetHigherCards("KING");
            string suit = "Hearts";
            List<string> expected = new List<string>() { "HKING", "HQUEEN", "HQUEEN", "HJACK" };

            // Act
            List<string> actual = Rules.DetermineCards(hand, higherCards, suit);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DeterminePlayAllCardsInSuitTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN" });
            hand.Add("Clubs", new List<string>() { "ACE", "ACE", "TEN", "KING" });
            hand.Add("Diamonds", new List<string>() { "ACE", "ACE" });
            hand.Add("Spades", new List<string>() { "ACE", "TEN" });
            List<string> pile = new List<string>() { "CQUEEN" };
            string trump = "Hearts";
            List<string> expected = new List<string>() { "CACE", "CACE", "CTEN", "CKING" };

            // Act
            List<string> actual = Rules.DeterminePlay(hand, pile, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DeterminePlaySomeCardsInSuitTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN" });
            hand.Add("Clubs", new List<string>() { "ACE", "ACE", "TEN", "KING" });
            hand.Add("Diamonds", new List<string>() { "ACE", "ACE" });
            hand.Add("Spades", new List<string>() { "ACE", "TEN" });
            List<string> pile = new List<string>() { "CQUEEN", "CTEN" };
            string trump = "Hearts";
            List<string> expected = new List<string>() { "CACE", "CACE" };

            // Act
            List<string> actual = Rules.DeterminePlay(hand, pile, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DeterminePlayTrumpTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "QUEEN", "QUEEN" });
            hand.Add("Clubs", new List<string>() { "ACE", "ACE", "TEN", "KING" });
            hand.Add("Diamonds", new List<string>() { "ACE", "ACE" });
            hand.Add("Spades", new List<string>());
            List<string> pile = new List<string>() { "SQUEEN", "SKING", "SACE" };
            string trump = "Hearts";
            List<string> expected = new List<string>() { "HACE", "HACE", "HTEN", "HTEN", "HQUEEN", "HQUEEN" };

            // Act
            List<string> actual = Rules.DeterminePlay(hand, pile, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DeterminePlayAlreadyTrumpedTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "QUEEN", "JACK", "NINE" });
            hand.Add("Clubs", new List<string>() { "ACE", "ACE", "TEN", "KING" });
            hand.Add("Diamonds", new List<string>() { "ACE", "ACE" });
            hand.Add("Spades", new List<string>());
            List<string> pile = new List<string>() { "SQUEEN", "SKING", "HKING" };
            string trump = "Hearts";
            List<string> expected = new List<string>() { "HACE", "HACE", "HTEN" };

            // Act
            List<string> actual = Rules.DeterminePlay(hand, pile, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DeterminePlayNoTrumpOrSuitTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE" });
            hand.Add("Clubs", new List<string>() { "ACE", "ACE", "TEN", "KING" });
            hand.Add("Diamonds", new List<string>());
            hand.Add("Spades", new List<string>());
            List<string> pile = new List<string>() { "SQUEEN", "SKING", "DNINE" };
            string trump = "Diamonds";
            List<string> expected = new List<string>() { "HACE", "HACE", "CACE", "CACE", "CTEN", "CKING" };

            // Act
            List<string> actual = Rules.DeterminePlay(hand, pile, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}