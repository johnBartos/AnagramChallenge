using AnagramTypes;

namespace AnagramSolver
{
    public interface IAnagramSolver
    {
        string Solve(IAnagram anagram, int maxDepth);
    }
}
