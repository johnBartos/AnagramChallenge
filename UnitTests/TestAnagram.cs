using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnagramChallenge;

namespace UnitTests
{
    public class TestAnagram
    {
        [Test]
        public void TestContainsWord()
        {
            var anagram = new Anagram("act");
            var word = "cat";

            Assert.IsTrue(anagram.ContainsWord(word));
        }

        [Test]
        public void TestSubtractWord()
        {
            var anagram = new Anagram("lolcat");
            var word = "cat";

            var expected = "lol";
            var actual = anagram.SubtractWord(word);

            Assert.AreEqual(expected, actual.ToString());
        }
    }
}
