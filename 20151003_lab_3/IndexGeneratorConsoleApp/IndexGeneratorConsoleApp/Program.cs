using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexGeneratorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WordMap wordMap = new WordMap();
            using (TextReader input = new StreamReader(File.OpenRead("in.txt"), Encoding.Default))
            using (TextWriter output = Console.Out)
            {
                string line;
                int lineNr = 1;

                while((line = input.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { ' ' ,',','.'}, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in words)
                    {
                        wordMap.addWord(word, lineNr);
                        lineNr++;
                    }
                }

                wordMap.PrintIndex(output);
            }
            Console.ReadKey();
        }
    }
}
