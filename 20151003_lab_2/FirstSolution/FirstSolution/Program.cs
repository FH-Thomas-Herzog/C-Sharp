using System;
using System.Threading;

namespace ConsoleApplication
{
    public class Program
    {
        private string name;

        // Property where the method body of getter and setter can be defined
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Simple get and set for the property
        public int MyProperty { get; set; }

        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Hello world");
            }

            int a = 15;
            a = Add(a, 5);
        }

        /// <summary>
        /// Adds two integers
        /// </summary>
        /// <param name="a">the left hand variable</param>
        /// <param name="v">the right hand variable</param>
        /// <returns>the sum of the two integers</returns>
        private static int Add(int a, int v)
        {
            return a + v;
        }
    }
}
