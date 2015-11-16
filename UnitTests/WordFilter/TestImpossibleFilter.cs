using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnagramFinder;
using AnagramFileReader.WordFilter;
using NUnit.Framework;
using AnagramTypes;

namespace UnitTests.WordFilter
{
    public class TestImpossibleFilter
    {
        [TestCase("cat", "at", true)]
        [TestCase("cat", "john", false)]
        public void TestFilter(string anagramString, string word, bool expected)
        {
            var anagram = new SortedAnagram(anagramString);

            var filter = new ImpossibleWordFilter(anagram);

            Assert.AreEqual(expected, filter.Pass(word));
        }
    }
}
