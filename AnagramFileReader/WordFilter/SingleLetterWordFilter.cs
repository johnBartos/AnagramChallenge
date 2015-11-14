using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramFileReader.WordFilter
{
    public class SingleLetterWordFilter : IWordFilter
    {
        private List<string> _allowedWords = new List<string> { "a", "i", "o" };

        public bool Pass(string word)
        {
            if(word.Length == 1)
            {
                foreach (var allowedWord in _allowedWords)
                {
                    if (String.Equals(word, allowedWord, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
