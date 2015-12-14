using System.Collections.Generic;
using AnagramSolver.Anagram;

namespace AnagramSolver.Finder
{
    public interface IAnagramFinder
    {
        IList<string> Solve(IAnagram anagram, string[] wordList, int index, int maxWords);
    }
}
