using System;
using AnagramFileReader.WordFilter;
using AnagramTypes;
using NUnit.Framework;

namespace UnitTests.WordFilter
{
    public class TestImpossibleFilter
    {
        [Test]
        public void TestFilterWordContainedWithinAnagram()
        {
            var anagram = new MockAnagram(true);

            var filter = new ImpossibleWordFilter(anagram);
            
            Assert.IsTrue(filter.Pass("anything"));
        }

        [Test]
        public void TestFilterWordNotContainedWithinAnagram()
        {
            var anagram = new MockAnagram(false);

            var filter = new ImpossibleWordFilter(anagram);

            Assert.IsFalse(filter.Pass("anything"));
        }

        internal class MockAnagram : IAnagram
        {
            private readonly bool _shouldContainWord;

            public MockAnagram(bool shouldContainWord)
            {
                _shouldContainWord = shouldContainWord;
            }

            public bool ContainsWord(string word)
            {
                return _shouldContainWord;
            }

            public IAnagram SubtractWord(string word)
            {
                throw new NotImplementedException();
            }

            public int Length
            {
                get { throw new NotImplementedException(); }
            }
        }
    }
}
