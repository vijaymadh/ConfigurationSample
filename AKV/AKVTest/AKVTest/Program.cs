using System;
using AKVTest.akvHelper;

namespace AKVTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var testValue = "Adding my Test Value";
            //var accessApi = "https://api.na2.echosign.com";

            testValue = AzureKeyVaultHelper.CreateSecret("testValue", testValue);
            //var accessApiKey = AzureKeyVaultHelper.CreateSecret("AccessApiKeyName", accessApi);

            var testKeyValue =  AzureKeyVaultHelper.GetSecretByName("testValue");
            //var accessApi = AzureKeyVaultHelper.GetSecretByName("AccessApiKeyName");

            Console.Write(string.Format("testValue: {0}", testKeyValue));

            Console.ReadLine();

        }
    }

}
