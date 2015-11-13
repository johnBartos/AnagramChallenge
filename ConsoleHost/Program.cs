using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnagramChallenge;
using AnagramFileReader;

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:/code/anagramchallenge/wordlist";
            var fileReader = new AnagramFileReader.AnagramFileReader();
            var wordList = fileReader.ReadFileIntoMemory(path);

            var anagram = new Anagram("poultry outwits ants");

            var solver = new AnagramSolver();

            solver.SolveAnagram(anagram, new List<string>(), wordList, 0);

            Console.ReadKey();
        }
    }
}
