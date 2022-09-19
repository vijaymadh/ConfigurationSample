using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace resetEvents
{
    class Program
    {
        private static readonly AutoResetEvent _turnstile = new AutoResetEvent(false);
        private static Queue<int> _queue = new Queue<int>();
        private static object _token = new object();
        static void Main(string[] args)
        {
            var producer = new Thread
            (
                () => 
                {
                    while (true)
                    {
                        var rnd = new Random().Next(0, 42);
                        lock (_token)
                        {
                            _queue.Enqueue(rnd);
                            _turnstile.Set();
                            System.Console.WriteLine($"Enqueued: " + rnd);
                        }
                        Thread.Sleep(300);
                    }
                }
            );

            producer.Start();
            new Thread(() => Consume("first")).Start();
            new Thread(() => Consume("second")).Start();
        }

        private static void Consume(string consumerName)
        {
            while (true)
            {
                _turnstile.WaitOne();
                lock (_token)
                {
                    if (_queue.Any())
                    {
                        int result = _queue.Dequeue();
                        System.Console.WriteLine($"{consumerName} dequeued: {result}");
                    }
                }
            }
        }
    }
}
