using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AnagramSolver;
using AnagramSolver.AnagramFinder;
using AnagramSolver.AnagramVerifier;
using AnagramSolver.AnagramVerifier.Permutator;


namespace ConsoleHost
{
    class Program
    {
        private const string AnagramToSolve = "poultry outwits ants";
        private const string SolutionHash = "4624d200580677270a54ccff86b9610e";

        static void Main(string[] args)
        {
            var solver = new RecursiveAnagramSolver(
                new RecursiveAnagramFinder(),
                new AnagramHashVerifier(new WordPermutator(), SolutionHash));

            var startTime = DateTime.Now;

            var wordList = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory() + @"\wordlist")).ToArray();
            var solution = solver.Solve(AnagramToSolve, wordList);

            Console.WriteLine("The solution is {0}", solution);
            Console.WriteLine("It took {0} to find the solution", DateTime.Now - startTime);

            Console.ReadKey();
        }
    }
}
