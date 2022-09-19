using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTreading
{
    public class LockedMethods
    {
        static readonly object _object = new object();
        public static int ThreadNo;
        public void Execute()
        {
            lock (_object)
            {

                Console.WriteLine("Call No (Before Lock): " + ThreadNo.ToString());
           
                System.Threading.Thread.Sleep(800);

                Console.WriteLine("Call No (After Lock): " + ThreadNo.ToString());
            }
        }

    }
}
