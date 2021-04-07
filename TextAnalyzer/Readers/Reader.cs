using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextAnalyzer.Readers
{
    public class Reader : IReader
    {
        protected char[] word = new char[3];
        protected readonly StreamReader _streamReader;
        readonly int _wordLength;
        public Reader(StreamReader streamReader, int wordLength)
        {
            _wordLength = wordLength;
            word = new char[wordLength];
            _streamReader = streamReader;
        }

        public void Dispose()
        {
            _streamReader.Close();
        }
        public bool TryRead(out string result)
        {
            int redCount = _streamReader.Read(word, 0, _wordLength);
            result = new string(word);
            return redCount == _wordLength;
        }

        public void Skip(int n)
        {
            for (int i = 0; i < n; i++)
            {
                _streamReader.Read();
            }
        }
        public bool CanRead => _streamReader.Peek() >= 0;
    }
}
