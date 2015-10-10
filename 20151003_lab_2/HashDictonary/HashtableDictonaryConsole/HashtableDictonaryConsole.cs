using HashDictonary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashtableDictonary.Console
{
    class HashtableDictonaryConsole
    {
        static void Main(string[] args)
        {
            HashDictonary<int, string> dictonary = new HashDictonary<int, string>();
            dictonary[3] = "Willi";
            dictonary[4] = "Hugo";
            dictonary.Add(5, "Franz");

            System.Console.WriteLine("[1] = {0}", dictonary[3]);
            System.Console.WriteLine("[4] = {0}", dictonary[4]);
            System.Console.WriteLine("[5] = {0}", dictonary[5]);

            string value;
            if(!dictonary.TryGetValue(6,  out value))
            {
                System.Console.WriteLine("No value found for key 6");
            }
            if (dictonary.TryGetValue(5, out value))
            {
                System.Console.WriteLine("[5] = {0}", value);
            }

            foreach (var pair in dictonary)
            {
                System.Console.WriteLine(pair.ToString());
            }

            IEnumerable enumerable = dictonary;
            foreach (var item in enumerable)
            {
                System.Console.WriteLine(item.ToString());
            }

            System.Console.ReadLine();
        }
    }
}
