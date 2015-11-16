using System.Collections.Generic;

namespace AnagramVerifier.Permutator
{
    public interface IPermutator
    {
        IList<string> Permutate(string sentence);
    }
}
