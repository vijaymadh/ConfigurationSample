using System.Threading;

[ThreadStatic]
private static int _local;

private static int _global;

for (int i = 0; i < 10; i++)
{
    var thread = new Thread(Increment);
    thread.Name = $"Thread-Nr [{i}]";
    thread.Start();

    Thread.Sleep(50); // besserer Output
}

static void Increment()
{
    _local++;
    string threadName = Thread.CurrentThread.Name;
    System.Console.WriteLine($"{threadName} - Local:  [{_local}]");
    System.Console.WriteLine($"{threadName} - Global: [{++_global}]");
}