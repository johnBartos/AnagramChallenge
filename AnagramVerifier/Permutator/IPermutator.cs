using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramVerifier.Permutator
{
    public interface IPermutator
    {
        IList<string> Permutate(string sentence);
    }
}
