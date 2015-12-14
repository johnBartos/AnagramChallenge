using System;
using System.Collections.Generic;

namespace AnagramSolver.Permutator
{
    public class WordPermutator : IPermutator
    {
        public IList<string> Permutate(string sentence)
        {
            var results = new List<string>();
            var wordList = sentence.Split(' ');
            Permutate(wordList, 0, wordList.Length - 1, results);

            return results;
        }

        private void Permutate(IList<string> words, int start, int end, IList<string> results)
        {
            if(start == end)
            {
                results.Add(String.Join(" ", words));
            }
            else
            {
                for(var i = start; i <= end; i++)
                {
                    Swap(words, start, i);
                    Permutate(words, start + 1, end, results);
                    Swap(words, start, i);
                }
            }
        }

        private void Swap(IList<string> words, int first, int second)
        {
            var temp = words[first];
            words[first] = words[second];
            words[second] = temp;
        }
    }
}
