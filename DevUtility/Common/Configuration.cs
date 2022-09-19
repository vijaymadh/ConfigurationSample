namespace ConfigurationValidation.Common
{
    static class Configuration
    {
        static public string AkvClientId => System.Configuration.ConfigurationSettings.AppSettings["core.azurekeyvault.clientid"];
        static public string AkvClientSecret => System.Configuration.ConfigurationSettings.AppSettings["core.azurekeyvault.clientsecret"];
        static public string AkvClientKeyVaultUri => System.Configuration.ConfigurationSettings.AppSettings["core.azurekeyvault.vaulturi"];
        static public string EchoSignClientId  => System.Configuration.ConfigurationSettings.AppSettings["core.esign.clientid"];
        static public string EchoSignClientSecret => System.Configuration.ConfigurationSettings.AppSettings["core.esign.clientsecret"];
        static public string EsignCallBackUrl => System.Configuration.ConfigurationSettings.AppSettings["esign.callbackurl"].TrimEnd('/');
        static public string authrefreshcode => System.Configuration.ConfigurationSettings.AppSettings["authrefreshcode"].TrimEnd('/');
        static public string accessapikey => System.Configuration.ConfigurationSettings.AppSettings["accessapikey"].TrimEnd('/');

    }
}
