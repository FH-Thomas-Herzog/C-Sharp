using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            timer.Interval = 500;

            // register observer (-= for removal)
            timer.Expired += OnTimeExpiredObserver;

            // registration via new operator of event
            // timer.Expired += new ExpiredEventHandler(OnTimeExpiredObserver);

            // registration via lambda expressions 
            // - multiple parameters need enclosing bracets ()
            // - multiple lines need enclosing bracets {})
            // - Anonymus methods cannot be unsubscribed via (-=) because they are anonymus 
            timer.Expired += signaledTime => Console.WriteLine("Via lambda: {0}" + signaledTime);

            // If we hold a reference to the anonymus function then we can unsubscribe it.
            ExpiredEventHandler lambdaHandler = signaledTime => Console.WriteLine("Via lambda: {0}" + signaledTime);
            timer.Expired += lambdaHandler;
            timer.Expired -= lambdaHandler;

            timer.Start();
        }

        private static void OnTimeExpiredObserver(DateTime signaledTime)
        {
            Console.WriteLine("Signaled time: {0}", signaledTime);
        }
    }
}
