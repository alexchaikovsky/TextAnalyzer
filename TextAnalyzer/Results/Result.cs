using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAnalyzer.Filters;

namespace TextAnalyzer.Results
{
    public class Result : IResult
    {
        Dictionary<string, int> _result = new Dictionary<string, int>();
        readonly FilterList _filterList;
        public Result(FilterList filterList)
        {
            _filterList = filterList;
        }
        public void AddWord(string word, int count = 1)
        {
            if (_result.ContainsKey(word))
            {
                _result[word] += count;
                return;
            }
            _result[word] = count;
        }

        public IEnumerator<KeyValuePair<string, int>> GetEnumerator() => _result.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Merge(IResult another)
        {
            foreach (var entry in another)
            {
                AddWord(entry.Key, entry.Value);
            }
        }
        public void RunFilter()
        {
            foreach(IFilter filter in _filterList)
            {
                _result = _result.Where(pair => filter.CheckWordValid(pair.Key)).ToDictionary(pair => pair.Key, pair => pair.Value);
            }
        }
        public void OrderAndCut(int n)
        {
            _result = _result.OrderByDescending(pair => pair.Value).SkipLast(_result.Count - n).ToDictionary(pair=> pair.Key, pair => pair.Value);
        }
    }
}
