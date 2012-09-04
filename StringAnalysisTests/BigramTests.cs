﻿using System;
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
            string testValue = "hi";
            string expected = "hi";
            int expectedCount = 1;

            var sut = new Bigram();
            sut.InitializeForValue(testValue);
            var result = sut.BigramSet;

            Assert.That(result.Count, Is.EqualTo(expectedCount));
            Assert.That(result.Contains(expected), Is.True);
        }
    }
}