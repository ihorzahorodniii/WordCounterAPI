using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounterAPI.Core.Interfaces
{
    public interface IWordCounterService
    {
        public Dictionary<string, int> GetWords();
    }
}
