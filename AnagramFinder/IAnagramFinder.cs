using System.Collections.Generic;
using AnagramTypes;

namespace AnagramFinder
{
    public interface IAnagramFinder
    {
        IList<string> Solve(IAnagram anagram, string[] wordList, int index, int maxWords);
    }
}
