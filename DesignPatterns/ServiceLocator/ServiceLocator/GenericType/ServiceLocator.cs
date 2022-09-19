using System;
using System.Collections.Generic;

namespace ServiceLocator.GenericType
{
    public  class ServiceLocator:IService
    {
        public Dictionary<object, object> servicecontainer;
        public ServiceLocator()
        {
            servicecontainer = new Dictionary<object, object>();
            servicecontainer.Add(typeof(IGenServiceA), new GenServiceA());
            servicecontainer.Add(typeof(IGenServiceB), new GenServiceB());
        }

        public T GetService<T>()
        {
            try
            {
                return (T)servicecontainer[typeof(T)];
            }
            catch (Exception)
            {

                throw new NotImplementedException("service is not available");
            }
        }
    }
}
