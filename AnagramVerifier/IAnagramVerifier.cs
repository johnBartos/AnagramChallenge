namespace AnagramVerifier
{
    public interface IAnagramVerifier
    {
        bool IsASolution(string anagram, out string solution);
    }
}
