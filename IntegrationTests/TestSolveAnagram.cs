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
                "red", "a", "tab", "act", "blue", "green", "aa", "poop", "asdjklhas", "quyeuiqw", "asldhbaskjdhaw", "bvbnvnbvn", "bat", "ajdehiqwuhidq", "rat", "alsjerhqwd"

            }.ToArray();

            var anagram = new Anagram("catbat");
            var solver = new AnagramSolver();

            var result = solver.SolveAnagram(anagram, wordList, 0);
        }
    }
}
