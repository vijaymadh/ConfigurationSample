using System;

namespace ServiceLocator.GenericType
{
    public class GenServiceA : IGenServiceA
    {
        public void Execute()
        {
            Console.WriteLine("A Generic Service Called");
        }
        
    }
}
