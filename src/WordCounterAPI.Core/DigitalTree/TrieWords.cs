using System.Reflection.Metadata;
using WordCounterAPI.Core.Constants;

namespace WordCounterAPI.Core.DigitalTree
{
    public class TrieWords
    {
        public TrieNode root;

        public Dictionary<string, int> Result;

        public TrieWords(ref Dictionary<string, int> result)
        {
            root = new TrieNode();
            Result = result;
        }

        public void Insert(string key)
        {
            int length = key.Length;

            TrieNode pCrawl = root;

            for (int level = 0; level < length; level++)
            {
                int index = key[level] - 'a';
                if (pCrawl.Children[index] == null)
                    pCrawl.Children[index] = new TrieNode();

                pCrawl = pCrawl.Children[index];
            }

            pCrawl.isComplete = true;
            pCrawl.Count++;
        }

        public int WordCount(TrieNode root, string prefix = "")
        {
            int result = 0;

            if (root.isComplete)
            {
                Result.Add(prefix, root.Count);
                result++;
            }

            for (int i = 0; i < Lexical.AlphabetLengthUS; i++)
            {
                if (root.Children[i] != null)
                {
                    string newPrefix = prefix + ((char)(i + Convert.ToByte('a')));
                    result += WordCount(root.Children[i], newPrefix);
                }
            }

            return result;
        }
    }
}
