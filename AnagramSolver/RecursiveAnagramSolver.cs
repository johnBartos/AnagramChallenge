using System;
using System.Collections.Generic;
using AnagramSolver.Anagram;
using System.Linq;
using System.Threading.Tasks;
using AnagramSolver.Finder;
using AnagramSolver.Permutator;
using AnagramSolver.Verifier;

namespace AnagramSolver
{
    public class RecursiveAnagramSolver : IAnagramSolver
    {
        private readonly IAnagramFinder _finder;
        private readonly IAnagramVerifier _verifier;
        private readonly IPermutator _permutator;

        public RecursiveAnagramSolver(IAnagramFinder finder, IAnagramVerifier verifier, IPermutator permutator)
        {
            _finder = finder;
            _verifier = verifier;
            _permutator = permutator;
        }

        public string Solve(string anagram, string[] wordList)
        {
            var maxNumWords = anagram.Count(x => x == ' ') + 1;
            var anagramToSolve = new SortedAnagram(anagram.Replace(" ", String.Empty));

            var result = _finder.Solve(anagramToSolve, wordList, 0, maxNumWords);

            var solution = String.Empty;
            Parallel.ForEach(result, (potentialSolution, outerState) =>
            {
                var permutations = _permutator.Permutate(potentialSolution);
                Parallel.ForEach(permutations, (p, innerState) =>
                {
                    if (_verifier.IsASolution(p))
                    {
                        solution = p;
                        outerState.Stop();
                        innerState.Stop();
                    }
                });
            });

            return solution;
        }
    }
}
