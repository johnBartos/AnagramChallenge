using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramChallenge
{
    public class AnagramSolver : IAnagramSolver
    {
        private IDictionary<string, IList<string>> _dynamicMap = new Dictionary<string, IList<string>>();

        public IList<string> Solve(IAnagram anagram, string[] wordList, int index)
        {
            if(_dynamicMap.ContainsKey(anagram.ToString()))
            {
                return _dynamicMap[anagram.ToString()];
            }

            var solutions = new List<string>();

            for (var i = index; i <= wordList.Length - 1; i++)
            {
                IList<string> solution;

                var currentWord = wordList[i];
                var next = i + 1;

                if (anagram.ContainsWord(currentWord))
                {
                    var shorterAnagram = anagram.SubtractWord(currentWord);

                    if (shorterAnagram.Length() == 0)
                    {
                        solution = new List<string> { currentWord };
                    }
                    else
                    {
                        solution = Solve(shorterAnagram, wordList, next);

                        var newWordDictionary = new Dictionary<string, byte>();
                        var newWordList = new List<string>();

                        foreach (var s in solution)
                        {
                            var sortedWord = String.Concat(s.OrderBy(x => x));
                            if (!newWordDictionary.ContainsKey(sortedWord))
                            {
                                newWordList.Add(String.Concat(currentWord, " ", String.Join(" ", s)));
                                newWordDictionary.Add(sortedWord, 0);
                            }
                        }

                        solution = newWordList;
                    }
                    solutions.AddRange(solution);
                }
            }

            if (solutions.Count > 0 && !_dynamicMap.ContainsKey(anagram.ToString()))
            {
                _dynamicMap.Add(anagram.ToString(), solutions);
            }

            return solutions;
        }


        public IList<string> SolveMaxWords(IAnagram anagram, string[] wordList, int index, int maxDepth)
        {
            if(maxDepth == 0)
            {
                return new List<string>();
            }

            if (_dynamicMap.ContainsKey(anagram.ToString()))
            {
                return _dynamicMap[anagram.ToString()];
            }

            var solutions = new List<string>();

            for (var i = index; i <= wordList.Length - 1; i++)
            {
                IList<string> solution;

                var currentWord = wordList[i];
                var next = i + 1;

                if (anagram.ContainsWord(currentWord))
                {
                    var shorterAnagram = anagram.SubtractWord(currentWord);

                    if (shorterAnagram.Length() == 0)
                    {
                        solution = new List<string> { currentWord };
                    }
                    else
                    {
                        solution = SolveMaxWords(shorterAnagram, wordList, next, maxDepth - 1);

                        var newWordDictionary = new Dictionary<string, byte>();
                        var newWordList = new List<string>();

                        foreach (var s in solution)
                        {
                            var sortedWord = String.Concat(s.OrderBy(x => x));
                            if (!newWordDictionary.ContainsKey(sortedWord))
                            {
                                newWordList.Add(String.Concat(currentWord, " ", String.Join(" ", s)));
                                newWordDictionary.Add(sortedWord, 0);
                            }
                        }

                        solution = newWordList;
                    }
                    solutions.AddRange(solution);
                }
            }

            if (solutions.Count > 0 && !_dynamicMap.ContainsKey(anagram.ToString()))
            {
                _dynamicMap.Add(anagram.ToString(), solutions);
            }

            return solutions;
        }
    }
}
