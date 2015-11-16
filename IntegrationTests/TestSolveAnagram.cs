﻿using System.Collections.Generic;
using AnagramFinder;
using AnagramTypes;
using NUnit.Framework;

namespace IntegrationTests
{
    public class TestSolveAnagram
    {
        [Test]
        public void TestSolve()
        {
            var wordList = new List<string> 
            {
                 "b", "see", "rat", "at", "mat", "rat", "lat", "tab", "green", "act", "a"
            }.ToArray();

            var anagram = new SortedAnagram("acatbat");
            var solver = new RecursiveAnagramFinder();

            var expected = new List<string> { "tab act a" };
            var actual = solver.Solve(anagram, wordList, 0, 3);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
