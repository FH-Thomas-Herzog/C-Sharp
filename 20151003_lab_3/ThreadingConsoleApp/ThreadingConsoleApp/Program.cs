using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingConsoleApp
{
    class Program
    {
        // Delegate method signature definition
        delegate void MyDelegate(int i1, int i2);
        // The problem is we need a delegate for each type
        delegate int StringToIntDelegate(string i);
        delegate double StringToDoubleDelegate(string i);
        // Solve the former problem by using generic delegates
        delegate void GenericDelegate<T>(T value);
        delegate T GenericDelegate<T, V>(V value);

        static void Main(string[] args)
        {
            int i1 = 10;
            int i2 = 10;

            // Assign method to delegate which works because the Method fits defined signature
            MyDelegate delegate1 = MyMethod;
            // Invoke delegate 
            delegate1(i1, i2);

            // use of generic delegate
            GenericDelegate < int > genericDelegate1 = GenericIntMethod;
            // Invoke generic delegate
            genericDelegate1(i1);

            // use of generic (param, return) with generics
            GenericDelegate<int, string> genericDelegate2 = GenericIntMethod2;
            genericDelegate2("12.0");

            // Use of implizit action delegates
            Action<int> actionDelegate1 = GenericIntMethod;
            actionDelegate1(i1);
            Action<int, int> actionDelegate2 = MyMethod;
            actionDelegate2(i1, i2);

            // Use of implizit function (delegates) which provide typed return value
            Func<string, int> functionDelegate1 = GenericIntMethod2;
            functionDelegate1("12.0");
        }

        private static void GenericIntMethod(int i1)
        {
            Console.WriteLine("generic delegate called. i1: {0}", i1);
        }

        private static int GenericIntMethod2(string value)
        {
            Console.WriteLine("generic delegate called. value: {0}", value);
            return int.Parse(value); 
        }

        static void MyMethod(int i1, int i2)
        {
            Console.WriteLine("Delegate called. i1: {0}, i2: {1}", i1, i2);
        }
    }
}
