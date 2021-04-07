using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAnalyzer.Filters;
using TextAnalyzer.Printers;
using TextAnalyzer.Results;

namespace TextAnalyzer
{
    public class AnalyzerStarter
    {
        private readonly IPrinter _printer;
        private readonly string _path;
        Analyzer analyzer;
        IResult result;
        long time;
        public AnalyzerStarter(string path, IPrinter printer)
        {
            _path = path;
            _printer = printer;
            analyzer = new Analyzer(_path, new FilterList(new char[] { '\n', ' ', '.', ',', '[', ']' }));
        }
        public void Calculate()
        {
            (result, time) = Utility.MeasureTime(analyzer.LaunchParallel, 6);
        }
        public void Print()
        {
            _printer.PrintResult(result);
            _printer.PrintTime(time);
        }
   

    }
}
