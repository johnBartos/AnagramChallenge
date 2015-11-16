using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramChallenge
{
    public interface IAnagramSolver
    {
        IList<string> Solve(IAnagram anagram, string[] wordList, int index);
        IList<string> SolveMaxWords(IAnagram anagram, string[] wordList, int index, int maxWords);
    }
}
