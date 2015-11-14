using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramChallenge
{
    public interface IAnagramSolver
    {
        void SolveAnagram(IAnagram anagram, IList<string> currentWords, string[] wordList, int index, IList<IList<string>> results);
    }
}
