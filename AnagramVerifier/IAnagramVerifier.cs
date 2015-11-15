using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramVerifier
{
    public interface IAnagramVerifier
    {
        bool IsASolution(string anagram);
    }
}
