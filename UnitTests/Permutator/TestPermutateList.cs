using System.Collections.Generic;
using AnagramSolver.AnagramVerifier.Permutator;
using Newtonsoft.Json;
using NUnit.Framework;

namespace UnitTests.Permutator
{
    public class TestPermutateList
    {
        [Test]
        public void TestPermutate()
        {
            var words = "a b c";

            var permutator = new WordPermutator();

            var expected = new List<string> {
                "a b c",
                "a c b",
                "b a c",
                "b c a",
                "c b a",
                "c a b"
            };

            var actual = permutator.Permutate(words);

            Assert.AreEqual(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));
        }
    }
}
