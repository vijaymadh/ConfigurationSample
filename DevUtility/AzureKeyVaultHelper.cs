using System;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace ConfigurationValidation
{
    //-------------------------------------------------------------------------------------------------
    // <copyright file="AzureKeyVaultHelper.cs" company="Icertis Inc.">
    //     Copyright (c) 2014 Icertis Inc. All Rights Reserved.
    // </copyright>
    //
    // <summary>
    //     Implements methods for retrieving keys and secrets from AzureKeyVault.
    // </summary>
    //-------------------------------------------------------------------------------------------------

    namespace akvHelper
    {
        //using Microsoft.IdentityModel.Clients.ActiveDirectory;

        /// <summary>
        /// Helper class to get keys and secrets from Azure Key Vault
        /// </summary>
        public static class AzureKeyVaultHelper
        {
            /// <summary>
            /// Constant variable for holding the Client Id value
            /// </summary>
            public static string ClientId = "1fb36fdf-208a-4b53-ab5e-7d4cac05faa2"; // Application Name: coredevkeyvaultapp

            /// <summary>
            /// Constant variable for holding the Client secret value
            /// </summary>
            public static string ClientSecret = "O7jqRrrVAABUaplu8T2IdTSKHCuDHAq9NV3xTiQ7IAQ=";

            /// <summary>
            /// Constant variable for holding the Client secret value
            /// </summary>
            public static string VaultName = "development-keyvault";


            /// <summary>
            /// Constant variable for holding the content type while creating new secret
            /// </summary>
            private const string ContentType = "plaintext";


            #region Secret related Methods - External

            /// <summary>
            /// Get Secret from AzureKeyVault
            /// </summary>
            /// <returns>String url of Key Vault</returns>
            public static string VaultAddress
            {
                get;
                set;
            }

            /// <summary>
            /// Creates or updates a secret
            /// </summary>
            /// <param name="secretName"> The secret name</param>
            /// <param name="secretValue">The secret value</param>
            public static string CreateSecret(string secretName, string secretValue)
            {
                var vaultClient = new KeyVaultClient(GetToken);

                var secret = vaultClient.SetSecretAsync(VaultAddress, secretName, secretValue, contentType: ContentType).Result;
                return secret.Value;
            }

            /// <summary>
            /// Deletes secret
            /// </summary>
            /// <param name="secretName"> The secret name</param>
            public static void DeleteSecret(string secretName)
            {
                try
                {
                    var vaultClient = new KeyVaultClient(GetToken);
                    Task.Run(() => vaultClient.DeleteSecretAsync(VaultAddress, secretName)).ConfigureAwait(false)
                        .GetAwaiter().GetResult();
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            /// <summary>
            /// Get Secret from AzureKeyVault using name
            /// </summary>
            /// <param name="secretName">name of the secret saved</param>
            /// <returns>secret value</returns>
            public static string GetSecretByName(string secretName)
            {
                var vaultClient = new KeyVaultClient(GetToken);
                var secret = vaultClient.GetSecretAsync(vaultBaseUrl: VaultAddress, secretName: secretName).GetAwaiter().GetResult().Value;
                return secret;
            }
            #endregion

            /// <summary>
            /// To Get token for accessing KeyVault
            /// </summary>
            /// <param name="authority">authority value</param>
            /// <param name="resource">resource value</param>
            /// <param name="scope">scope value</param>
            /// <returns>token value</returns>
            private static async Task<string> GetToken(string authority, string resource, string scope)
            {
                var authContext = new AuthenticationContext(authority);
                var clientCred = new ClientCredential(
                    clientId: ClientId, clientSecret: ClientSecret);
                var result = await authContext.AcquireTokenAsync(resource, clientCred);

                if (result == null)
                {
                    throw new InvalidOperationException("Failed to obtain the JWT token");
                }

                return result.AccessToken;
            }

        }
    }

}
