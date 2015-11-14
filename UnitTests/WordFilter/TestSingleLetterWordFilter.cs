using AnagramChallenge;
using AnagramFileReader.WordFilter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.WordFilter
{
    public class TestSingleLetterWordFilter
    {
        [TestCase("a", true)]
        [TestCase("i", true)]
        [TestCase("O", true)]
        [TestCase("j", false)]
        public void TestFilter(string word, bool expected)
        {
            var filter = new SingleLetterWordFilter();

            Assert.AreEqual(expected, filter.Pass(word));
        }
    }
}
