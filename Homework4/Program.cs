using System;
using static Clock.ClockEvent;

namespace Clock
{

    
    class Program
    {
        static void Main(string[] args)
        {
            Clock1 ck = new Clock1();
            ck.alarmClock.Run();
        }
    }
}
