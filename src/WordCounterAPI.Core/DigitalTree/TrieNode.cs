using System.Reflection.Metadata;
using WordCounterAPI.Core.Constants;

namespace WordCounterAPI.Core.DigitalTree
{
    public class TrieNode
    {
        public TrieNode[] Children = new TrieNode[Lexical.AlphabetLengthUS];

        public bool isComplete;

        public int Count;

        public TrieNode()
        {
            isComplete = false;

            for (int i = 0; i < Children.Length; i++)
            {
                Children[i] = null;
            }
        }

    }
}
