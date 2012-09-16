using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StringAnalysis;

namespace StringAnalysisTests
{
    [TestFixture]
    public class BigramTests
    {

        [Test]
        public void InitializeWithValue_Empty_String_Yields_Empty_Set()
        {
            string testValue = string.Empty;
            int expected = 0;

            var sut = new Bigram();
            sut.InitializeForValue(testValue);
            var result = sut.BigramSet;

            Assert.That(result.Count, Is.EqualTo(expected));
        }

        [Test]
        public void InitializeWithValue_Two_Char_String_Yields_One_Item_Set()
        {
            string testValue = "hi";
            string expected = "hi";
            int expectedCount = 1;

            var sut = new Bigram();
            sut.InitializeForValue(testValue);
            var result = sut.BigramSet;

            Assert.That(result.Count, Is.EqualTo(expectedCount));
            Assert.That(result.Contains(expected), Is.True);
        }

        [Test]
        public void InitializeWithValue_Multi_Char_String_Yields_Correct_Item_Set()
        {
            string testValue = "hello";
            int expectedCount = 4;

            var sut = new Bigram();
            sut.InitializeForValue(testValue);
            var result = sut.BigramSet;

            Assert.That(result.Count, Is.EqualTo(expectedCount));
            Assert.That(result.Contains("he"), Is.True);
            Assert.That(result.Contains("el"), Is.True);
            Assert.That(result.Contains("ll"), Is.True);
            Assert.That(result.Contains("lo"), Is.True);
        }

        [Test]
        public void InitializeWithValue_Repeat_Pairs_Yields_One_Item_Set()
        {
            string testValue = "iiii";
            string expected = "ii";
            int expectedCount = 1;

            var sut = new Bigram();
            sut.InitializeForValue(testValue);
            var result = sut.BigramSet;

            Assert.That(result.Count, Is.EqualTo(expectedCount));
            Assert.That(result.Contains(expected), Is.True);
        }

        [Test]
        public void Constructor_Empty_String_Yields_Empty_Set() 
        {
            string testValue = string.Empty;
            int expected = 0;

            var sut = new Bigram(testValue);
            var result = sut.BigramSet;

            Assert.That(result.Count, Is.EqualTo(expected));
        }

        [Test]
        public void Constructor_Two_Char_String_Yields_One_Item_Set()
        {
            string testValue = "hi";
            string expected = "hi";
            int expectedCount = 1;

            var sut = new Bigram(testValue);
            var result = sut.BigramSet;

            Assert.That(result.Count, Is.EqualTo(expectedCount));
            Assert.That(result.Contains(expected), Is.True);
        }

        [Test]
        public void Constructor_Multi_Char_String_Yields_Correct_Item_Set()
        {
            string testValue = "hello";
            int expectedCount = 4;

            var sut = new Bigram(testValue);
            var result = sut.BigramSet;

            Assert.That(result.Count, Is.EqualTo(expectedCount));
            Assert.That(result.Contains("he"), Is.True);
            Assert.That(result.Contains("el"), Is.True);
            Assert.That(result.Contains("ll"), Is.True);
            Assert.That(result.Contains("lo"), Is.True);
        }

        [Test]
        public void Constructor_Repeat_Pairs_Yields_One_Item_Set()
        {
            string testValue = "iiii";
            string expected = "ii";
            int expectedCount = 1;

            var sut = new Bigram(testValue);
            var result = sut.BigramSet;

            Assert.That(result.Count, Is.EqualTo(expectedCount));
            Assert.That(result.Contains(expected), Is.True);
        }

        [Test]
        public void DiceCoefficient_Matching_Bigrams_Returns_1()
        {
            string testValue = "test";
            double expected = 1.0;

            var sut = new Bigram(testValue);
            var sutCompare = new Bigram(testValue);

            var result = sut.DiceCoefficient(sutCompare);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void DiceCoefficient_Matching_Strings_Returns_1()
        {
            string testValue = "test";
            double expected = 1.0;

            var sut = new Bigram(testValue);
            var sutCompare = new Bigram(testValue);

            var result = sut.DiceCoefficient(testValue);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void DiceCoefficient_Completely_Different_Bigrams_Returns_0()
        {
            string testValue1 = "abcd";
            string testValue2 = "wxyz";
            double expected = 0.0;

            var sut = new Bigram(testValue1);
            var sutCompare = new Bigram(testValue2);

            var result = sut.DiceCoefficient(sutCompare);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void DiceCoefficient_Completely_Different_Strings_Returns_0()
        {
            string testValue1 = "abcd";
            string testValue2 = "wxyz";
            double expected = 0.0;

            var sut = new Bigram(testValue1);

            var result = sut.DiceCoefficient(testValue2);

            Assert.That(result, Is.EqualTo(expected));
        }
        
    }
}
