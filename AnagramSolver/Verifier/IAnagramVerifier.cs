using System.Collections.Generic;

namespace AnagramSolver.Verifier
{
    public interface IAnagramVerifier
    {
        bool IsASolution(string anagram);
    }
}
