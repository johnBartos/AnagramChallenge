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
        private static string AnagramToSolve = "poultry outwits ants";
        private static string Path = @"C:/code/anagramchallenge/wordlist";
        private static string SolutionHash = "4624d200580677270a54ccff86b9610e";

        static void Main(string[] args)
        {
            var startTime = DateTime.Now;

            var anagram = new Anagram(AnagramToSolve.Replace(" ", String.Empty));
            var maxNumWords = AnagramToSolve.Count(x => x == ' ') + 1;

            var fileReader = new AnagramFileReader.AnagramFileReader(new List<IWordFilter> { new ImpossibleWordFilter(anagram) } );
            var wordList = fileReader.ReadFileIntoMemory(Path);
            
            var solver = new AnagramSolver();
            var result = solver.SolveMaxWords(anagram, wordList, 0, maxNumWords);

            var hashVerifier = new AnagramHashVerifier(new WordPermutator(), SolutionHash);

            string solution;
            foreach(var anagramString in result)
            {
                if(hashVerifier.IsASolution(anagramString, out solution))
                {
                    Console.WriteLine("The solution is {0}", solution);
                    Console.WriteLine("It took {0} to find the solution", DateTime.Now - startTime);
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}
