namespace AnagramSolver.Anagram
{
    public interface IAnagram
    {
        bool ContainsWord(string word);
        IAnagram SubtractWord(string word);
        int Length { get; }
        string ToString();
    }
}
