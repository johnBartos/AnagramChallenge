using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AnagramFileReader
{
    public class AnagramFileReader : IAnagramFileReader
    {
        public IList<string> ReadFileIntoMemory(string path)
        {
            var lines = File.ReadAllLines(path);

            return lines.ToList();
        }
    }
}
