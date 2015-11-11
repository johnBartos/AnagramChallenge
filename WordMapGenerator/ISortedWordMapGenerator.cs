using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMapGenerator
{
    public interface ISortedWordMapGenerator
    {
        IDictionary<string, List<string>> GenerateSortedWordMap(IList<string> words);
    }
}
