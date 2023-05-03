using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using WordCounterAPI.Core.DigitalTree;
using WordCounterAPI.Core.Interfaces;
using WordCounterAPI.Core.Constants;


namespace WordCounterAPI.Core.Services
{
    public class WordCounterService : IWordCounterService
    {
        private readonly ITextProvider _textProvider;
        private Dictionary<string, int> searchWordsResults;

        public WordCounterService(ITextProvider textProvider)
        {
            _textProvider = textProvider;
            searchWordsResults = new Dictionary<string, int>();
        }

        public Dictionary<string, int> GetWords()
        {
            TrieWords trie = new TrieWords(ref searchWordsResults);

            foreach (string word in _textProvider.GetText().SelectMany(x => x.Split()))
            {
                string cleanedWord = word;

                if (word.Any(char.IsPunctuation))
                    cleanedWord = RemovePunctiation(word);

                if (cleanedWord.Length > 0)
                {
                    if (cleanedWord.Any(char.IsAsciiDigit))
                    {
                        if (!searchWordsResults.ContainsKey(cleanedWord))
                            searchWordsResults.Add(cleanedWord, 1);
                        else
                            searchWordsResults[cleanedWord]++;
                    }
                    else
                    {
                        trie.Insert(cleanedWord.ToLower());
                    }
                }
            }

            if (trie.WordCount(trie.root) > 0)
            {
                //OK
            }

            return searchWordsResults.OrderByDescending(x => x.Value).ToDictionary(i => i.Key, i => i.Value);

        }

        string RemovePunctiation(string input)
        {
            return Regex.Replace(input, Lexical.PunctiationChars, string.Empty);
        }
    }
}
