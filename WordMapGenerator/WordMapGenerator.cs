using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedWordMapGenerator
{
    public class WordMapGenerator : ISortedWordMapGenerator
    {
        public IDictionary<string, IList<string>> GenerateSortedWordMap(IList<string> words)
        {
            var wordMap = new Dictionary<string, IList<string>>();

            foreach(var word in words)
            {
                var sortedWord = SortWord(word);

                if (wordMap.ContainsKey(sortedWord))
                {
                    wordMap[sortedWord].Add(word);
                }
                else
                {
                    var wordList = new List<string> { word };
                    wordMap.Add(sortedWord, wordList);
                }
            }

            return wordMap;
        }

        private string SortWord(string word)
        {
            return String.Concat(word.OrderBy(x => x));
        }
    }
}
