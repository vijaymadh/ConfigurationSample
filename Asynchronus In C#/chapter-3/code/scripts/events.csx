using System.Threading;

private readonly ManualResetEvent _turnstile = new ManualResetEvent(false);
private Queue<int> _queue = new Queue<int>();
private  object _token = new object();
void Main()
{
    var producer = new Thread
    (
        () => 
        {
            while (true)
            {
                var rnd = new Random().Next(0, 42);
                lock (_token)
                {
                    _queue.Enqueue(rnd);
                    _turnstile.Set();
                    System.Console.WriteLine($"Enqueued: " + rnd);
                }
                Thread.Sleep(300);
            }
        }
    );

    producer.Start();
    new Thread(() => Consume("first")).Start();
    new Thread(() => Consume("second")).Start();
}

void Consume(string consumerName)
{
    while (true)
    {
        _turnstile.WaitOne();
        lock (_token)
        {
            if (_queue.Any())
            {
                int result = _queue.Dequeue();
                System.Console.WriteLine($"{consumerName} dequeued: {result}");
            }
        }
    }
}

//Main();