using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pool
{
    public class PoolingObect<T>
    {
        public string PoolIdentity { get; set; }
        public bool IsObjectInUse { get; set; }

        public string UserIdentity { get; set; }

        public T ObjectInstance { get; set; }
    }


    public class ObjectList<T>
    {
        private List<PoolingObect<T>> objectPool { get; set; }
        public T AddOrGet(T objectToAdd)
        {
            if(objectPool.ContainsKey(key))
                return obje

            objectPool.Add(key, objectToAdd);
        }

    }



    public class PoolCache<T>
    {
        private int poolSize = 5;
        private Dictionary<string, PoolSchema<T>> objectPool { get; set; }

        public void Add(PoolSchema<T> objectToAdd, string key)
        {
            objectPool.Add(key, objectToAdd);
        }

        public PoolSchema<T> GetOrAdd(string key)
        {
            if(objectPool.Where< PoolSchema<T>>(schema=>schema.UserIdentity)

           return objectPool[key];
        }

        public void SetObjectUsed(string key, string userIdentity)
        {
            objectPool[key].IsObjectInUse = true;
            objectPool[key].UserIdentity= userIdentity;
        }

        public string GetObjectUser(string key)
        {
           return objectPool[key].UserIdentity;
        }

        public string GetNotUSedObject(string key)
        {
            return objectPool[key].UserIdentity;
        }



    }
}
