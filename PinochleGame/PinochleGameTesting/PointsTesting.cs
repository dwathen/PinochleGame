using NUnit.Framework;
using PinochleGame;
using System.Collections.Generic;

namespace PinochleGameTesting
{
    public class PointsTesting
    {
        [Test]
        public void CountNinesTwoTesting()
        {
            // Arrange
            List<string> hand = new List<string>() { "KING", "NINE", "NINE" };
            int expected = 2;

            // Act
            int actual = Points.CountNines(hand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountNinesOneTesting()
        {
            // Arrange
            List<string> hand = new List<string>() { "ACE", "ACE", "TEN", "QUEEN", "JACK", "NINE" };
            int expected = 1;

            // Act
            int actual = Points.CountNines(hand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountNinesZeroTesting()
        {
            // Arrange
            List<string> hand = new List<string>() { "ACE", "ACE", "TEN", "QUEEN", "JACK", "JACK" };
            int expected = 0;

            // Act
            int actual = Points.CountNines(hand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasDoubleRunTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "KING", "KING", "QUEEN", "QUEEN", "JACK", "JACK" });
            hand.Add("Clubs", new List<string>());
            hand.Add("Diamonds", new List<string>());
            hand.Add("Spades", new List<string>() { "ACE", "TEN" });
            string trump = "Hearts";
            bool expected = true;

            // Act
            bool actual = Points.HasDoubleRun(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasDoubleRunFalseTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "KING", "KING", "QUEEN", "QUEEN", "JACK", "NINE" });
            hand.Add("Clubs", new List<string>() { "NINE" });
            hand.Add("Diamonds", new List<string>());
            hand.Add("Spades", new List<string>() { "ACE", "TEN" });
            string trump = "Hearts";
            bool expected = false;

            // Act
            bool actual = Points.HasDoubleRun(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasRunTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "KING", "KING", "QUEEN", "QUEEN", "JACK", "NINE" });
            hand.Add("Clubs", new List<string>() { "NINE" });
            hand.Add("Diamonds", new List<string>());
            hand.Add("Spades", new List<string>() { "ACE", "TEN" });
            string trump = "Hearts";
            bool expected = true;

            // Act
            bool actual = Points.HasRun(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasRunFalseTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "KING", "KING", "QUEEN", "QUEEN", "NINE", "NINE" });
            hand.Add("Clubs", new List<string>() { "NINE", "NINE" });
            hand.Add("Diamonds", new List<string>());
            hand.Add("Spades", new List<string>() { "ACE", "TEN" });
            string trump = "Hearts";
            bool expected = false;

            // Act
            bool actual = Points.HasRun(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasDoubleAcesRoundTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "KING", "KING" });
            hand.Add("Clubs", new List<string>() { "ACE", "ACE" });
            hand.Add("Diamonds", new List<string>() { "ACE", "ACE" });
            hand.Add("Spades", new List<string>() { "ACE", "ACE" });
            bool expected = true;

            // Act
            bool actual = Points.HasDoubleAcesRound(hand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasDoubleAcesRoundFalseTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "KING", "KING" });
            hand.Add("Clubs", new List<string>() { "ACE", "ACE" });
            hand.Add("Diamonds", new List<string>() { "ACE", "ACE" });
            hand.Add("Spades", new List<string>() { "ACE", "TEN" });
            bool expected = false;

            // Act
            bool actual = Points.HasDoubleAcesRound(hand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasAcesRoundTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "KING", "KING" });
            hand.Add("Clubs", new List<string>() { "ACE", "ACE" });
            hand.Add("Diamonds", new List<string>() { "ACE", "ACE" });
            hand.Add("Spades", new List<string>() { "ACE", "TEN" });
            bool expected = true;

            // Act
            bool actual = Points.HasAcesRound(hand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasAcesRoundFalseTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "KING", "KING" });
            hand.Add("Clubs", new List<string>() { "ACE", "ACE" });
            hand.Add("Diamonds", new List<string>() { "ACE", "ACE" });
            hand.Add("Spades", new List<string>() { "TEN", "TEN" });
            bool expected = false;

            // Act
            bool actual = Points.HasAcesRound(hand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasDoubleKingsRoundTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "KING", "KING" });
            hand.Add("Clubs", new List<string>() { "KING", "KING" });
            hand.Add("Diamonds", new List<string>() { "KING", "KING" });
            hand.Add("Spades", new List<string>() { "KING", "KING" });
            bool expected = true;

            // Act
            bool actual = Points.HasDoubleKingsRound(hand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasDoubleKingsRoundFalseTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "KING", "KING" });
            hand.Add("Clubs", new List<string>() { "KING", "KING" });
            hand.Add("Diamonds", new List<string>() { "KING", "QUEEN" });
            hand.Add("Spades", new List<string>() { "KING", "KING" });
            bool expected = false;

            // Act
            bool actual = Points.HasDoubleKingsRound(hand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasKingsRoundTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "KING", "KING" });
            hand.Add("Clubs", new List<string>() { "KING", "KING" });
            hand.Add("Diamonds", new List<string>() { "KING", "QUEEN" });
            hand.Add("Spades", new List<string>() { "KING", "KING" });
            bool expected = true;

            // Act
            bool actual = Points.HasKingsRound(hand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasKingsRoundFalseTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "KING", "KING" });
            hand.Add("Clubs", new List<string>() { "KING", "KING" });
            hand.Add("Diamonds", new List<string>() { "KING", "KING" });
            hand.Add("Spades", new List<string>() { "QUEEN", "QUEEN" });
            bool expected = false;

            // Act
            bool actual = Points.HasKingsRound(hand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasDoubleQueensRoundTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "QUEEN", "QUEEN" });
            hand.Add("Clubs", new List<string>() { "QUEEN", "QUEEN" });
            hand.Add("Diamonds", new List<string>() { "QUEEN", "QUEEN" });
            hand.Add("Spades", new List<string>() { "QUEEN", "QUEEN" });
            bool expected = true;

            // Act
            bool actual = Points.HasDoubleQueensRound(hand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasDoubleQueensRoundFalseTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "QUEEN", "QUEEN" });
            hand.Add("Clubs", new List<string>() { "QUEEN", "QUEEN" });
            hand.Add("Diamonds", new List<string>() { "QUEEN", "QUEEN" });
            hand.Add("Spades", new List<string>() { "KING", "QUEEN" });
            bool expected = false;

            // Act
            bool actual = Points.HasDoubleQueensRound(hand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasQueensRoundTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "QUEEN", "QUEEN" });
            hand.Add("Clubs", new List<string>() { "QUEEN", "QUEEN" });
            hand.Add("Diamonds", new List<string>() { "QUEEN", "QUEEN" });
            hand.Add("Spades", new List<string>() { "KING", "QUEEN" });
            bool expected = true;

            // Act
            bool actual = Points.HasQueensRound(hand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasQueensRoundFalseTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "QUEEN", "QUEEN" });
            hand.Add("Clubs", new List<string>() { "QUEEN", "QUEEN" });
            hand.Add("Diamonds", new List<string>() { "QUEEN", "QUEEN" });
            hand.Add("Spades", new List<string>() { "KING", "KING" });
            bool expected = false;

            // Act
            bool actual = Points.HasQueensRound(hand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasDoubleJacksRoundTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "JACK", "JACK" });
            hand.Add("Clubs", new List<string>() { "JACK", "JACK" });
            hand.Add("Diamonds", new List<string>() { "JACK", "JACK" });
            hand.Add("Spades", new List<string>() { "JACK", "JACK" });
            bool expected = true;

            // Act
            bool actual = Points.HasDoubleJacksRound(hand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasDoubleJacksRoundFalseTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "JACK", "JACK" });
            hand.Add("Clubs", new List<string>() { "JACK", "JACK" });
            hand.Add("Diamonds", new List<string>() { "JACK", "JACK" });
            hand.Add("Spades", new List<string>() { "JACK", "NINE" });
            bool expected = false;

            // Act
            bool actual = Points.HasDoubleJacksRound(hand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasJacksRoundTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "JACK", "JACK" });
            hand.Add("Clubs", new List<string>() { "JACK", "JACK" });
            hand.Add("Diamonds", new List<string>() { "JACK", "JACK" });
            hand.Add("Spades", new List<string>() { "JACK", "NINE" });
            bool expected = true;

            // Act
            bool actual = Points.HasJacksRound(hand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasJacksRoundFalseTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "JACK", "JACK" });
            hand.Add("Clubs", new List<string>() { "JACK", "JACK" });
            hand.Add("Diamonds", new List<string>() { "JACK", "JACK" });
            hand.Add("Spades", new List<string>() { "NINE", "NINE" });
            bool expected = false;

            // Act
            bool actual = Points.HasJacksRound(hand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasDoublePinochleTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "JACK", "JACK" });
            hand.Add("Clubs", new List<string>() { "JACK", "JACK" });
            hand.Add("Diamonds", new List<string>() { "JACK", "JACK" });
            hand.Add("Spades", new List<string>() { "QUEEN", "QUEEN" });
            bool expected = true;

            // Act
            bool actual = Points.HasDoublePinochle(hand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasDoublePinochleFalseTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "JACK", "JACK" });
            hand.Add("Clubs", new List<string>() { "JACK", "JACK" });
            hand.Add("Diamonds", new List<string>() { "JACK", "JACK" });
            hand.Add("Spades", new List<string>() { "KING", "QUEEN" });
            bool expected = false;

            // Act
            bool actual = Points.HasDoublePinochle(hand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasPinochleTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "JACK", "JACK" });
            hand.Add("Clubs", new List<string>() { "JACK", "JACK" });
            hand.Add("Diamonds", new List<string>() { "JACK", "JACK" });
            hand.Add("Spades", new List<string>() { "KING", "QUEEN" });
            bool expected = true;

            // Act
            bool actual = Points.HasPinochle(hand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasPinochleFalseTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "JACK", "JACK" });
            hand.Add("Clubs", new List<string>() { "JACK", "JACK" });
            hand.Add("Diamonds", new List<string>() { "JACK", "JACK" });
            hand.Add("Spades", new List<string>() { "KING", "KING" });
            bool expected = false;

            // Act
            bool actual = Points.HasPinochle(hand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasDoubleMarriageTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "KING", "KING", "QUEEN", "QUEEN" });
            hand.Add("Clubs", new List<string>() { "JACK", "JACK" });
            hand.Add("Diamonds", new List<string>() { "JACK", "JACK" });
            hand.Add("Spades", new List<string>() { "QUEEN", "QUEEN" });
            string trump = "Hearts";
            bool expected = true;

            // Act
            bool actual = Points.HasDoubleMarriage(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasDoubleMarriageFalseTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "KING", "KING", "QUEEN", "JACK" });
            hand.Add("Clubs", new List<string>() { "JACK", "JACK" });
            hand.Add("Diamonds", new List<string>() { "JACK", "JACK" });
            hand.Add("Spades", new List<string>() { "QUEEN", "QUEEN" });
            string trump = "Hearts";
            bool expected = false;

            // Act
            bool actual = Points.HasDoubleMarriage(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasMarriageTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "KING", "KING", "JACK", "JACK" });
            hand.Add("Clubs", new List<string>() { "JACK", "JACK" });
            hand.Add("Diamonds", new List<string>() { "JACK", "JACK" });
            hand.Add("Spades", new List<string>() { "KING", "QUEEN" });
            string suit = "Spades";
            bool expected = true;

            // Act
            bool actual = Points.HasMarriage(hand, suit);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasMarriageFalseTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "KING", "KING", "QUEEN", "QUEEN" });
            hand.Add("Clubs", new List<string>() { "JACK", "JACK" });
            hand.Add("Diamonds", new List<string>() { "JACK", "JACK" });
            hand.Add("Spades", new List<string>() { "QUEEN", "QUEEN" });
            string suit = "Spades";
            bool expected = false;

            // Act
            bool actual = Points.HasMarriage(hand, suit);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasDoubleNineTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "NINE", "NINE" });
            hand.Add("Clubs", new List<string>() { "ACE", "ACE", "TEN" });
            hand.Add("Diamonds", new List<string>() { "QUEEN", "JACK" });
            hand.Add("Spades", new List<string>() { "ACE", "TEN" });
            string trump = "Hearts";
            bool expected = true;

            // Act
            bool actual = Points.HasDoubleNines(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasDoubleNineFalseTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "JACK", "NINE" });
            hand.Add("Clubs", new List<string>() { "ACE", "ACE", "TEN" });
            hand.Add("Diamonds", new List<string>() { "QUEEN", "JACK" });
            hand.Add("Spades", new List<string>() { "ACE", "TEN" });
            string trump = "Hearts";
            bool expected = false;

            // Act
            bool actual = Points.HasDoubleNines(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasNineTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "QUEEN", "NINE" });
            hand.Add("Clubs", new List<string>() { "ACE", "ACE", "TEN" });
            hand.Add("Diamonds", new List<string>() { "QUEEN", "JACK" });
            hand.Add("Spades", new List<string>() { "ACE", "TEN" });
            string trump = "Hearts";
            bool expected = true;

            // Act
            bool actual = Points.HasNine(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HasNineFalseTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "QUEEN", "JACK" });
            hand.Add("Clubs", new List<string>() { "ACE", "ACE", "TEN" });
            hand.Add("Diamonds", new List<string>() { "QUEEN", "JACK" });
            hand.Add("Spades", new List<string>() { "ACE", "TEN" });
            string trump = "Hearts";
            bool expected = false;

            // Act
            bool actual = Points.HasNine(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountDoubleRunPointsTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "KING", "KING", "QUEEN", "QUEEN", "JACK", "JACK" });
            hand.Add("Clubs", new List<string>());
            hand.Add("Diamonds", new List<string>());
            hand.Add("Spades", new List<string>() { "ACE", "TEN" });
            string trump = "Hearts";
            int expected = 150;

            // Act
            int actual = Points.CalculateMeld(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountRunPointsTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "KING", "KING", "QUEEN", "QUEEN", "JACK", "NINE" });
            hand.Add("Clubs", new List<string>() { "NINE" });
            hand.Add("Diamonds", new List<string>());
            hand.Add("Spades", new List<string>() { "ACE", "TEN" });
            string trump = "Hearts";
            int expected = 46;

            // Act
            int actual = Points.CalculateMeld(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountDoubleAcesRoundPointsTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "KING", "KING" });
            hand.Add("Clubs", new List<string>() { "ACE", "ACE" });
            hand.Add("Diamonds", new List<string>() { "ACE", "ACE" });
            hand.Add("Spades", new List<string>() { "ACE", "ACE" });
            string trump = "Hearts";
            int expected = 100;

            // Act
            int actual = Points.CalculateMeld(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountAcesRoundPointsTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "KING", "KING" });
            hand.Add("Clubs", new List<string>() { "ACE", "ACE" });
            hand.Add("Diamonds", new List<string>() { "ACE", "ACE" });
            hand.Add("Spades", new List<string>() { "ACE", "TEN" });
            string trump = "Hearts";
            int expected = 10;

            // Act
            int actual = Points.CalculateMeld(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountDoubleKingsRoundPointsTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "KING", "KING" });
            hand.Add("Clubs", new List<string>() { "KING", "KING" });
            hand.Add("Diamonds", new List<string>() { "KING", "KING" });
            hand.Add("Spades", new List<string>() { "KING", "KING" });
            string trump = "Hearts";
            int expected = 80;

            // Act
            int actual = Points.CalculateMeld(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountKingsRoundPointsTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "KING", "KING" });
            hand.Add("Clubs", new List<string>() { "KING", "KING" });
            hand.Add("Diamonds", new List<string>() { "KING", "QUEEN" });
            hand.Add("Spades", new List<string>() { "KING", "KING" });
            string trump = "Hearts";
            int expected = 10;

            // Act
            int actual = Points.CalculateMeld(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountDoubleQueensRoundPointsTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "QUEEN", "QUEEN" });
            hand.Add("Clubs", new List<string>() { "QUEEN", "QUEEN" });
            hand.Add("Diamonds", new List<string>() { "QUEEN", "QUEEN" });
            hand.Add("Spades", new List<string>() { "QUEEN", "QUEEN" });
            string trump = "Hearts";
            int expected = 60;

            // Act
            int actual = Points.CalculateMeld(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountQueensRoundPointsTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "QUEEN", "QUEEN" });
            hand.Add("Clubs", new List<string>() { "QUEEN", "QUEEN" });
            hand.Add("Diamonds", new List<string>() { "QUEEN", "QUEEN" });
            hand.Add("Spades", new List<string>() { "KING", "QUEEN" });
            string trump = "Hearts";
            int expected = 8;

            // Act
            int actual = Points.CalculateMeld(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountDoubleJacksRoundPointsTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "JACK", "JACK" });
            hand.Add("Clubs", new List<string>() { "JACK", "JACK" });
            hand.Add("Diamonds", new List<string>() { "JACK", "JACK" });
            hand.Add("Spades", new List<string>() { "JACK", "JACK" });
            string trump = "Hearts";
            int expected = 40;

            // Act
            int actual = Points.CalculateMeld(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountJacksRoundPointsTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "JACK", "JACK" });
            hand.Add("Clubs", new List<string>() { "JACK", "JACK" });
            hand.Add("Diamonds", new List<string>() { "JACK", "JACK" });
            hand.Add("Spades", new List<string>() { "JACK", "NINE" });
            string trump = "Hearts";
            int expected = 4;

            // Act
            int actual = Points.CalculateMeld(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountDoublePinochlePointsTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "JACK", "JACK" });
            hand.Add("Clubs", new List<string>() { "JACK", "JACK" });
            hand.Add("Diamonds", new List<string>() { "JACK", "JACK" });
            hand.Add("Spades", new List<string>() { "QUEEN", "QUEEN" });
            string trump = "Hearts";
            int expected = 30;

            // Act
            int actual = Points.CalculateMeld(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountPinochlePointsTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "TEN", "JACK", "JACK" });
            hand.Add("Clubs", new List<string>() { "JACK", "JACK" });
            hand.Add("Diamonds", new List<string>() { "JACK", "JACK" });
            hand.Add("Spades", new List<string>() { "KING", "QUEEN" });
            string trump = "Hearts";
            int expected = 6;

            // Act
            int actual = Points.CalculateMeld(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountDoubleRoyalMarriagePointsTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "KING", "KING", "QUEEN", "QUEEN" });
            hand.Add("Clubs", new List<string>() { "JACK", "JACK" });
            hand.Add("Diamonds", new List<string>() { "JACK", "JACK" });
            hand.Add("Spades", new List<string>() { "QUEEN", "QUEEN" });
            string trump = "Hearts";
            int expected = 60;

            // Act
            int actual = Points.CalculateMeld(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountRoyalMarriagePointsTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "KING", "KING", "QUEEN", "JACK" });
            hand.Add("Clubs", new List<string>() { "JACK", "JACK" });
            hand.Add("Diamonds", new List<string>() { "JACK", "JACK" });
            hand.Add("Spades", new List<string>() { "KING", "QUEEN" });
            string trump = "Hearts";
            int expected = 10;

            // Act
            int actual = Points.CalculateMeld(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountDoubleCommonMarriagePointsTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "KING", "KING" });
            hand.Add("Clubs", new List<string>() { "JACK", "JACK" });
            hand.Add("Diamonds", new List<string>() { "JACK", "JACK" });
            hand.Add("Spades", new List<string>() { "KING", "KING", "QUEEN", "QUEEN" });
            string trump = "Hearts";
            int expected = 34;

            // Act
            int actual = Points.CalculateMeld(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountCommonMarriagePointsTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "KING", "KING" });
            hand.Add("Clubs", new List<string>() { "JACK", "JACK" });
            hand.Add("Diamonds", new List<string>() { "JACK", "JACK" });
            hand.Add("Spades", new List<string>() { "KING", "KING", "QUEEN", "JACK" });
            string trump = "Hearts";
            int expected = 6;

            // Act
            int actual = Points.CalculateMeld(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountDoubleNinePointsTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "NINE", "NINE" });
            hand.Add("Clubs", new List<string>() { "ACE", "ACE", "TEN" });
            hand.Add("Diamonds", new List<string>() { "QUEEN", "JACK" });
            hand.Add("Spades", new List<string>() { "ACE", "TEN" });
            string trump = "Hearts";
            int expected = 2;

            // Act
            int actual = Points.CalculateMeld(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountNinePointsTesting()
        {
            // Arrange
            Dictionary<string, List<string>> hand = new Dictionary<string, List<string>>();
            hand.Add("Hearts", new List<string>() { "ACE", "ACE", "TEN", "QUEEN", "NINE" });
            hand.Add("Clubs", new List<string>() { "ACE", "ACE", "TEN" });
            hand.Add("Diamonds", new List<string>() { "QUEEN", "JACK" });
            hand.Add("Spades", new List<string>() { "ACE", "TEN" });
            string trump = "Hearts";
            int expected = 1;

            // Act
            int actual = Points.CalculateMeld(hand, trump);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Trick5PointsTesting()
        {
            // Arrange
            List<string> pile = new List<string>() { "CACE", "CKING", "HACE", "HKING" };
            int trickNumber = 25;
            int expected = 5;

            // Act
            int actual = Points.CalculateTrickPoints(pile, trickNumber);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Trick4PointsTesting()
        {
            // Arrange
            List<string> pile = new List<string>() { "CACE", "CKING", "CKING", "HKING" };
            int trickNumber = 5;
            int expected = 4;

            // Act
            int actual = Points.CalculateTrickPoints(pile, trickNumber);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Trick3PointsTesting()
        {
            // Arrange
            List<string> pile = new List<string>() { "CACE", "CKING", "CNINE", "HKING" };
            int trickNumber = 5;
            int expected = 3;

            // Act
            int actual = Points.CalculateTrickPoints(pile, trickNumber);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Trick2PointsTesting()
        {
            // Arrange
            List<string> pile = new List<string>() { "CACE", "CKING", "CNINE", "CQUEEN" };
            int trickNumber = 9;
            int expected = 2;

            // Act
            int actual = Points.CalculateTrickPoints(pile, trickNumber);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Trick1PointsTesting()
        {
            // Arrange
            List<string> pile = new List<string>() { "CNINE", "CKING", "CNINE", "CQUEEN" };
            int trickNumber = 20;
            int expected = 1;

            // Act
            int actual = Points.CalculateTrickPoints(pile, trickNumber);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Trick0PointsTesting()
        {
            // Arrange
            List<string> pile = new List<string>() { "CQUEEN", "CJACK", "HNINE", "DNINE" };
            int trickNumber = 3;
            int expected = 0;

            // Act
            int actual = Points.CalculateTrickPoints(pile, trickNumber);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
