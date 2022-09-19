using System;
using System.Threading;

namespace coordinate
{
    class Program
    {
        static void Main(string[] args)
        {
            WithResultAndTimeOut();
            return;
            // var sndThread = new Thread
            // (
            //     () => 
            //     {
            //         System.Console.WriteLine("snd thread started");
            //         Thread.Sleep(400);
            //         System.Console.WriteLine("snd thread stopped");
            //     }
            // );

            // sndThread.Start();

            //     System.Console.WriteLine("block main thread at : " + DateTime.Now.ToString("ss : fff") + " s : ms");
            //     // blocking main thread!
            //     sndThread.Join();
            //     System.Console.WriteLine("unblock main thread at : " + DateTime.Now.ToString("ss : fff") + " s : ms");
        }

        static void WithResultAndTimeOut()
        {
            var result = new Result { Value = "before" };
            var thread = new Thread
            (
                () => 
                {
                    Thread.Sleep(200);
                    result.Value = "after";
                }
            );

            thread.Start();

            bool wasJoined = thread.Join(400);

            if (wasJoined)
            {
                System.Console.WriteLine("operation completed ! - " + result.Value);
            }
            else
            {
                System.Console.WriteLine("operation timed out ! - " + result.Value);
            }

        }

        class Result
        {
            public string Value { get; set; }
        }
    }
}
