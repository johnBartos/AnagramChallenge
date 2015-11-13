using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnagramChallenge;
using AnagramFileReader;
using AnagramFileReader.WordFilter;
namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var anagram = new Anagram("poultry outwits ants");

            var path = @"C:/code/anagramchallenge/wordlist";
            var fileReader = new AnagramFileReader.AnagramFileReader(new ImpossibleWordFilter(anagram));
            var wordList = fileReader.ReadFileIntoMemory(path);
            
            var solver = new AnagramSolver();

            solver.SolveAnagram(anagram, new List<string>(), wordList, 0);

            Console.ReadKey();
        }
    }
}
