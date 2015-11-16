using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnagramFileReader;
using AnagramFileReader.WordFilter;
using AnagramVerifier;
using AnagramVerifier.Permutator;
using AnagramFinder;
using AnagramTypes;
using AnagramSolver;

namespace ConsoleHost
{
    class Program
    {
        private static string AnagramToSolve = "poultry outwits ants";
        private static string SolutionHash = "4624d200580677270a54ccff86b9610e";

        static void Main(string[] args)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory() + @"\wordlist");

            var anagram = new SortedAnagram(AnagramToSolve.Replace(" ", String.Empty));
            var maxNumWords = AnagramToSolve.Count(x => x == ' ') + 1;

            var fileReader = new NewlineDelimitedFileReader(path, new List<IWordFilter> { new ImpossibleWordFilter(anagram) } );
            var finder = new RecursiveAnagramFinder();
            var verifier = new AnagramHashVerifier(new WordPermutator(), SolutionHash);

            var solver = new RecursiveAnagramSolver(fileReader, finder, verifier);

            var startTime = DateTime.Now;

            var solution = solver.Solve(anagram, maxNumWords);

            Console.WriteLine("The solution is {0}", solution);
            Console.WriteLine("It took {0} to find the solution", DateTime.Now - startTime);

            Console.ReadKey();
        }
    }
}
