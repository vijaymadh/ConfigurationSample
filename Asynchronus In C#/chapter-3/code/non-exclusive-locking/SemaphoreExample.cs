using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace non_exclusive_locking
{
    class SemaphoreExample
    {
        static SemaphoreSlim _semaphore = new SemaphoreSlim(3);

        public static void run()
        {
            var flipchart = new FlipChart();
            for (int i = 1; i < 10; i++)
            {
                var thread = new Thread(EnterToClub);
                thread.Start(i);
            }
        }

        private static void EnterToClub(Object id)
        {
            Console.WriteLine($"{id} Wants to Entered club at {DateTime.Now.Minute}-{DateTime.Now.Second}-{DateTime.Now.Millisecond}");
            _semaphore.Wait();
            Console.WriteLine($"{id} Entered the club at {DateTime.Now.Minute}-{DateTime.Now.Second}-{DateTime.Now.Millisecond} and dancing ......");
            Thread.Sleep(Convert.ToInt32(id) * 500);
            Console.WriteLine($"{id} left the club at {DateTime.Now.Minute}-{DateTime.Now.Second}-{DateTime.Now.Millisecond}");
            _semaphore.Release();
        }

    }
}

