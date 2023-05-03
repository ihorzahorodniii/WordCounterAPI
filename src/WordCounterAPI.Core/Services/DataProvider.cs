using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounterAPI.Core.Interfaces;

namespace WordCounterAPI.Core.Services
{
    public class DataProvider : ITextProvider
    {
        private readonly string? _fileName;
        private FileStream? _fileStream;

        public DataProvider(string fileName)
        {
            _fileName = fileName;
        }

        public DataProvider(FileStream fileStream)
        {
            _fileStream = fileStream;
        }

        public IEnumerable<string> GetText()
        {
            return string.IsNullOrEmpty(_fileName) ? File.ReadAllLines(_fileStream.Name) : File.ReadLines(_fileName);
        }
    }
}
