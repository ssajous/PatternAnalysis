using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAnalysis
{
    public class Bigram
    {
        private string _source;

        public Bigram()
        {
            _source = string.Empty;
        }

        public Bigram(string value)
        {
            InitializeForValue(value);
        }

        public HashSet<string> BigramSet { get; private set; }

        public void InitializeForValue(string value)
        {
            _source = value;
            BigramSet = BuildBigramSet(value);
        }

        private static HashSet<string> BuildBigramSet(string input)
        {
            HashSet<string> bigrams = new HashSet<string>();

            for (int i = 0; i < input.Length - 1; i++)
            {
                bigrams.Add(input.Substring(i, 2));
            }
            return bigrams;
        }
    }
}
