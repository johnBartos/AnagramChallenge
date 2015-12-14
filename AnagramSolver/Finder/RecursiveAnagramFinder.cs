using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnagramSolver.Anagram;

namespace AnagramSolver.Finder
{
    public class RecursiveAnagramFinder : IAnagramFinder
    {
        private readonly ConcurrentDictionary<string, IList<string>> _dynamicMap = new ConcurrentDictionary<string, IList<string>>();
  
        public IList<string> Solve(IAnagram anagram, string[] wordList, int maxWords)
        {
            if (maxWords == 0)
            {
                return new List<string>();
            }

            if (_dynamicMap.ContainsKey(anagram.ToString()))
            {
                return _dynamicMap[anagram.ToString()];
            }

            var containingWordList = wordList.Where(x => (anagram.ContainsWord(x))).ToArray();
            var solutions = new ConcurrentBag<string>();

            Parallel.For(0, containingWordList.Length - 1, i =>
            {
                var currentWord = containingWordList[i];
                var shorterAnagram = anagram.SubtractWord(currentWord);

                var solution = (shorterAnagram.Length == 0) 
                    ? new List<string> {currentWord} 
                    : ConcatList(currentWord,
                        Solve(shorterAnagram, containingWordList.Skip(i + 1).ToArray(), maxWords - 1));

                foreach (var s in solution)
                {
                    solutions.Add(s);
                }
            });

            var solutionsList = solutions.ToList();

            if (solutions.Count > 0)
            {
                _dynamicMap.TryAdd(anagram.ToString(), solutionsList);
            }

            return solutionsList;
        }

        private IList<string> ConcatList(string word, IList<string> solution)
        {
            var newWordDictionary = new Dictionary<string, string>();

            foreach (var s in solution)
            {
                var sortedWord = String.Concat(s.OrderBy(x => x));
                if (!newWordDictionary.ContainsKey(sortedWord))
                {
                    newWordDictionary.Add(sortedWord, String.Concat(word, " ", s));
                }
            }

            return newWordDictionary.Values.ToList();
        }
    }

}
