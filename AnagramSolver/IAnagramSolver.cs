using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnagramTypes;

namespace AnagramSolver
{
    public interface IAnagramSolver
    {
        string Solve(IAnagram anagram, int maxDepth);
    }
}
