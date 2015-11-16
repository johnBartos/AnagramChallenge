using AnagramTypes;

namespace AnagramFileReader.WordFilter
{
    public class ImpossibleWordFilter : IWordFilter
    {
        private readonly IAnagram _anagram;

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
