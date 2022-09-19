using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceFactory
{
    public class Loader
    {
        private static readonly Dictionary<string, IResourceLoader> Instance=new Dictionary<string, IResourceLoader>();
        public static IResourceLoader LoadInstance(string name)
        {
            if (Instance != null && Instance.ContainsKey(name))
            {
                return Instance[name];
            }

            var allTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()).
                Where(type => typeof(IResourceLoader).IsAssignableFrom(type) &&
            !type.IsInterface && !type.IsAbstract && type.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            Instance.Add(name, (IResourceLoader)Activator.CreateInstance(allTypes));

            return Instance[name];
        }
    }
}
