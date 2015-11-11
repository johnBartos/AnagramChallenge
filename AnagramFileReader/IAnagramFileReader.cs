using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramFileReader
{
    public interface IAnagramFileReader
    {
        IList<string> ReadFileIntoMemory(string path);
    }
}
