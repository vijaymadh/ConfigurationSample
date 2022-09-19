using System;

namespace ServiceLocator
{
    public class LoggingService : Iservice
    {
        public void ExecuteService()
        {
            Console.WriteLine("Executing Log Service");
        }
    }
}
