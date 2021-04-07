using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer.Readers
{
    public interface IReader : IDisposable
    {
        //string Path { get; }
        void Skip(int n);
        //bool TryRead(out Word result);
        bool TryRead(out string result);
        bool CanRead { get; }

    }
}
