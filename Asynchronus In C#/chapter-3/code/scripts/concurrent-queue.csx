using System.Collections.Concurrent;
using System.Threading;

AutoResetEvent _event = new AutoResetEvent(false);
ConcurrentQueue<int> _queue = new ConcurrentQueue<int>();
void QueueUsage()
{
    var produce = new Thread(() => 
    {
        while (true)
        {
            int rnd = new Random().Next(0, 100);

            _queue.Enqueue(rnd);
            System.Console.WriteLine("enqueued: " + rnd);
            Thread.Sleep(500);
            _event.Set();
        }
    });
    var c1 = new Thread(() => Consume("first"));
    var c2 = new Thread(() => Consume("second"));

    produce.Start();
    c1.Start();
    c2.Start();
}

void Consume(string name)
{
    while (true)
    {
        _event.WaitOne();
        AtomicQueue(name);
    }
}

void AtomicQueue(string name)
{
    bool success = _queue.TryDequeue(out int i);
    if (success)
    {
        System.Console.WriteLine($"{name} dequeued: " + i);
    }
    else
    {
        System.Console.WriteLine("no content for " + name);
    }
}

QueueUsage();