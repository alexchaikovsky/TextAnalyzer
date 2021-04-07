using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAnalyzer.Results;

namespace TextAnalyzer.Printers
{
    public class Printer : IPrinter
    {
        public void PrintResult(IResult result)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine(string.Join(",", result.Select(pair => pair.Key.ToString()).ToArray()));
        }

        public void PrintTime(long time)
        {
            Console.WriteLine($"{time} ms");
        }
    }
}
