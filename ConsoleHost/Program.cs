using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnagramChallenge;
using AnagramFileReader;
using AnagramFileReader.WordFilter;
using AnagramVerifier;
using AnagramVerifier.Permutator;

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

            var result = solver.Solve(anagram, wordList, 0);

            var hashVerifier = new AnagramHashVerifier(new WordPermutator(), "4624d200580677270a54ccff86b9610e");

            string solution;
            foreach(var anagramString in result)
            {
                if(hashVerifier.IsASolution(anagramString, out solution))
                {
                    Console.WriteLine("The solution is {0}", solution);
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}
//pastils towy turnout