using System;
using System.Collections.Concurrent;
using System.Threading;

namespace concurrent_data_structures
{
    class Program
    {
        static Lazy<int> lazy = new Lazy<int>(() => { System.Console.WriteLine("calling factory"); Thread.Sleep(200); return 42; });
        static void Main(string[] args)
        {
            //var t = new Thread(PrintLazyAndThreadName);
            //var t2 = new Thread(PrintLazyAndThreadName);

            //t.Name = "Thread-1";
            //t2.Name = "Thread-2";

            //t.Start();
            //t2.Start();
            //System.Console.WriteLine("press any key for concurrent queue");
            //Console.ReadKey();
            QueueUsage();
        }

        static void PrintLazyAndThreadName()
        {
            var name = Thread.CurrentThread.Name;
            int result = lazy.Value;
            System.Console.WriteLine($"Thread: [{name}] with - Result: [{result}]");
        }

        static AutoResetEvent _event = new AutoResetEvent(false);
        static ConcurrentQueue<int> _queue = new ConcurrentQueue<int>();
        static void QueueUsage()
        {
            var produce = new Thread(() => 
            {
                while (true)
                {
                    int rnd = new Random().Next(0, 100);

                    _queue.Enqueue(rnd);
                    System.Console.WriteLine("enqueued: " + rnd);
                    Thread.Sleep(500);
                    _event.Set();
                }
            });
            
            var c1 = new Thread(() => Consume("first"));
            var c2 = new Thread(() => Consume("second"));

            produce.Start();
            c1.Start();
            c2.Start();
        }

        static void Consume(string name)
        {
            while (true)
            {
                _event.WaitOne();
                AtomicQueue(name);
            }
        }

        static void AtomicQueue(string name)
        {
            bool success = _queue.TryDequeue(out int i);
            if (success)
            {
                System.Console.WriteLine($"{name} dequeued: " + i);
            }
            else
            {
                System.Console.WriteLine("no content for " + name);
            }
        }
    }
}
