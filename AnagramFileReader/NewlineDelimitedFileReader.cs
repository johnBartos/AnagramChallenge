using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AnagramFileReader.WordFilter;

namespace AnagramFileReader
{
    public class NewlineDelimitedFileReader : IAnagramFileReader
    {
        private readonly IList<IWordFilter> _wordFilters;
        private readonly string _path;

        public NewlineDelimitedFileReader(string path, IList<IWordFilter> wordFilters)
        {
            _path = path;
            _wordFilters = wordFilters;
        }
        public string[] ReadFileIntoMemory()
        {
            var lines = File.ReadLines(_path);

            var result = new Dictionary<string, byte>();

            foreach (var line in lines)
            {
                if (!result.ContainsKey(line))
                {
                    if (_wordFilters.All(x => x.Pass(line)))
                    {
                        result.Add(line, 0);
                    }
                }
            }

            return result.Keys.ToArray();
        }
    }
}
