using System.Threading;

ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim();

void Main()
{
    var flipchart = new FlipChart();
    for (int i = 0; i < 30; i++)
    {
        var thread = new Thread(() => Execute(i, flipchart));
        thread.Start();
        Thread.Sleep(50); // better readable output
    }

}


void Execute(int i, FlipChart flip)
{
    if (i == 0 || i % 5 == 0)
    {
        try
        {
            _rwLock.EnterWriteLock();
            System.Console.WriteLine("entering write mode for thread-" + i);
            flip.Write(i.ToString());
        }
        finally
        {
            _rwLock.ExitWriteLock();
        }
    }
    else
    {
        try
        {
            _rwLock.EnterReadLock();
            System.Console.WriteLine("entering read mode for thread-" + i);
            System.Console.WriteLine(flip.ReadAllText());
        }
        finally
        {
            _rwLock.ExitReadLock();
        }
    }
}

class FlipChart
{
    private string Value;

    public void Write(string value)
    {
        Value += value + "-"; 
    }

    public string ReadAllText()
    {
        return Value;
    }
}

Main();