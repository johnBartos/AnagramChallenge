using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortedWordMapGenerator;
using Newtonsoft.Json;

namespace IntegrationTests
{
    public class TestGenerateSortedWordMapFromFile
    {
        [Test]
        public void TestGenerateMapFromFile()
        {
            var testFilePath = Path.Combine(Directory.GetCurrentDirectory() + @"\testfile.txt");

            var reader = new AnagramFileReader.AnagramFileReader();
            var mapGenerator = new WordMapGenerator();

            var expected = new Dictionary<string, IList<string>>
            {
                {"abt", new List<string> {"bat", "tab"}},
                {"act", new List<string> {"cat", "act"}}
            };

            var words = reader.ReadFileIntoMemory(testFilePath);

            var actual = mapGenerator.GenerateSortedWordMap(words);

            Assert.AreEqual(
             JsonConvert.SerializeObject(expected),
             JsonConvert.SerializeObject(actual));   
        }
    }
}
