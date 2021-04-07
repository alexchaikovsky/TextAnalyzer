using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAnalyzer.Results;

namespace TextAnalyzer.Filters
{
    public class FilterList : IEnumerable
    {
        readonly List<IFilter> _filters;
        public FilterList(char [] ruleSet)
        {
            _filters = new List<IFilter>();

            foreach(char rule in ruleSet)
            {
                _filters.Add(new Filter(rule));
            }
        }

        public IEnumerator GetEnumerator()
        {
            return _filters.GetEnumerator();
        }
    }
}
