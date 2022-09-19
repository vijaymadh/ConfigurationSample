using System.Threading;

Lazy<int> lazy = new Lazy<int>(() => { System.Console.WriteLine("calling factory"); Thread.Sleep(200); return 42; });
void Main()
{
    var t = new Thread(PrintLazyAndThreadName);
    var t2 = new Thread(PrintLazyAndThreadName);

    t.Name = "Thread-1";
    t2.Name = "Thread-2";

    t.Start();
    t2.Start();
}

void PrintLazyAndThreadName()
{
    var name = Thread.CurrentThread.Name;
    int result = lazy.Value;
    System.Console.WriteLine($"Thread: [{name}] with - Result: [{result}]");
}

Main();