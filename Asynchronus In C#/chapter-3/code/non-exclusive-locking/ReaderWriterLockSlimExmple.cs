using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace non_exclusive_locking
{
    class ReaderWriterLockSlimExmple
    {
        static ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim();

        public static void run()
        {
            var flipchart = new FlipChart();
            for (int i = 0; i < 30; i++)
            {
                var thread = new Thread(() => Execute(i, flipchart));
                thread.Start();
                Thread.Sleep(50); // better readable output
            }
        }

       static void Execute(int threadCount, FlipChart flip)
        {
            if (threadCount == 0 || threadCount % 5 == 0)
            {
                try
                {
                    _rwLock.EnterWriteLock();
                    System.Console.WriteLine("entering write mode for thread-" + threadCount);
                    flip.Write(threadCount.ToString());
                }
                finally
                {
                    _rwLock.ExitWriteLock();
                }
            }
            else
            {
                try
                {
                    _rwLock.EnterReadLock();
                    System.Console.WriteLine("entering read mode for thread-" + threadCount);
                    System.Console.WriteLine(flip.ReadAllText());
                }
                finally
                {
                    _rwLock.ExitReadLock();
                }
            }
        }


    }
    public class FlipChart
    {
        private string Value;

        public void Write(string value)
        {
            Value += value + "-";
        }

        public string ReadAllText()
        {
            return Value;
        }
    }
}

