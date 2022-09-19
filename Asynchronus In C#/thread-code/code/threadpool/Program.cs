using System;
using System.Threading;

namespace threadpool
{
    class Program
    {
        static void Main(string[] args)
        {
            // "normal" thread
            var thread = new Thread(() => RunOnThreadpool("Normal-Thread"));

            // 1 Use ThreadPool Enqueuing
            ThreadPool.QueueUserWorkItem(param => RunOnThreadpool("Queued Item"));

            // 2 Task (chapter 4) 
            System.Threading.Tasks.Task.Run(() => RunOnThreadpool("From the Task"));

            // 3 APM is another one, but obsolete
            // usually BeginInvoke and EndInvoke Methods
            thread.Start();
            Console.ReadLine();
        }

        private static void RunOnThreadpool(string threadName) // not allowed on thread pool
        {
            // how to find out? --> Thread Pool thread is automatic background thread!

            bool isBackground = Thread.CurrentThread.IsBackground;

            string background = isBackground ? "a background thread" : "a foreground thread";
            System.Console.WriteLine($"Now running thread is {background} with name {threadName}");

        }
    }
}
