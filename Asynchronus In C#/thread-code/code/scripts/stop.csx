using System;
using System.Threading;

// stop on end
// var thread = new Thread(() => System.Console.WriteLine("stopped after this"));
// thread.Start();
// string state = thread.ThreadState == ThreadState.Stopped ? "was stopped" : "still running";

// System.Console.WriteLine(state);
// stop by request
var stopper = new Stopper();
var thread = new Thread(stopper.StopPerRequest);
thread.Start();

Thread.Sleep(500);
stopper.ShouldStop = true; // stop per request
System.Console.WriteLine("finished business thread");


class Stopper
{
    public bool ShouldStop = false;

    public void StopPerRequest()
    {
        int i = 0;
        while (!ShouldStop)
        {
            i++;
            BusinessLogic(i);
        }
    }
    void BusinessLogic(int i)
    {
        Thread.Sleep(200);
        System.Console.WriteLine("some business operation - number: " + i);
    }
}