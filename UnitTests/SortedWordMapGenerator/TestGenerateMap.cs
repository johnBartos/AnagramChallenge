using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortedWordMapGenerator;
using Newtonsoft.Json;

namespace UnitTests.SortedWordMapGenerator
{
    public class TestGenerateMap
    {
        [Test]
        public void TestGenerateWordMap()
        {
            var wordList = new List<string> { "the", "het", "cat", "act" };

            var wordMapGenerator = new WordMapGenerator();

            var expected = new Dictionary<string, IList<string>>
            {
                {"eht", new List<string> {"the", "het"}},
                {"act", new List<string> {"cat", "act"}}
            };

            var actual = wordMapGenerator.GenerateSortedWordMap(wordList);

            Assert.AreEqual(
             JsonConvert.SerializeObject(expected),
             JsonConvert.SerializeObject(actual));
        }
    }
}
