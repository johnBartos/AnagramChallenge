using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnagramVerifier.Permutator;
using Newtonsoft.Json;

namespace UnitTests.Permutator
{
    public class TestPermutateList
    {
        [Test]
        public void TestPermutate()
        {
            var words = "pastils towy turnout";

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
