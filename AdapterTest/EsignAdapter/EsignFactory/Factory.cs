using System.Reflection;
using EsignDifinition;

namespace EsignFactory
{
    public static class Factory
    {
        public static IEsign GetEsignObject(string esignImplementation)
        {
            var esignImplementationArray = esignImplementation.Split(';');

            var dllName = esignImplementationArray[0] + ".dll";
            var className = esignImplementationArray.Length > 1 ? esignImplementationArray[1] : string.Empty;
            if (esignImplementationArray[0].Equals("EchoSign") && string.IsNullOrWhiteSpace(className))
            {
                className = "EchoSign.EchoSign";
            }

            if (esignImplementationArray[0].Equals("DocuSign") && string.IsNullOrWhiteSpace(className))
            {
                className = "DocuSign.DocuSign";
            }

            var assemblyName = dllName;
            var assemblyNameSpace = className;
            Assembly esignAssembly = Assembly.LoadFrom(assemblyName);
            var esignInstance = esignAssembly.CreateInstance(assemblyNameSpace);
            return esignInstance as IEsign;
        }
    }
}
