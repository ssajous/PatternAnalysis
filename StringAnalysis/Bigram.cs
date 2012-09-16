using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAnalysis
{
    public class Bigram
    {
        public Bigram()
        {
            Source = string.Empty;
        }

        public Bigram(string value)
        {
            InitializeForValue(value);
        }

        public HashSet<string> BigramSet { get; private set; }

        public void InitializeForValue(string value)
        {
            Source = value;
            BigramSet = BuildBigramSet(value);
        }

        public string Source { get; private set; }

        private static HashSet<string> BuildBigramSet(string input)
        {
            HashSet<string> bigrams = new HashSet<string>();

            for (int i = 0; i < input.Length - 1; i++)
            {
                bigrams.Add(input.Substring(i, 2));
            }
            return bigrams;
        }

        public double DiceCoefficient(Bigram compareTo)
        {
            var intersection = this.BigramSet.Intersect(compareTo.BigramSet);

            return CalculateDiceCoefficient(intersection.Count(), this.BigramSet.Count, compareTo.BigramSet.Count);
        }

        public double DiceCoefficient(string compareTo)
        {
            Bigram compareBigram = new Bigram(compareTo);
            var intersection = this.BigramSet.Intersect(compareBigram.BigramSet);

            return CalculateDiceCoefficient(intersection.Count(), this.BigramSet.Count, compareBigram.BigramSet.Count);
        }

        private double CalculateDiceCoefficient(int intersectionCount, int setXCount, int setYCount)
        {
            return (2 * intersectionCount) / (setXCount + setYCount);
        }
    }
}
