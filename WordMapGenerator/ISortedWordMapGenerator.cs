using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedWordMapGenerator
{
    public interface ISortedWordMapGenerator
    {
        IDictionary<string, IList<string>> GenerateSortedWordMap(IList<string> words);
    }
}
