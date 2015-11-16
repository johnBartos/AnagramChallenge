using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramTypes
{
    public interface IAnagram
    {
        bool ContainsWord(string word);
        IAnagram SubtractWord(string word);
        int Length { get; }
        string ToString();
    }
}
