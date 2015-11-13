using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramChallenge
{
    public interface IAnagram
    {
        bool ContainsWord(string word);
        IAnagram SubtractWord(string word);
        int Length();
    }
}
