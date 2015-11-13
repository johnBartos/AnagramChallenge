using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramChallenge
{
    public class Anagram : IAnagram
    {
        private string _anagram { get; set; }

        public Anagram(string anagram)
        {
            _anagram = anagram;
        }

        public bool ContainsWord(string word)
        {
            var wordAsChars= word.ToCharArray();

            return _anagram.IndexOfAny(wordAsChars) != -1;   
        }

        public IAnagram SubtractWord(string word)
        {
            var wordAsChars = word.ToCharArray();
            var anagramCharList = _anagram.ToList();

            foreach(var wordChar in wordAsChars)
            {
                anagramCharList.Remove(wordChar);
            }

            return new Anagram(String.Join("", anagramCharList));
        }

        public int Length()
        {
            return _anagram.Length;
        }

        public override string ToString()
        {
            return _anagram.ToString();
        }
    }
}
