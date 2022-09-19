using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace exclusive_locking
{
    class Program
    {
        static void Main(string[] args)
        {
           var waiter1 = new Thread(() => DeliverCake(1, distanceToBuffet:100));
           var waiter2 = new Thread(() => DeliverCake(2, distanceToBuffet:25));

           waiter1.Start();
           waiter2.Start();
        }

        private static List<Cake> _cakes = new List<Cake>
        {
            new Cake { Name = "Apfelkuchen" },
            new Cake { Name = "Torte" },
            new Cake { Name = "Vanille Eis" },
        };

        private static object _token = new object();
        private static void DeliverCake(int v, int distanceToBuffet)
        {
           lock(_token)
           {
               try
               {
                    if (_cakes.Any(x => x.Name == "Apfelkuchen"))
                    {
                        System.Console.WriteLine($"waiter-{v} Cake found");
                        Thread.Sleep(distanceToBuffet);

                        //if (v == 1) throw new InvalidOperationException("waiter fell over the carpet");

                        Cake taken = _cakes.FirstOrDefault(x => x.Name == "Apfelkuchen");
                        _cakes.Remove(taken);

                        string result = taken != null 
                                    ? taken.Name + $" is taken now and is of the menu."
                                    : "Cake was taken before.";
                        
                        System.Console.WriteLine($"waiter-{v} - " + result);
                    }
                    else
                    {
                        System.Console.WriteLine($"waiter-{v} - " + "Cake not found");
                    }
               }
               catch (System.Exception ex)
               {
                    System.Console.WriteLine($"Exception-{ex.ToString()}");
                }
            }
        }
    }
    class Cake
    {
        public string Name { get; set; }
    }
}
