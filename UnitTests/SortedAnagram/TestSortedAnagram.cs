using AnagramTypes;
using NUnit.Framework;

namespace UnitTests
{
    public class TestAnagram
    {
        [Test]
        public void TestContainsWord()
        {
            var anagram = new SortedAnagram("act");
            var word = "cat";

            Assert.IsTrue(anagram.ContainsWord(word));
        }

        [Test]
        public void TestDoesnContainWord()
        {
            var anagram = new SortedAnagram("blu");
            var word = "blue";

            Assert.IsFalse(anagram.ContainsWord(word));
        }

        [Test]
        public void TestDoesnContainRepeatedChars()
        {
            var anagram = new SortedAnagram("act");
            var word = "aa";

            Assert.IsFalse(anagram.ContainsWord(word));
        }

        [Test]
        public void TestSubtractWord()
        {
            var anagram = new SortedAnagram("lolcat");
            var word = "cat";

            var expected = "llo";
            var actual = anagram.SubtractWord(word);

            Assert.AreEqual(expected, actual.ToString());
        }
    }
}
