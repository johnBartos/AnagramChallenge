using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnagramTypes;

namespace AnagramFinder
{
    public interface IAnagramFinder
    {
        IList<string> Solve(IAnagram anagram, string[] wordList, int index);
        IList<string> SolveMaxWords(IAnagram anagram, string[] wordList, int index, int maxWords);
    }
}
