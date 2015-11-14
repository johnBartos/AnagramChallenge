using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramChallenge
{
    public interface IAnagramSolver
    {
        IList<IList<string>> SolveAnagram(IAnagram anagram, string[] wordList, int index);
    }
}
