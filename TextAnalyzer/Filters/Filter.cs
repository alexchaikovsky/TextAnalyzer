using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer.Filters
{
    public class Filter : IFilter
    {
        private readonly char _rule;
        public Filter(char rule)
        {
            _rule = rule;
        }
        public bool CheckWordValid(string word)
        {
            //string wordString = word.ToString();
            return !word.Contains(_rule);
        }
    }
}
