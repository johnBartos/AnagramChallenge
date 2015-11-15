using AnagramVerifier;
using AnagramVerifier.Permutator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.AnagramVerifier
{
    public class TestHashVerification
    {
        [Test]
        public void TestThatHashesAreEqual()
        {
            var permutations = new List<string> { "john" };

            var mockPermutator = new MockPermutator(permutations);

            var verifier = new AnagramHashVerifier(mockPermutator, "527bd5b5d689e2c32ae974c6229ff785");

            string actualResult;
            var actual = verifier.IsASolution("john", out actualResult);

            Assert.IsTrue(actual);
            Assert.AreEqual("john", actualResult);
        }
    }

    internal class MockPermutator : IPermutator
    {
        private readonly IList<string> _sentencesToReturn;

        public MockPermutator(IList<string> sentencesToReturn)
        {
            _sentencesToReturn = sentencesToReturn;
        }

        public IList<string> Permutate(string sentence)
        {
            return _sentencesToReturn;
        }
    }
}
