using AnagramFileReader;
using AnagramFinder;
using AnagramTypes;
using AnagramVerifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramSolver
{
    public class RecursiveAnagramSolver : IAnagramSolver
    {
        private readonly IAnagramFileReader _fileReader;
        private readonly IAnagramFinder _finder;
        private readonly IAnagramVerifier _verifier;

        public RecursiveAnagramSolver(IAnagramFileReader fileReader, IAnagramFinder finder, IAnagramVerifier verifier)
        {
            _fileReader = fileReader;
            _finder = finder;
            _verifier = verifier;
        }

        public string Solve(IAnagram anagram, int maxNumberWords)
        {
            var wordList = _fileReader.ReadFileIntoMemory();
            var result = _finder.SolveMaxWords(anagram, wordList, 0, maxNumberWords);

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
