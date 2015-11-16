using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using AnagramFileReader;
using AnagramFileReader.WordFilter;

namespace UnitTests.FileReader
{
    //Todo: create test file in memory/as a temp
    public class TestReadFileIntoMemory
    {
        [Test]
        public void TestReadFile()
        {
            var testFilePath = Path.Combine(Directory.GetCurrentDirectory() + @"\FileReader\testfile.txt");
                        
            var reader = new AnagramFileReader.NewlineDelimitedFileReader(testFilePath, new List<IWordFilter> { new MockWordFilter() });

            var expected = new string[] { "test", "file" };

            var actual = reader.ReadFileIntoMemory();

            Assert.AreEqual(
                JsonConvert.SerializeObject(expected),
                JsonConvert.SerializeObject(actual));
        }
    }

    internal class MockWordFilter : IWordFilter
    {
        public bool Pass(string word)
        {
            return true;
        }
    }
}
