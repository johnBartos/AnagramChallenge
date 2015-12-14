using System;
using System.Collections.Generic;
using AnagramSolver.AnagramFinder;
using AnagramSolver.Anagram;
using AnagramSolver.AnagramVerifier;
using AnagramSolver.AnagramFinder.WordFilter;
using System.Linq;

namespace AnagramSolver
{
    public class RecursiveAnagramSolver : IAnagramSolver
    {
        private readonly IAnagramFinder _finder;
        private readonly IAnagramVerifier _verifier;

        public RecursiveAnagramSolver(IAnagramFinder finder, IAnagramVerifier verifier)
        {
            _finder = finder;
            _verifier = verifier;
        }

        public string Solve(string anagram, string[] wordList)
        {
            var maxNumWords = anagram.Count(x => x == ' ') + 1;
            var anagramToSolve = new SortedAnagram(anagram.Replace(" ", String.Empty));
            wordList = wordList.Where(x => new ImpossibleWordFilter(anagramToSolve).Pass(x)).ToArray();

            var result = _finder.Solve(anagramToSolve, wordList, 0, maxNumWords);

            string solution = String.Empty;
            foreach (var anagramString in result)
            {
                if (_verifier.IsASolution(anagramString, out solution))
                {
                    break;
                }
            }

            return solution;
        }
    }
}
