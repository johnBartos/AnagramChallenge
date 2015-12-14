using System;
using System.Linq;

namespace AnagramSolver.Anagram
{
    public class SortedAnagram : IAnagram
    {
        private string Anagram { get; set; }

        public SortedAnagram(string anagram)
        {
            Anagram = anagram;
        }

        public int Length
        {
            get { return Anagram.Length; }
        }

        public bool ContainsWord(string word)
        {
            var wordAsChars = word.ToList();
            var anagramCharList = Anagram.ToList();

            return wordAsChars.All(wordChar => anagramCharList.Remove(wordChar));
        }

        public IAnagram SubtractWord(string word)
        {
            var wordAsChars = word.ToList();
            var anagramCharList = Anagram.ToList();

            foreach(var wordChar in wordAsChars)
            {
                anagramCharList.Remove(wordChar);
            }

            return new SortedAnagram(String.Join("", anagramCharList));
        }

        public override string ToString()
        {
            return String.Concat(Anagram.OrderBy(x => x));
        }
    }
}
