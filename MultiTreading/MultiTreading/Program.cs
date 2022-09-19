using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiTreading
{
    class Program
    {
        static void Main(string[] args)
        {
            LockedMethods.ThreadNo = 0;
            for (int i = 0; i < 10; i++)
            {
                LockedMethods.ThreadNo += 1;
                var start = new ThreadStart((new LockedMethods()).Execute);
                new Thread(start).Start();
            }

            Console.ReadLine();
        }
    }
}
