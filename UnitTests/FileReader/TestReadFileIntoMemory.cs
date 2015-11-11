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

            var expected = new Dictionary<string, byte> 
            {
                {"test", 0},
                {"file", 0}
            };

            var actual = reader.ReadFileIntoMemory(testFilePath);

            Assert.AreEqual(
                JsonConvert.SerializeObject(expected),
                JsonConvert.SerializeObject(actual));
        }
    }
}
