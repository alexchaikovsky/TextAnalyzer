using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer.Filters
{
    public interface IFilter
    {
        bool CheckWordValid(string word);
    }
}
