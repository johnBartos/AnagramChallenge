using System.Collections.Generic;

namespace AnagramSolver.AnagramVerifier.Permutator
{
    public interface IPermutator
    {
        IList<string> Permutate(string sentence);
    }
}
