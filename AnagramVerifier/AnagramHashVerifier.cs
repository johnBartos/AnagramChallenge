using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using AnagramChallenge;

namespace AnagramVerifier
{
    public class AnagramHashVerifier : IAnagramVerifier
    {
        private readonly string _solutionHash;

        public AnagramHashVerifier(string solutionHash)
        {
            _solutionHash = solutionHash;
        }

        public bool IsASolution(string anagram)
        {
            using(var md5Hash = MD5.Create())
            {
                var hash = GetHash(md5Hash, anagram);

                return String.Equals(hash, _solutionHash, StringComparison.OrdinalIgnoreCase);
            }
        }

        private string GetHash(MD5 md5Hash, string input)
        {
            var data = md5Hash.ComputeHash(Encoding.ASCII.GetBytes(input));

            var builder = new StringBuilder();

            foreach(var stringByte in data)
            {
                builder.Append(stringByte.ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
