using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramTypes
{
    public class SortedAnagram : IAnagram
    {
        private string _anagram { get; set; }

        public SortedAnagram(string anagram)
        {
            _anagram = anagram;
        }

        public int Length
        {
            get { return _anagram.Length; }
        }

        public bool ContainsWord(string word)
        {
            var wordAsChars = word.ToList();
            var anagramCharList = _anagram.ToList();

            foreach (var wordChar in wordAsChars)
            {
                if(!anagramCharList.Remove(wordChar))
                {
                    return false;
                }
            }

            return true;
        }

        public IAnagram SubtractWord(string word)
        {
            var wordAsChars = word.ToList();
            var anagramCharList = _anagram.ToList();

            foreach(var wordChar in wordAsChars)
            {
                anagramCharList.Remove(wordChar);
            }

            return new SortedAnagram(String.Join("", anagramCharList));
        }


        public override string ToString()
        {
            return String.Concat(_anagram.OrderBy(x => x));
        }
    }
}
