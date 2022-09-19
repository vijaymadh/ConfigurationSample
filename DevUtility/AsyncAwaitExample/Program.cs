using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitExample
{
    class Program
    {
        static void Main(string[] args)
        {
            /* var stopwatch = new Stopwatch();
             stopwatch.Start();

             var apiResult= GetDataFromAPI();
             var dbResult = GetDataFromDB();
             stopwatch.Stop();
             ShowResult(apiResult, dbResult);
             Console.WriteLine($"\nElapsed Time: { stopwatch.ElapsedMilliseconds}, Press Any Key to break.");
             Console.Read();*/
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            CallMethod();            
            stopwatch.Stop();
            Console.WriteLine($"\nElapsed Time: { stopwatch.ElapsedMilliseconds}, \nPress Any Key to break.");
            Console.Read();
        }

        private static async void CallMethod()
        {
            try
            {
                var apiResult = GetDataFromAPIAsync();
                var dbResult = GetDataFromDB();

                await apiResult;
                ShowResult(apiResult.Result, dbResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        // /*

        public static async Task<string> GetDataFromAPIAsync()
        {
            await Task.Delay(500);
            //Task.Delay(500).Wait();
            return "Get Data From API";
        }

        // */

        /*
        public static string GetDataFromAPI()
        {   
            Task.Delay(500).Wait();
            return "Get Data From API";
        }
        */

        public static string GetDataFromDB()
        {
            Task.Delay(500).Wait();
            return "Get Data From DB";
        }


        public static void ShowResult(string apiResult, string dbResult)
        {
            Console.WriteLine($"API Result: {apiResult} \nDB Result: {dbResult}");

        }


    }
}
