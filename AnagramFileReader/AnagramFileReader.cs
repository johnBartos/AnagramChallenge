using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramFileReader
{
    public class AnagramFileReader : IAnagramFileReader
    {
        public IDictionary<string, byte> ReadFileIntoMemory(string path)
        {
            var result = new Dictionary<string, byte>();

            return result;
        }
    }
}
