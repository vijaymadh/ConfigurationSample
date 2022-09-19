using System;
using System.Threading;

namespace timeout_exclusive
{
    class Program
    {
        static object _token = new object();
        static int accountBalance = 100;
        static void Main(string[] args)
        {
            // your code goes here
        }

        static void AccessWithTimeOut(int withdrawl)
        {
            bool wasAquired = false; 
            try
            {
                Monitor.TryEnter(_token, TimeSpan.FromSeconds(10), ref wasAquired);
                if (wasAquired)
                {
                    if (accountBalance >= withdrawl)
                    {
                        accountBalance -= withdrawl;
                    }
                }
                else
                {
                    throw new TimeoutException("timed out!");
                }
            }
            catch (System.Exception)
            { 
                // deliberately left empty
            }
            finally
            {
                if (wasAquired)
                {
                    Monitor.Exit(_token);
                }
            }
        }
    }
}
