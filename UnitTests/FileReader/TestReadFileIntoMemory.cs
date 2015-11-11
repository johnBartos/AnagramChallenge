using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace UnitTests.FileReader
{
    public class TestReadFileIntoMemory
    {
        [Test]
        public void TestReadFile()
        {
            var testFilePath = Path.Combine(Directory.GetCurrentDirectory() + @"\FileReader\testfile.txt");
                        
            var reader = new AnagramFileReader.AnagramFileReader();

            var expected = new List<string>
            {
                "test","file"
            };

            var actual = reader.ReadFileIntoMemory(testFilePath);

            Assert.AreEqual(
                JsonConvert.SerializeObject(expected),
                JsonConvert.SerializeObject(actual));
        }
    }
}
