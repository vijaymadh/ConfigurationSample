using ConfigurationValidation.akvHelper;
using ConfigurationValidation.Common;

namespace ConfigurationValidation.Adobe
{
    static class EsignCommon
    {
        private static string oauthRefreshCode;
        private static string accessApi;

        public static string GetOauthRefreshCode(string aKVClientID, string aKVClientSecret, string aKVVaultUri)
        {
            if (!string.IsNullOrWhiteSpace(Configuration.authrefreshcode))
                {
                return Configuration.authrefreshcode;

            }

            if (!string.IsNullOrWhiteSpace(oauthRefreshCode))
            {
                return oauthRefreshCode;
            }

            AzureKeyVaultHelper.ClientId = aKVClientID;
            AzureKeyVaultHelper.ClientSecret = aKVClientSecret;
            AzureKeyVaultHelper.VaultAddress = aKVVaultUri;

            oauthRefreshCode = AzureKeyVaultHelper.GetSecretByName("OauthRefreshCode");
            return oauthRefreshCode;
        }

        public static string GetOauthRefreshCode()
        {
            if (!string.IsNullOrWhiteSpace(Configuration.authrefreshcode))
            {
                return Configuration.authrefreshcode;
            }

            if (!string.IsNullOrWhiteSpace(oauthRefreshCode))
            {
                return oauthRefreshCode;
            }

            AzureKeyVaultHelper.ClientId = Configuration.AkvClientId;
            AzureKeyVaultHelper.ClientSecret = Configuration.AkvClientSecret;
            AzureKeyVaultHelper.VaultAddress = Configuration.AkvClientKeyVaultUri;

            oauthRefreshCode = AzureKeyVaultHelper.GetSecretByName("OauthRefreshCode");
            return oauthRefreshCode;
        }

        public static string GetAccessAPI(string aKVClientID, string aKVClientSecret, string AKVVaultUri)
        {

            if (!string.IsNullOrWhiteSpace(Configuration.accessapikey))
            {
                return Configuration.accessapikey;

            }

            if (!string.IsNullOrWhiteSpace(accessApi))
            {
                return accessApi;
            }

            AzureKeyVaultHelper.ClientId = aKVClientID;
            AzureKeyVaultHelper.ClientSecret = aKVClientSecret;
            AzureKeyVaultHelper.VaultAddress = AKVVaultUri;

            accessApi = AzureKeyVaultHelper.GetSecretByName("AccessApiKeyName");
            return accessApi;
        }

        public static string GetAccessAPI()
        {


            if (!string.IsNullOrWhiteSpace(Configuration.accessapikey))
            {
                return Configuration.accessapikey;

            }

            if (!string.IsNullOrWhiteSpace(accessApi))
            {
                return accessApi;
            }

            AzureKeyVaultHelper.ClientId = Configuration.AkvClientId;
            AzureKeyVaultHelper.ClientSecret = Configuration.AkvClientSecret;
            AzureKeyVaultHelper.VaultAddress = Configuration.AkvClientKeyVaultUri;

            accessApi = AzureKeyVaultHelper.GetSecretByName("AccessApiKeyName");
            return accessApi;
        }
    }
}
