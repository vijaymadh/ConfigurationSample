using System.Threading;


void PrintThreadType()
{
    string type = Thread.CurrentThread.IsBackground ? "Background Thread" : "Foreground Thread";
    string threadName = Thread.CurrentThread.Name;
    System.Console.WriteLine($"Thread: {threadName} is a {type}");
}

var thread = new Thread(PrintThreadType);
var thread2 = new Thread(PrintThreadType);
thread2.IsBackground = true;

thread.Name = "Thread-1";
thread2.Name = "Thread-2";

thread.Start();
thread2.Start();