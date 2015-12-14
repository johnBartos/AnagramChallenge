using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AnagramSolver.Verifier
{
    public class AnagramHashVerifier : IAnagramVerifier
    {
        private readonly string _solutionHash;

        public AnagramHashVerifier( string solutionHash)
        {
            _solutionHash = solutionHash;
        }

        public bool IsASolution(string anagram)
        {
            return String.Equals(_solutionHash, GetHash(anagram), StringComparison.InvariantCultureIgnoreCase);
        }
        
        private string GetHash(string input)
        {
            using (var hasher = MD5.Create())
            {
                var data = hasher.ComputeHash(Encoding.ASCII.GetBytes(input));
                return BitConverter.ToString(data).Replace("-", "");
            }
        }
    }
}
