using System;
using System.Threading;

namespace start
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart @start = StartThread;
            var thread = new Thread(@start);
            thread.Name = "Thread from ThreadStart Delegate";

            ParameterizedThreadStart param = _ParameterizedThreadStart;
            var thread2 = new Thread(param);
            thread2.Name = "Thread from ParameterizedStart Delegate";
            

            int threehundred = 300;
            //string noClosure = "not in the closure space";
            var thread3 = new Thread
            (
                () => 
                {
                    Print();
                    System.Console.WriteLine(threehundred);
                }
            );
            var closure = new Closure(threehundred, Print);
            var thread4 = new Thread(closure.Run);

            thread4.Name = "Thread from Lambda with Closure";
            thread4.Start();
            thread4.Abort();

            // thread.Start();
            // thread3.Start();
            // thread2.Start(42); // will be boxed 
        }

        static void Print()
        {
            string threadName = Thread.CurrentThread.Name;
            System.Console.WriteLine(threadName);
        }

        static void StartThread()
        {
            System.Console.WriteLine("started a thread");
            Print();
        }

        static void _ParameterizedThreadStart(object obj)
        {
            System.Console.WriteLine("from parameter " + obj);
            Print();
        }
    }
}
