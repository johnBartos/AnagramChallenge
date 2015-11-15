using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramChallenge
{
    public class AnagramSolver : IAnagramSolver
    {
        private IDictionary<string, IList<IList<string>>> _dynamicMap = new Dictionary<string, IList<IList<string>>>();

        public IList<IList<string>> SolveAnagram(IAnagram anagram, string[] wordList, int index)
        {
            var solutions = new List<IList<string>>();

            for (var i = index; i <= wordList.Length - 1; i++)
            {
                IList<IList<string>> solution = new List<IList<string>>();
                var currentWord = wordList[i];
                var next = i + 1;
                if (anagram.ContainsWord(currentWord))
                {
                    var shorterAnagram = anagram.SubtractWord(currentWord);

                    if (shorterAnagram.Length() == 0)
                    {
                        solution = new List<IList<string>> { new List<string> { currentWord } };
                    }
                    else
                    {
                        solution = SolveAnagram(shorterAnagram, wordList, next);
                        foreach (var s in solution)
                        {
                            if (s.Count > 0)
                            {
                                s.Add(currentWord);
                            }
                        }
                    }
                }
                solutions.AddRange(solution);
            }
            return solutions;
        }

        private IDictionary<string, IList<string>> _dynamicMapString = new Dictionary<string, IList<string>>();

        public IList<string> SolveAnagramDynamicString(IAnagram anagram, string[] wordList, int index)
        {
            if(_dynamicMapString.ContainsKey(anagram.ToString()))
            {
                return _dynamicMapString[anagram.ToString()];
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
                        solution = SolveAnagramDynamicString(shorterAnagram, wordList, next);

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

            if (solutions.Count > 0 && !_dynamicMapString.ContainsKey(anagram.ToString()))
            {
                _dynamicMapString.Add(anagram.ToString(), solutions);
            }

            return solutions;
        }
    }
}
