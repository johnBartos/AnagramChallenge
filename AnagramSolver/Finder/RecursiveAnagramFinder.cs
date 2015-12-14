using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnagramSolver.Anagram;

namespace AnagramSolver.Finder
{
    public class RecursiveAnagramFinder : IAnagramFinder
    {
        private readonly IDictionary<string, IList<string>> _dynamicMap = new Dictionary<string, IList<string>>();

        public IList<string> Solve(IAnagram anagram, string[] wordList, int index, int maxWords)
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
            var solutions = new List<string>();
            Parallel.For(0, containingWordList.Length - 1, i =>
            {
                var currentWord = containingWordList[i];
                var shorterAnagram = anagram.SubtractWord(currentWord);

                IList<string> solution;
                if (shorterAnagram.Length == 0)
                {
                    solution = new List<string> {currentWord};
                }
                else
                {
                    solution = ConcatList(currentWord,
                        Solve(shorterAnagram, containingWordList.Skip(i + 1).ToArray(), i + 1, maxWords - 1));
                }
                solutions.AddRange(solution);
            });

            if (solutions.Count > 0 && !_dynamicMap.ContainsKey(anagram.ToString()))
            {
                _dynamicMap.Add(anagram.ToString(), solutions);
            }

            return solutions;
        }

        private IList<string> ConcatList(string word, IList<string> solution)
        {
            var newWordDictionary = new Dictionary<string, string>();

            foreach (var s in solution)
            {
                if (s != null)
                {
                    var sortedWord = String.Concat(s.OrderBy(x => x));
                    if (!newWordDictionary.ContainsKey(sortedWord))
                    {
                        newWordDictionary.Add(sortedWord, String.Concat(word, " ", s));
                    }
                }
            }

            return newWordDictionary.Values.ToList();
        }
    }

}
