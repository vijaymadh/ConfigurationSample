using System;
using System.Threading;

namespace stop
{
    class Program
    {
        static void Main(string[] args)
        {
            // stop on end
            // var thread = new Thread(() => System.Console.WriteLine("stopped after this"));
            // thread.Start();
            // string state = thread.ThreadState == ThreadState.Stopped ? "was stopped" : "still running";
            
            // System.Console.WriteLine(state);
            // stop by request
            var thread = new Thread(StopPerRequest);
            thread.Start();

            Thread.Sleep(500);
            _shouldStop = true; // stop per request
            System.Console.WriteLine("finished business thread");
        }

        static bool _shouldStop = false;

        private static void StopPerRequest()
        {
            int i = 0;
            if (_shouldStop)
                return;

            BusinessLogic(++i);
            
            if (_shouldStop)
                return;
            
            //System.Console.WriteLine("Other businesslogic");

            // usw.

            while (!_shouldStop)
            {
                i++;
                BusinessLogic(i);
            }
        }

        private static void BusinessLogic(int i)
        {
            Thread.Sleep(200);
            System.Console.WriteLine("some business operation - number: " + i);
        }
        
    }
}
