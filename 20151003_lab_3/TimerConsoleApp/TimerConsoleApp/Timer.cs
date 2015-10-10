using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Observer pattern in C#
// Timer notifies observer about action
//
// 1. declare event handler (delegate)
// 2. declare event in sender object
// 3. fire event with null check (null event means no observer registered)
// 4. register/unsubscribe observers when needed/not needed
namespace TimerConsoleApp
{
    public delegate void ExpiredEventHandler(DateTime signaledTime);

    class Timer
    {
        private Thread ticker;
        private const int DEFAULT_INTERVAL = 1000;

        // Makes this (delegate) variable to an event which allows observer registration
        public event ExpiredEventHandler Expired;

        public int Interval { get; set; }

        public Timer()
        {
            Interval = DEFAULT_INTERVAL;
            ticker = new Thread(OnTick);
        }

        // Inline invocation since C# 6
        public void Start() => ticker.Start();

        private void OnTick()
        {
            while (true)
            {
                Thread.Sleep(Interval);

                // TODO... code which shall be get invoced each tick

                //Null safe invocation since C# 6
                Expired?.Invoke(DateTime.Now);
            }
        }
    }
}
