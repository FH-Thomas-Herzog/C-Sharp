using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexGeneratorConsoleApp
{
    using Entry = KeyValuePair<string, SortedSet<int>>;

    class WordMap
    {
        private IDictionary<string, SortedSet<int>> wordMap = new Dictionary<string, SortedSet<int>>();

        public void addWord(string word, int lineNr)
        {
            SortedSet<int> set = null;
            if (!wordMap.TryGetValue(word, out set))
            {
                wordMap.Add(word, (set = new SortedSet<int>() { lineNr }));
            }
            else
            {
                set.Add(lineNr);
            }
        }
        public void PrintIndex(TextWriter output)
        {
            foreach (var entry in wordMap)
            {
                output.Write("{0}: ", entry.Key);

                foreach (var lineNumber in entry.Value)
                {
                    output.Write(" {0}", lineNumber);
                }

                output.WriteLine();
            }
        }

        public IEnumerable<string> FindWordsInLine(int line)
        {
            return wordMap.Where(e => e.Value.Contains(line))
                          .OrderBy(e => e.Key)
                          .Select(e => e.Key)
                          .ToList();
        }

        public IEnumerable<Entry> SortByFrequency()
        {
            // Sort by lambda function which returns count of values which represents the frequency 
            return wordMap.OrderByDescending(entry => { return entry.Value.Count; });
        }

        public String FindMostFrequentWord()
        {
            // return SortByFrequency()?.First().Key;

            // via extension method (no this)
            // return IEnumerableExtensions.MaxBy(wordMap, (e1, e2) => e1.Value.Count.CompareTo(e2.Value.Count)).Key;

            // via extensio method 
            return wordMap.MaxBy((e1, e2) => e1.Value.Count.CompareTo(e2.Value.Count)).Key;
        }
    }
}
