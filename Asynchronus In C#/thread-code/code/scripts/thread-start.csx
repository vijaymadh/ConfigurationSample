using System;
using System.Threading;

ThreadStart deleg = StartThread;
var thread = new Thread(deleg);
thread.Name = "Thread From Method Delegate";

ParameterizedThreadStart par = ParameterStart;
var thread2 = new System.Threading.Thread(par);
thread2.Name = "Thread From Parameter Delegate";

var thread3 = new Thread
(
    () => 
    {
        Print(); 
        System.Console.WriteLine("from lambda " + 42);
    }
);
thread3.Name = "From Lambda";

thread.Start();
thread2.Start(42);
thread3.Start();

static void Print() 
{
    string threadName = Thread.CurrentThread.Name;
    System.Console.WriteLine(threadName);
}

static void StartThread()
{
    Print();
}

static void ParameterStart(object obj)
{
    System.Console.WriteLine("parameter inc: " + obj);
    Print();
}