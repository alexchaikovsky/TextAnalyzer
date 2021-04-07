using System.IO;
using System.Threading.Tasks;
using TextAnalyzer.Filters;
using TextAnalyzer.Readers;
using TextAnalyzer.Results;

namespace TextAnalyzer
{
    class Analyzer
    {
        private readonly string _path;
        private readonly int _wordLength;
        private readonly FilterList _filterList;
        public Analyzer(string path, FilterList filterList, int wordLength = 3)
        {
            _path = path;
            _wordLength = wordLength;
            _filterList = filterList;

        }
        public IResult LaunchParallel(int providedThreadsNumber = 3)
        {
            int threadsNumber = SetThreadNumber(providedThreadsNumber);

            IResult finalResult = new Result(_filterList);
            object lockObject = new();

            Parallel.For(0, threadsNumber, (i) =>
            {
                var threadResult = Process(offset: i, charsToSkipAfterReading: threadsNumber - _wordLength);
                lock (lockObject)
                {
                    finalResult.Merge(threadResult);
                }
            });
      
            finalResult.OrderAndCut(10);
            return finalResult;
        }

        private int SetThreadNumber(int threadsNumber)
        {
            if (threadsNumber < _wordLength)
            {
                threadsNumber = _wordLength;
            }

            return threadsNumber;
        }

        private IResult Process(int offset = 0, int charsToSkipAfterReading = 0)
        {
            IResult result = new Result(_filterList);

            using (IReader reader = new Reader(new StreamReader(_path), _wordLength))
            {
                reader.Skip(offset);
                ReadProcessPart(charsToSkipAfterReading, result, reader);
            }
            result.RunFilter();
            return result;
        }

        private void ReadProcessPart(int charsToSkipAfterReading, IResult result, IReader reader)
        {
            while (reader.CanRead)
            {
                if (!reader.TryRead(out string newWord))
                {
                    break;
                }
                result.AddWord(newWord);
                reader.Skip(charsToSkipAfterReading);
            }
        }
    }
}
