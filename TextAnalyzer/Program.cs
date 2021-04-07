using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using TextAnalyzer.Results;
using TextAnalyzer.Filters;
using TextAnalyzer.Printers;

namespace TextAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];

            if (Utility.CheckFileExists(path))
            {
                var analyzerStarter = new AnalyzerStarter(path, new Printer());
                analyzerStarter.Calculate();
                analyzerStarter.Print();
            }
        }
    }
}
