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
        public IDictionary<string, byte> ReadFileIntoMemory(string path)
        {
            var result = new Dictionary<string, byte>();

            var lines = File.ReadLines(path);

            foreach(var line in lines)
            {
                if(!result.ContainsKey(line))
                {
                    result.Add(line, 0);
                }
            }

            return result;
        }
    }
}
