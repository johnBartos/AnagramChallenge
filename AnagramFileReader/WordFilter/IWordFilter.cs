using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramFileReader.WordFilter
{
    public interface IWordFilter
    {
        bool Pass(string word);
    }
}
