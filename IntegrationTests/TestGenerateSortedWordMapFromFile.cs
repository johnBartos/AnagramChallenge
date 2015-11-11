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
    //Todo: create test file in memory/as a temp

    public class TestGenerateSortedWordMapFromFile
    {
        [Test]
        public void TestGenerateMapFromFile_SmallFile()
        {
            var testFilePath = Path.Combine(Directory.GetCurrentDirectory() + @"\testfile.txt");

            var expected = new Dictionary<string, IList<string>>
            {
                {"abt", new List<string> {"bat", "tab"}},
                {"act", new List<string> {"cat", "act"}}
            };

            var actual = GenerateMap(testFilePath, expected);

            Assert.AreEqual(
             JsonConvert.SerializeObject(expected),
             JsonConvert.SerializeObject(actual));
        }

        [Test]
        public void TestGenerateMapFromFile_LargeFile()
        {
            var testFilePath = @"C:\Code\AnagramChallenge\wordlist";

            var expected = new Dictionary<string, IList<string>>
            {
                {"abt", new List<string> {"bat", "tab"}},
                {"act", new List<string> {"cat", "act"}}
            };

            var actual = GenerateMap(testFilePath, expected);

            Assert.IsNotEmpty(actual);
        }

        private IDictionary<string, IList<string>> GenerateMap(string testFilePath, IDictionary<string, IList<string>> expected)
        {
            var reader = new AnagramFileReader.AnagramFileReader();
            var mapGenerator = new WordMapGenerator();

            var words = reader.ReadFileIntoMemory(testFilePath);

            return mapGenerator.GenerateSortedWordMap(words);
        }
    }
}
