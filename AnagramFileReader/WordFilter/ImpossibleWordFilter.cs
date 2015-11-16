using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnagramTypes;

namespace AnagramFileReader.WordFilter
{
    public class ImpossibleWordFilter : IWordFilter
    {
        private IAnagram _anagram;

        public ImpossibleWordFilter(IAnagram anagram)
        {
            _anagram = anagram;
        }

        public bool Pass(string word)
        {
            return _anagram.ContainsWord(word);
        }
    }
}
