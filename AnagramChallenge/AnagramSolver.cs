﻿using System;
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
            if (anagram.Length() == 0)
            {
                Console.WriteLine("Found a solution: {0}", String.Join(" ", currentWords));
                return;
            }

            if(index == wordList.Length)
            {
                Console.WriteLine("Ran out of words");
                return;
            }

            for(var i = index; i <= wordList.Length - 1; i++)
            {
                var currentWord = wordList[i];
                
                if(anagram.ContainsWord(currentWord))
                {
                    var shorterAnagram = anagram.SubtractWord(currentWord);

                    var fitList = new List<string>(currentWords);
                    fitList.Add(currentWord);

                    var next = i + 1;

                    SolveAnagram(shorterAnagram, fitList, wordList, next);
                }
            }
        }
    }
}
