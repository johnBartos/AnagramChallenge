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
            var anagram = new Anagram("poultryoutwitsants");

            var path = @"C:/code/anagramchallenge/wordlist";
            var fileReader = new AnagramFileReader.AnagramFileReader(new List<IWordFilter> { new ImpossibleWordFilter(anagram), new SingleLetterWordFilter() } );
            var wordList = fileReader.ReadFileIntoMemory(path);
            
            var solver = new AnagramSolver();
            var results = new List<IList<string>>();

            var result = solver.SolveAnagram(anagram, wordList, 0);

            Console.ReadKey();
        }
    }
}
