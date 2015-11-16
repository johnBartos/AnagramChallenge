using AnagramChallenge;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var anagram = new Anagram("acatbat");
            var solver = new AnagramSolver();

            var result = solver.SolveMaxWords(anagram, wordList, 0, 3);
        }
    }
}
