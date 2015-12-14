using System.Collections.Generic;

namespace AnagramSolver.Permutator
{
    public interface IPermutator
    {
        IList<string> Permutate(string sentence);
    }
}
