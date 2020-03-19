using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Clock
{
    class ClockEvent
    {
        ///声明一个委托类型，定义事件处理函数的格式
        public delegate void TickHandler(object sender, TickEventArgs args);
        public class TickEventArgs
        {
            public DateTime CurrentTime { get; }
            public TickEventArgs(DateTime time)
            {
                CurrentTime = time;
            }
        }

        public delegate void AlarmHandler(object sender, AlarmEventArgs args);
        public class AlarmEventArgs
        {
            public DateTime AlarmTime { get; }
            public AlarmEventArgs(DateTime time)
            {
                AlarmTime = time;
            }
        }

        public class AlarmClock
        {
            //闹钟响铃时间
            private DateTime alarmTime;
            //定义事件
            public event TickHandler OnTick;
            public event AlarmHandler OnAlarm;

            //Run方法每隔一秒触发一次OnTick事件，并且时间到了设定的闹铃时间会触发OnAlarm事件响铃
            public void Run()
            {
                alarmTime = System.DateTime.Now.AddSeconds(10);
                Console.WriteLine($"闹钟将于十秒后启动({alarmTime.ToString("HH:mm:ss")}).");
                DateTime tmpTime;

                while (DateTime.Compare(alarmTime, tmpTime = System.DateTime.Now) > 0)
                {
                    TickEventArgs args = new TickEventArgs(tmpTime);
                    //触发onTick事件
                    OnTick(this, args);
                    Thread.Sleep(1000);
                }

                AlarmEventArgs args1 = new AlarmEventArgs(tmpTime);
                OnAlarm(this, args1);
                return;
            }
        }

        public class Clock1
        {
            public AlarmClock alarmClock = new AlarmClock();

            public Clock1()
            {
                //为AlarmClock的OnTick事件添加处理方法
                alarmClock.OnTick += new TickHandler(Clock_OnTick);
                //为AlarmClock的OnAlarm事件添加处理方法
                alarmClock.OnAlarm += new AlarmHandler(Clock_OnAlarm);
            }

            void Clock_OnTick(object sender, TickEventArgs args)
            {
                Console.WriteLine($"滴答! 时间为 {args.CurrentTime.ToString("HH:mm:ss")}");
            }

            void Clock_OnAlarm(object sender, AlarmEventArgs args)
            {
                Console.WriteLine($"闹钟响了! 时间为 {args.AlarmTime.ToString("HH:mm:ss")}");
            }
        }
    }
}
