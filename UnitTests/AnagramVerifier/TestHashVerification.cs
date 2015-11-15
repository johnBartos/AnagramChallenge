using AnagramVerifier;
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
            var verifier = new AnagramHashVerifier("527bd5b5d689e2c32ae974c6229ff785");

            Assert.IsTrue(verifier.IsASolution("john"));
        }
    }
}
