using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAnalyzer.Results;

namespace TextAnalyzer.Printers
{
    public interface IPrinter
    {
        void PrintResult(IResult result);
        void PrintTime(long time);
    }
}
