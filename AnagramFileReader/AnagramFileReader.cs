using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AnagramFileReader.WordFilter;

namespace AnagramFileReader
{
    public class AnagramFileReader : IAnagramFileReader
    {
        private IList<IWordFilter> _wordFilters;

        public AnagramFileReader(IList<IWordFilter> wordFilters)
        {
            _wordFilters = wordFilters;
        }
        public string[] ReadFileIntoMemory(string path)
        {
            var lines = File.ReadLines(path);

            var result = new List<string>();

            foreach (var line in lines)
            {
                if(_wordFilters.All(x => x.Pass(line)))
                {
                    result.Add(line);
                }
            }

            return result.ToArray();
        }
    }
}
