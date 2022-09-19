using System;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace ConfigurationValidation
{


    namespace akvHelper
    {
    

        public class AKVSecretInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public string KeyName { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string KeyValue { get; set; }


        }
    }

}
