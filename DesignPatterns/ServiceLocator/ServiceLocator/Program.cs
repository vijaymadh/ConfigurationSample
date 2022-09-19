using System;

namespace ServiceLocator
{
    class Program
    {
        static void Main(string[] args)
        {
            Iservice service = Locator.SetLocation(new LoggingService());
            service.ExecuteService();
            
            ///

            var serviceLocator = new GenericType.ServiceLocator();

            GenericType.IGenServiceA genServiceA = serviceLocator.GetService<GenericType.IGenServiceA>();
            genServiceA.Execute();

            var genServiceB = serviceLocator.GetService<GenericType.IGenServiceB>();
            genServiceB.Execute();

            Console.ReadLine();
        }
    }
}
