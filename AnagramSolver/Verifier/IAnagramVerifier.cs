namespace AnagramSolver.AnagramVerifier
{
    public interface IAnagramVerifier
    {
        bool IsASolution(string anagram, out string solution);
    }
}
