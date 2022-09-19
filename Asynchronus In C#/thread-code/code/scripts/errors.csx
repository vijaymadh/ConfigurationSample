using System.Threading;

var thread = new Thread
(
    () =>
    {
        try
        {
            throw new Exception
            ("thread that crashed: " + Thread.CurrentThread.Name);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            
        }
    }
);
thread.Name = "Named Thread";

thread.Start();