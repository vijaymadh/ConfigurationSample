using System.Threading;

[ThreadStatic]
private static int _local = 42;

private static int _global = 42;

private static ThreadLocal<int> _tLocal = new ThreadLocal<int>(() => 42);

for (int i = 0; i < 10; i++)
{
    var thread = new Thread(Increment);
    thread.Name = $"Thread-Nr [{i}]";
    thread.Start();

    Thread.Sleep(50); // besserer Output
}

static void Increment()
{
    // _local++;
    _tLocal.Value++;
    string threadName = Thread.CurrentThread.Name;
    System.Console.WriteLine($"{threadName} - Local:  [{_tLocal}]");
    System.Console.WriteLine($"{threadName} - Global: [{++_global}]");
}