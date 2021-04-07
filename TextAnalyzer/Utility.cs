using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAnalyzer.Results;

namespace TextAnalyzer
{
    class Utility
    {
        public static (IResult, long) MeasureTime(Func <int, IResult> function, int parameter)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var result = function(parameter);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            return (result, elapsedMs);
        }
        public static bool CheckFileExists(string path)
        {
            if (!File.Exists(path)) { 
                Console.WriteLine($"Could not find {path}");
                return false;
            }
            return true;
        }
    }
}
