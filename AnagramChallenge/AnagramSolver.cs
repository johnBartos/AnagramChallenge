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

        public IList<IList<string>> SolveAnagram(IAnagram anagram, string[] wordList, int index)
        {
            var solutions = new List<IList<string>>();

            for(var i = index; i <= wordList.Length - 1; i++)
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
    }
}
