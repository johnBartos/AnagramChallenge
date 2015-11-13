using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramChallenge
{
    public class AnagramSolver : IAnagramSolver
    {
        public void SolveAnagram(IAnagram anagram, IList<string> currentWords, string[] wordList, int index)
        {
            if(index == wordList.Length - 1)
            {
                return;
            }

            if(anagram.Length() == 0)
            {
                Console.WriteLine("Found a solution: {0}", String.Join(" ", currentWords));
                return;
            }

            for(var i = index; i <= wordList.Length - 1; i++)
            {
                var currentWord = wordList[i];
                
                if(anagram.ContainsWord(currentWord))
                {
                    anagram.SubtractWord(currentWord);
                    currentWords.Add(currentWord);
                    SolveAnagram(anagram, currentWords, wordList, i);
                }
            }

            Console.WriteLine("Reached end of list");
        }
    }
}
