using System.Threading;

object _token = new object();
int accountBalance = 100;
void Main()
{
    var thread = new Thread(() => { lock (_token) { Thread.Sleep(4500); } });
    var threadThatTimesOut = new Thread(() => AccessWithTimeOut(100));
    
    thread.Start();
    threadThatTimesOut.Start();
}

void AccessWithTimeOut(int withdrawl)
{
    bool wasAquired = false; 
    try
    {
        Monitor.TryEnter(_token, TimeSpan.FromSeconds(2), ref wasAquired);
        if (wasAquired)
        {
            if (accountBalance >= withdrawl)
            {
                accountBalance -= withdrawl;
                System.Console.WriteLine(accountBalance);
            }
        }
        else
        {
            throw new TimeoutException("timed out!");
        }
    }
    catch (System.Exception ex)
    { 
        System.Console.WriteLine(ex);
    }
    finally
    {
        if (wasAquired)
        {
            Monitor.Exit(_token);
        }
    }
}

Main();