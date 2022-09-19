using System;

namespace ServiceLocator.GenericType
{
    public class GenServiceB : IGenServiceB
    {
        public void Execute()
        {
            Console.WriteLine("B Generic Service Called");
        }
        
    }
}
