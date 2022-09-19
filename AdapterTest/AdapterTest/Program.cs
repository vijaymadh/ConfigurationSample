using System;
using System.Configuration;
using System.Diagnostics;
using EsignDifinition;
using EsignFactory;
using ResourceFactory;

namespace AdapterTest
{
    class Program
    {

        //public static string getCurrentCpuUsage()
        //{

        //    PerformanceCounter cpuCounter;
        //    cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        //    return cpuCounter.NextValue() + "%";
        //}

        //public static string getAvailableRAM()
        //{
        //    PerformanceCounter ramCounter;
        //    ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        //    return ramCounter.NextValue() + "MB";
        //}

        static void Main(string[] args)
        {
            var esignImplementation = ConfigurationManager.AppSettings["Esign.Implementation"];

            IEsign esignObject = Factory.GetEsignObject(esignImplementation);
            Console.WriteLine(esignObject.Send());
            Console.WriteLine(esignObject.OverrideTest());
            
            Console.ReadLine();
        }
    }
}
