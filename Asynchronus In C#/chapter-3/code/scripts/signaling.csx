using System.Threading;

Queue<int> _queue = new Queue<int>();
object _token = new object();
void Main()
{
    var producer = new Thread(() => 
    {
        while (true)
        {
            lock (_token)
            {
                var rnd = new Random().Next(0, 42);
                _queue.Enqueue(rnd);
                System.Console.WriteLine("enqueud was: " + rnd);
                Monitor.Pulse(_token);
                Thread.Sleep(1500);
            }
        }
    });

    string first = "first";
    string snd = "second";

    var consumer1 = new Thread(() => Consume(first));
    var consumer2 = new Thread(() => Consume(snd));

    producer.Start();
    consumer1.Start();
    consumer2.Start();

}
void Consume(string consumerName)
{
    lock (_token)
    {
        while (true)
        {
            Monitor.Wait(_token);
            if (_queue.Any())
            {
                int result = _queue.Dequeue();
                System.Console.WriteLine(consumerName + " dequeued: " + result);
            }
        }
    }
}

Main();