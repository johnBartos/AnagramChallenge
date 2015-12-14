using System.Collections.Generic;
using AnagramSolver.Permutator;
using AnagramSolver.Verifier;
using NUnit.Framework;

namespace UnitTests.AnagramVerifier
{
    public class TestHashVerification
    {
        [Test]
        public void TestThatHashesAreEqual()
        {
            var verifier = new AnagramHashVerifier("527bd5b5d689e2c32ae974c6229ff785");

            var actual = verifier.IsASolution("john");

            Assert.IsTrue(actual);
        }
    }
}
