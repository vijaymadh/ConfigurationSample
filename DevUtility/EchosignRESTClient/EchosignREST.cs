using EchosignRESTClient.Models;
using EchosignRESTClient.ErrorHandling;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using EchosignRESTClient.Models.AgreementInfo;

namespace EchosignRESTClient
{
    /// <summary>
    ///  EchosignREST client for working with the Echosign REST v5+ api
    /// </summary>
    public class EchosignREST : IDisposable
    {
        private readonly HttpClient client;

        private readonly string clientId;
        private readonly string secretId;

        private string accessToken;
        private int accessTokenExpires;
        private string refreshToken;

        private readonly string apiUrl;
        private string apiEndpointVer = "api/rest/v6";

        /// <summary>
        /// Initialize EchosignREST without Access Token. Must call Authorize() after initialization to acquire Access Token.
        /// </summary>
        /// <param name="apiUrl">API url returned from the authorization request URL</param>
        /// <param name="clientId">Application/Client ID</param>
        /// <param name="secretId">Client Secret</param>
        public EchosignREST(string apiUrl, string clientId, string secretId)
        {
            this.apiUrl = apiUrl;
            this.clientId = clientId;
            this.secretId = secretId;

            this.client = new HttpClient();
            this.client.BaseAddress = new Uri(apiUrl);
        }

        /// <summary>
        /// Obtain Access Token for the Echosign REST API (use only if you don't already have a Refresh Token, or if it is expired)
        /// </summary>
        /// <param name="authCode">Authorization code received from the authorization request</param>
        /// <param name="redirect_uri">Redirect URI matching the one specified in the authorization request</param>
        /// <returns></returns>
        public async Task GetRefreshToken(string authCode, string redirect_uri)
        {
            using (HttpContent content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("client_id", this.clientId),
                new KeyValuePair<string, string>("client_secret", this.secretId),
                new KeyValuePair<string, string>("code", authCode),
                new KeyValuePair<string, string>("redirect_uri", redirect_uri)
            }))
            {
                HttpResponseMessage result = await this.client.PostAsync("oauth/token", content).ConfigureAwait(false);
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync();
                    TokenResponse tokenObj = JsonConvert.DeserializeObject<TokenResponse>(response);

                    this.accessToken = tokenObj.access_token;
                    this.accessTokenExpires = tokenObj.expires_in;
                    this.refreshToken = tokenObj.refresh_token;

                    this.client.DefaultRequestHeaders.Remove("Access-Token");
                    this.client.DefaultRequestHeaders.Add("Access-Token", this.accessToken);
                }
                else
                {
                    string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    this.HandleError(result.StatusCode, response, true);
                }
            }


        }

        /// <summary>
        /// Refresh existing Access Token with the Refresh Token.
        /// </summary>
        /// <param name="refreshToken">Refresh Token used to get a new Access Token.</param>
        /// <returns></returns>
        public async Task Authorize(string refreshToken)
        {
            using (HttpContent content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "refresh_token"),
                new KeyValuePair<string, string>("client_id", this.clientId),
                new KeyValuePair<string, string>("client_secret", this.secretId),
                new KeyValuePair<string, string>("refresh_token", refreshToken)
            }))
            {
                HttpResponseMessage result = await this.client.PostAsync("oauth/refresh", content).ConfigureAwait(false);
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    RefreshTokenResponse tokenObj = JsonConvert.DeserializeObject<RefreshTokenResponse>(response);

                    this.accessToken = tokenObj.access_token;
                    this.accessTokenExpires = tokenObj.expires_in;

                    this.client.DefaultRequestHeaders.Remove("Access-Token");
                    this.client.DefaultRequestHeaders.Add("Access-Token", this.accessToken);
                }
                else
                {
                    string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    this.HandleError(result.StatusCode, response, true);
                }
            }
        }

        /// <summary>
        /// Revoke Access and Refresh tokens so they cannot be used again until next authorization.
        /// </summary>
        /// <param name="token">Access or Refresh token.</param>
        /// <returns></returns>
        public async Task Revoke(string token)
        {
            using (HttpContent content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("token", token)
            }))
            {
                HttpResponseMessage result = await this.client.PostAsync("oauth/revoke", content).ConfigureAwait(false);
                if (!result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    this.HandleError(result.StatusCode, response, true);
                }
            }
        }

        /// <summary>
        /// Uploads a document and obtains the document's ID to use in an Agreement.
        /// </summary>
        /// <param name="fileName">The name for the Transient Document</param>
        /// <param name="file">The document file</param>
        /// <param name="mimeType">(Optional) The mime type for the document</param>
        /// <returns>Returns the uploaded document ID</returns>
        public async Task<TransientDocument> UploadTransientDocument(string fileName, byte[] file, string mimeType = null)
        {
            using (MultipartFormDataContent content = new MultipartFormDataContent())
            {
                content.Add(new StreamContent(new MemoryStream(file)), "File", "sample.pdf");
                content.Add(new StringContent(fileName), "File-Name");

                if (mimeType != null)
                {
                    content.Add(new StringContent(mimeType), "Mime-Type");
                }

                HttpResponseMessage result = await this.client.PostAsync(this.apiEndpointVer + "/transientDocuments", content);
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    TransientDocument document = JsonConvert.DeserializeObject<TransientDocument>(response);

                    return document;
                }
                else
                {
                    string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    this.HandleError(result.StatusCode, response, false);

                    return null;
                }
            }
        }

        /// <summary>
        /// Creates an agreement. Sends it out for signatures, and returns the agreementID in the response to the client
        /// </summary>
        /// <param name="newAgreement">Information about the agreement</param>
        /// <returns>AgreementCreationResponse</returns>
        public async Task<AgreementCreationResponse> CreateAgreement(AgreementInfo newAgreement)
        {
            string serializedObject = JsonConvert.SerializeObject(newAgreement);

            using (StringContent content = new StringContent(serializedObject, Encoding.UTF8))
            {
                content.Headers.Remove("Content-Type");
                content.Headers.Add("Content-Type", "application/json");

                HttpResponseMessage result = await this.client.PostAsync(this.apiEndpointVer + "/agreements", content).ConfigureAwait(false);
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    AgreementCreationResponse agreement = JsonConvert.DeserializeObject<AgreementCreationResponse>(response);

                    return agreement;
                }
                else
                {
                    string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    this.HandleError(result.StatusCode, response, false);

                    return null;
                }
            }
        }

        /////// <summary>
        /////// Creates a new alternate participant
        /////// </summary>
        /////// <param name="agreementId">The agreement identifier, as returned by the agreement creation API or retrieved from the API to fetch agreements</param>
        /////// <param name="participantSetId">The participant set identifier</param>
        /////// <param name="participantId">The participant identifier</param>
        /////// <param name="participantInfo">Information about the alternate participant</param>
        /////// <returns>AlternateParticipantResponse</returns>
        ////public async Task<AlternateParticipantResponse> AddParticipant(string agreementId, string participantSetId, string participantId, AlternateParticipantInfo participantInfo)
        ////{
        ////    string serializedObject = JsonConvert.SerializeObject(participantInfo);

        ////    using (StringContent content = new StringContent(serializedObject, Encoding.UTF8))
        ////    {
        ////        content.Headers.Remove("Content-Type");
        ////        content.Headers.Add("Content-Type", "application/json");

        ////        HttpResponseMessage result = await client.PostAsync(apiEndpointVer + "/agreements/" + agreementId + "/participantSets/" +
        ////                                                participantSetId + "/participants/" + participantId + "/alternateParticipants", content)
        ////                                                .ConfigureAwait(false);
        ////        if (result.IsSuccessStatusCode)
        ////        {
        ////            string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
        ////            AlternateParticipantResponse agreement = JsonConvert.DeserializeObject<AlternateParticipantResponse>(response);

        ////            return agreement;
        ////        }
        ////        else
        ////        {
        ////            string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
        ////            HandleError(result.StatusCode, response, false);

        ////            return null;
        ////        }
        ////    }
        ////}

        ///// <summary>
        ///// Retrieves agreements for the user
        ///// </summary>
        ///// <returns>UserAgreements</returns>
        //public async Task<UserAgreements> GetAgreements()
        //{
        //    HttpResponseMessage result = await client.GetAsync(apiEndpointVer + "/agreements").ConfigureAwait(false);
        //    if (result.IsSuccessStatusCode)
        //    {
        //        string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
        //        UserAgreements agreements = JsonConvert.DeserializeObject<UserAgreements>(response);

        //        return agreements;
        //    }
        //    else
        //    {
        //        string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
        //        HandleError(result.StatusCode, response, false);

        //        return null;
        //    }
        //}

        /// <summary>
        /// Retrieves the latest status of an agreement
        /// </summary>
        /// <param name="agreementId">The agreement identifier, as returned by the agreement creation API or retrieved from the API to fetch agreements</param>
        /// <returns>AgreementInfo</returns>
        public async Task<AgreementInfo> GetAgreement(string agreementId)
        {
            HttpResponseMessage result = await this.client.GetAsync(this.apiEndpointVer + "/agreements/" + agreementId).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                AgreementInfo agreement = JsonConvert.DeserializeObject<AgreementInfo>(response);

                return agreement;
            }
            else
            {
                string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                this.HandleError(result.StatusCode, response, false);

                return null;
            }
        }

        /// <summary>
        /// Retrieves the IDs of all the main and supporting documents of an agreement identified by agreementid
        /// </summary>
        /// <param name="agreementId">The agreement identifier, as returned by the agreement creation API or retrieved from the API to fetch agreements</param>
        /// <returns>AgreementInfo</returns>
        public async Task<AgreementDocuments> GetAgreementDocuments(string agreementId)
        {
            HttpResponseMessage result = await this.client.GetAsync(this.apiEndpointVer + "/agreements/" + agreementId + "/documents").ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                AgreementDocuments agreement = JsonConvert.DeserializeObject<AgreementDocuments>(response);

                return agreement;
            }
            else
            {
                string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                this.HandleError(result.StatusCode, response, false);

                return null;
            }
        }

        /// <summary>
        /// Retrieves the file stream of a document of an agreement
        /// </summary>
        /// <param name="agreementId">The agreement identifier, as returned by the agreement creation API or retrieved from the API to fetch agreements</param>
        /// <param name="documentId">The document identifier, as retrieved from the API which fetches the documents of a specified agreement</param>
        /// <returns>AgreementInfo</returns>
        public async Task<Stream> GetAgreementDocument(string agreementId, string documentId)
        {
            HttpResponseMessage result = await this.client.GetAsync(this.apiEndpointVer + "/agreements/" + agreementId + "/documents/" + documentId)
                                                        .ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                Stream response = await result.Content.ReadAsStreamAsync().ConfigureAwait(false);

                return response;
            }
            else
            {
                string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                this.HandleError(result.StatusCode, response, false);

                return null;
            }
        }

        /// <summary>
        /// Cancels an agreement
        /// </summary>
        /// <param name="agreementId">The agreement identifier, as returned by the agreement creation API or retrieved from the API to fetch agreements</param>
        /// <param name="comment">An optional comment describing to the recipient why you want to cancel the transaction</param>
        /// <param name="notifySigner">Whether or not you would like the recipient to be notified that the transaction has been cancelled. The notification is mandatory if any party has already signed this document. The default value is false</param>
        /// <returns>AgreementStatusUpdateResponse</returns>
        public async Task<bool> CancelAgreement(string agreementId, string comment, bool notifySigner)
        {
            var info = new AgreementStatusUpdateInfo
            {
                Value = "CANCEL",
                NotifySigner = notifySigner.ToString(),
                Comment = comment
            };

            var serializedObject = JsonConvert.SerializeObject(info);

            using (HttpContent content = new StringContent(serializedObject))
            {
                content.Headers.Remove("Content-Type");
                content.Headers.Add("Content-Type", "application/json");

                var result = await this.client.PutAsync($"{this.apiEndpointVer}/agreements/{agreementId}/state", content)
                                                        .ConfigureAwait(false);
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return true;
                }
                else
                {
                    var response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    this.HandleError(result.StatusCode, response, false);
                    return false;
                }
            }
        }

        /// <summary>
        /// Deletes an agreement. Agreement will no longer be visible in the user's Manage Page
        /// </summary>
        /// <param name="agreementId">The agreement identifier, as returned by the agreement creation API or retrieved from the API to fetch agreements</param>
        /// <returns>void</returns>
        public async Task DeleteAgreement(string agreementId)
        {
            HttpResponseMessage result = await this.client.DeleteAsync(this.apiEndpointVer + "/agreements/" + agreementId).ConfigureAwait(false);
            if (!result.IsSuccessStatusCode)
            {
                string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                this.HandleError(result.StatusCode, response, false);
            }
        }

        private void HandleError(HttpStatusCode statusCode, string response, bool isOAuthError = false)
        {
            switch (statusCode)
            {
                case HttpStatusCode.Unauthorized:
                    EchosignError error = JsonConvert.DeserializeObject<EchosignError>(response);
                    throw new EchosignOAuthException(error);
                case HttpStatusCode.BadRequest:
                    if (!isOAuthError) // echosign returns different json for oAuth calls
                    {
                        EchosignErrorCode errorCode = JsonConvert.DeserializeObject<EchosignErrorCode>(response);
                        throw new EchosignBadRequestException(errorCode);
                    }
                    else
                    {
                        EchosignError oAuthError = JsonConvert.DeserializeObject<EchosignError>(response);
                        throw new EchosignOAuthException(oAuthError);
                    }
                default:
                    EchosignErrorCode defaultError = JsonConvert.DeserializeObject<EchosignErrorCode>(response);
                    throw new EchosignBadRequestException(defaultError);
            }
        }

        /// <summary>
        /// Creates a user on your Echosign account.
        /// </summary>
        /// <returns></returns>
        public async Task GetUser()
        {
            try
            {

                var result = await this.client.GetAsync(this.apiEndpointVer + "/users").ConfigureAwait(false);
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var usersInfo = JsonConvert.DeserializeObject<UsersInfo>(response);
                }
                else
                {
                    string response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    this.HandleError(result.StatusCode, response, false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }





        public void Dispose()
        {
            if (this.client != null)
            {
                this.client.Dispose();
            }
        }

        /// <summary>
        /// Gets or sets the Access Token obtained from the last authorization request
        /// </summary>
        public string AccessToken
        {
            get => this.accessToken;
            set => this.accessToken = value;
        }

        /// <summary>
        /// Returns the Refresh Token obtained from the last authorization request
        /// </summary>
        public string RefreshToken => this.refreshToken;

        /// <summary>
        /// Get or set API endpoint and version. Default is "api/rest/v5"
        /// </summary>
        public string ApiEndpointVer
        {
            get => this.apiEndpointVer;
            set => this.apiEndpointVer = value;
        }

        /// <summary>
        /// Gets the expiration time of the acquired Access Token (in seconds)
        /// </summary>
        public int AccessTokenExpires => this.accessTokenExpires;

        /// <summary>
        /// Sets the user (by email) from your Echosign account that will be used in the operations
        /// </summary>
        public string UserEmail
        {
            set
            {
                this.client.DefaultRequestHeaders.Remove("x-api-user");
                this.client.DefaultRequestHeaders.Add("x-api-user", "email:" + value);
            }
        }

        /// <summary>
        /// Sets the user (by email) from your Echosign account that will be used in the operations
        /// </summary>
        public string AutoLogin
        {
            set
            {
                this.client.DefaultRequestHeaders.Remove("x-api-user");
                this.client.DefaultRequestHeaders.Add("x-api-user", "email:" + value);
            }
        }
    }
}
