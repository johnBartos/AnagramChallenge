using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using AnagramChallenge;
using AnagramVerifier.Permutator;

namespace AnagramVerifier
{
    public class AnagramHashVerifier : IAnagramVerifier
    {
        private readonly string _solutionHash;
        private readonly IPermutator _wordPermutator;

        public AnagramHashVerifier(IPermutator permutator, string solutionHash)
        {
            _wordPermutator = permutator;
            _solutionHash = solutionHash;
        }

        public bool IsASolution(string anagram, out string solution)
        {
            var hash = GetHash(anagram);
            var permutations = _wordPermutator.Permutate(anagram);

            solution = permutations.FirstOrDefault(x => String.Equals(GetHash(x), _solutionHash, StringComparison.OrdinalIgnoreCase));

            return solution != null;
        }

        private string GetHash(string input)
        {
            using (var md5Hash = MD5.Create())
            {
                var data = md5Hash.ComputeHash(Encoding.ASCII.GetBytes(input));

                var builder = new StringBuilder();

                foreach (var stringByte in data)
                {
                    builder.Append(stringByte.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
