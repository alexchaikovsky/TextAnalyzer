using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer.Results
{
    public interface IResult : IEnumerable <KeyValuePair<string, int>>
    {
        void AddWord(string word, int count = 1);
        void Merge(IResult another);
        void RunFilter();
        void OrderAndCut(int n);
    }
}
