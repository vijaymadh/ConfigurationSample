using System;
using System.Threading;

namespace errors
{
    class Program
    {
        static void Main(string[] args)
        {
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
            
            var background = new Thread(() => throw new InvalidOperationException("nothing shown"))
            {
                // IsBackground = true,
                
                Name = "silently fails"
            };
            background.Start();
        }
    }
}
