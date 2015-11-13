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
                "red", "a", "tab", "act", "blue", "bat", "aa"
            };

            var anagram = new Anagram("catbat");
            var solver = new AnagramSolver();


            solver.SolveAnagram(anagram, new List<string>(), wordList.ToArray(), 0);
        }
    }
}
