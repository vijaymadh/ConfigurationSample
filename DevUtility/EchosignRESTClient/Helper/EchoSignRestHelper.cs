//  -------------------------------------------------------------------------
//  <copyright file="EchoSignRestHelper.cs"  company="Icertis Inc.">
//      Copyright (c) 2014 Icertis Inc. All Rights Reserved.
//  </copyright>
// 
//  <summary>
//       EchoSing Helper
//  </summary>
//  -------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Aspose.Pdf.Facades;
using EchosignRESTClient.Models;
using EchosignRESTClient.Models.AgreementInfo;
using EchosignRESTClient.Models.AgreementView;
using EchosignRESTClient.Models.WebHook;
using Icertis.CLM.ESignAdapter.Model.EchoSignRest;
using Newtonsoft.Json;

namespace EchosignRESTClient.Helper
{
    /// <inheritdoc />
    public class EchoSignRestHelper:IEchoSignRestHelper
    {
        private string clientId;
        private string clientSecret;
        private static HttpClient client;
        private string accessToken;
        private DateTime accessTokenExpiresTime;
        private string apiEndpointVer = "api/rest/v5";
    
        /// <summary>
        /// Injecting HttpClient Object
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public static HttpClient Client
        {
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                client = value;
            }
        }
             

        /// <inheritdoc />
        public string UserEmail
        {
            set
            {
                client.DefaultRequestHeaders.Remove("x-api-user");
                client.DefaultRequestHeaders.Add("x-api-user", "email:" + value);
            }
        }

        /// <summary>
        /// Initializes instance of the Echo Sign RestHelper
        /// </summary>
        /// <param name="accessApi">Access API of EchoSign rest</param>
        /// <param name="clientId">Client Id of EchoSign rest application</param>
        /// <param name="clientSecret">Customer Id of EchoSign rest application</param>
        /// <param name="refreshToken">Refresh token to connect to EchoSign</param>
        public EchoSignRestHelper(string accessApi, string clientId, string clientSecret, string refreshToken)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;

            if (client == null)
            {
                client = new HttpClient { BaseAddress = new Uri(accessApi) };
            }
         
            Authorize(refreshToken).Wait();
        }

        /// <summary>
        /// Authorizes EchoSign relst client for any calls
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        private async Task Authorize(string refreshToken)
        {
            if (accessTokenExpiresTime >= DateTime.Now)
            {
                return;
            }
            using (HttpContent content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "refresh_token"),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret),
                new KeyValuePair<string, string>("refresh_token", refreshToken)
            }))
            {
                var result = await client.PostAsync("oauth/refresh", content).ConfigureAwait(false);
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var tokenObj = JsonConvert.DeserializeObject<RefreshTokenResponse>(response);

                    accessToken = tokenObj.access_token;
                    accessTokenExpiresTime = DateTime.Now.AddMinutes(tokenObj.expires_in);

                    client.DefaultRequestHeaders.Remove("Access-Token");
                    client.DefaultRequestHeaders.Add("Access-Token", accessToken);
                }
                else
                {
                    var response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);                    
                }
            }
        }
        
        /// <inheritdoc />      
        public async Task<TransientDocument> UploadTransientDocument(string fileName, byte[] file, string mimeType = null)
        {
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StreamContent(new MemoryStream(file)), "File", "sample.pdf");
                content.Add(new StringContent(fileName), "File-Name");

                client.DefaultRequestHeaders.Remove("Authorization");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + this.accessToken);


                if (mimeType != null)
                    content.Add(new StringContent(mimeType), "Mime-Type");

                var result = client.PostAsync(apiEndpointVer + "/transientDocuments", content).Result;
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var document = JsonConvert.DeserializeObject<TransientDocument>(response);

                    return document;
                }
                else
                {
                    var response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                                        
                    return null;
                }
            }
        }

        /// <inheritdoc />
        public async Task<AgreementCreationResponse> CreateAgreement(AgreementInfo newAgreement)
        {
            var serializedObject = JsonConvert.SerializeObject(newAgreement);

            using (var content = new StringContent(serializedObject, Encoding.UTF8))
            {
                content.Headers.Remove("Content-Type");
                content.Headers.Add("Content-Type", "application/json");

                ////content.Headers.Remove("x-api-user");
                ////content.Headers.Add("x-api-user", "email:raghu.kotha@icertis.com");


                client.DefaultRequestHeaders.Remove("Authorization");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + this.accessToken);

                var result = await client.PostAsync(apiEndpointVer + "/agreements", content).ConfigureAwait(false);
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var agreement = JsonConvert.DeserializeObject<AgreementCreationResponse>(response);

                    return agreement;
                }
                else
                {
                    var response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    
                    return null;
                }
            }
        }
        
        /// <inheritdoc />        
        public async Task<UsersInfo> GetUser(string emailAddress)
        {
            var usersInfo = new UsersInfo();
            var result = await client.GetAsync(apiEndpointVer + "/users?x-user-email=" + emailAddress).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                usersInfo = JsonConvert.DeserializeObject<UsersInfo>(response);
            }
            else
            {
                string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);

            }
            return usersInfo;
        }

        /// <inheritdoc />       
        public async Task<UserDetailsInfo> GetUserDetailsInfo(string userId)
        {
            var userInfo = new UserDetailsInfo();
            var result = await client.GetAsync(apiEndpointVer + "/users/" + userId).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                userInfo = JsonConvert.DeserializeObject<UserDetailsInfo>(response);
            }
            else
            {
                string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                /*Error*/
            }
            return userInfo;
        }

        /// <inheritdoc />        
        public async Task<AgreementDocuments> GetAgreementDocuments(string agreementId)
        {
            var result = await client.GetAsync(apiEndpointVer + "/agreements/" + agreementId + "/documents").ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                var agreement = JsonConvert.DeserializeObject<AgreementDocuments>(response);

                return agreement;
            }
            else
            {
                var response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                

                return null;
            }
        }

        /// <inheritdoc />      
        public async Task<AgreementInfo> GetAgreement(string agreementId)
        {
            HttpResponseMessage result = await client.GetAsync(apiEndpointVer + "/agreements/" + agreementId).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                AgreementInfo agreement = JsonConvert.DeserializeObject<AgreementInfo>(response);

                return agreement;
            }
            else
            {
                string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                

                return null;
            }
        }

        /// <inheritdoc />      
        public async Task<byte[]> GetAgreementDocument(string agreementId, string documentId)
        {
            var result = await client.GetAsync(apiEndpointVer + "/agreements/" + agreementId + "/documents/" + documentId)
                .ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

                return response;
            }
            else
            {
                var response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                

                return null;
            }
        }

        /// <inheritdoc />     
        public async Task<byte[]> GetAgreementDocumentWithAuditTrail(string agreementId, string documentId)
        {
            var resultDocument = await client.GetAsync(apiEndpointVer + "/agreements/" + agreementId + "/documents/" + documentId)
                .ConfigureAwait(false);
            if (resultDocument.IsSuccessStatusCode)
            {
                var responseDocument = await resultDocument.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                var auditTrail = await client.GetAsync(apiEndpointVer + "/agreements/" + agreementId + "/auditTrail")
                .ConfigureAwait(false);

                if (auditTrail.IsSuccessStatusCode)
                {
                    using (var consolidateDocument = new MemoryStream())
                    {
                        var responseAuditTrail = await auditTrail.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                        var consolidatedFile = new PdfFileEditor();
                        consolidatedFile.Concatenate(new MemoryStream(responseDocument), new MemoryStream(responseAuditTrail), consolidateDocument);

                        responseDocument = consolidateDocument.ToArray();
                    }
                }

                return responseDocument;
            }
            else
            {
                var response = await resultDocument.Content.ReadAsStringAsync().ConfigureAwait(false);                

                return null;
            }
        }

        /// <inheritdoc />      
        public async Task<bool> CancelAgreement(string agreementId, string comment, bool notifySigner)
        {
            var info = new AgreementStatusUpdateInfo
            {
                Value = "CANCEL",
                NotifySigner = notifySigner.ToString(),
                Comment = comment
            };

            var serializedObject = JsonConvert.SerializeObject(info);

            using (var content = new StringContent(serializedObject))
            {
                content.Headers.Remove("Content-Type");
                content.Headers.Add("Content-Type", "application/json");

                var result = await client.PutAsync(apiEndpointVer + "/agreements/" + agreementId + "/status", content).ConfigureAwait(false);
                if (result.IsSuccessStatusCode)
                {
                    await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return true;
                }
                else
                {
                    var response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    /* TODO: AC: Error handeling */
                    return false;
                }
            }
        }

        /// <inheritdoc />     
        public async Task<Stream> GetFormData(string agreementId)
        {
            var result = await client.GetAsync(apiEndpointVer + "/agreements/" + agreementId + "/formData").ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStreamAsync().ConfigureAwait(false);
                return response;
            }
            else
            {
                var response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                

                return null;
            }
        }

        /// <inheritdoc />      
        public async Task<WebhookCreationResponse> CreateWebHook(WebhookInfo newWebHook)
        {
            var serializedObject = JsonConvert.SerializeObject(newWebHook);

            using (var content = new StringContent(serializedObject, Encoding.UTF8))
            {
                content.Headers.Remove("Content-Type");
                content.Headers.Add("Content-Type", "application/json");

                client.DefaultRequestHeaders.Remove("Authorization");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + this.accessToken);

                var result = await client.PostAsync(apiEndpointVer + "/webhooks", content).ConfigureAwait(false);
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var webHook = JsonConvert.DeserializeObject<WebhookCreationResponse>(response);

                    return webHook;
                }
                else
                {
                    var response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);

                    return null;
                }
            }
        }
        
        /// <inheritdoc />        
        public async Task<AgreementViews> ViewAgreement(string agreementId, AgreementViewInfo agreementViewInfo)
        {
            var serializedObject = JsonConvert.SerializeObject(agreementViewInfo);

            using (var content = new StringContent(serializedObject, Encoding.UTF8))
            {
                content.Headers.Remove("Content-Type");
                content.Headers.Add("Content-Type", "application/json");

                client.DefaultRequestHeaders.Remove("Authorization");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + this.accessToken);

                var result = await client.PostAsync($"{apiEndpointVer}/agreements/{agreementId}/views", content).ConfigureAwait(false);
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);

                    return JsonConvert.DeserializeObject<AgreementViews>(response); ;
                }
                else
                {
                    var response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);

                    return null;
                }
            }
        }

    }
}
