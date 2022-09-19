//  -------------------------------------------------------------------------
//  <copyright file="IEchoSignRestHelper.cs"  company="Icertis Inc.">
//      Copyright (c) 2014 Icertis Inc. All Rights Reserved.
//  </copyright>
// 
//  <summary>
//       EchoSing Helper
//  </summary>
//  -------------------------------------------------------------------------

using System.IO;
using System.Threading.Tasks;
using EchosignRESTClient.Models;
using EchosignRESTClient.Models.AgreementInfo;
using EchosignRESTClient.Models.AgreementView;
using EchosignRESTClient.Models.WebHook;
using Icertis.CLM.ESignAdapter.Model.EchoSignRest;

namespace EchosignRESTClient.Helper
{
    /// <summary>
    /// Helper to assit EchoSign related executions
    /// </summary>
    public interface IEchoSignRestHelper
    {
        /// <summary>
        /// Sets the user (by email) from your Echosign account that will be used in the operations
        /// </summary>
        string UserEmail
        {
            set;
        }

        /// <summary>
        /// Uploads a document and obtains the document's ID to use in an Agreement.
        /// </summary>
        /// <param name="fileName">The name for the Transient Document</param>
        /// <param name="file">The document file</param>
        /// <param name="mimeType">(Optional) The mime type for the document</param>
        /// <returns>Returns the uploaded document ID</returns>
        Task<TransientDocument> UploadTransientDocument(string fileName, byte[] file, string mimeType = null);

        /// <summary>
        /// Creates an agreement. Sends it out for signatures, and returns the agreementID in the response to the client
        /// </summary>
        /// <param name="newAgreement">Information about the agreement</param>
        /// <returns>AgreementCreationResponse</returns>
        Task<AgreementCreationResponse> CreateAgreement(AgreementInfo newAgreement);

        /// <summary>
        /// Get Users on your Echosign account.
        /// </summary>
        /// <returns>List of Users</returns>
        Task<UsersInfo> GetUser(string emailAddress);

        /// <summary>
        /// Get detailed information about the user in the Echosign account.
        /// </summary>
        /// <returns>Detailed information about the user</returns>
        Task<UserDetailsInfo> GetUserDetailsInfo(string userId);

        /// <summary>
        /// Retrieves the IDs of all the main and supporting documents of an agreement identified by agreementid
        /// </summary>
        /// <param name="agreementId">The agreement identifier, as returned by the agreement creation API or retrieved from the API to fetch agreements</param>
        /// <returns>AgreementInfo</returns>
        Task<AgreementDocuments> GetAgreementDocuments(string agreementId);

        /// <summary>
        ///  Retrives agreement information for agreement id
        /// </summary>
        /// <param name="agreementId"></param>
        /// <returns></returns>
        Task<AgreementInfo> GetAgreement(string agreementId);

        /// <summary>
        /// Retrieves the file stream of a document of an agreement
        /// </summary>
        /// <param name="agreementId">The agreement identifier, as returned by the agreement creation API or retrieved from the API to fetch agreements</param>
        /// <param name="documentId">The document identifier, as retrieved from the API which fetches the documents of a specified agreement</param>
        /// <returns>AgreementInfo</returns>
        Task<byte[]> GetAgreementDocument(string agreementId, string documentId);

        /// <summary>
        /// Retrieves the file stream of a document of an agreement along with Audit trail
        /// </summary>
        /// <param name="agreementId">The agreement identifier, as returned by the agreement creation API or retrieved from the API to fetch agreements</param>
        /// <param name="documentId">The document identifier that need to sync back</param>
        /// <returns>AgreementInfo</returns>
        Task<byte[]> GetAgreementDocumentWithAuditTrail(string agreementId, string documentId);

        /// <summary>
        /// Cancels an agreement
        /// </summary>
        /// <param name="agreementId">The agreement identifier, as returned by the agreement creation API or retrieved from the API to fetch agreements</param>
        /// <param name="comment">An optional comment describing to the recipient why you want to cancel the transaction</param>
        /// <param name="notifySigner">Whether or not you would like the recipient to be notified that the transaction has been cancelled. The notification is mandatory if any party has already signed this document. The default value is false</param>
        /// <returns>AgreementStatusUpdateResponse</returns>
        Task<bool> CancelAgreement(string agreementId, string comment, bool notifySigner);

        /// <summary>
        /// Cancels an agreement
        /// </summary>
        /// <param name="agreementId">The agreement identifier, as returned by the agreement creation API or retrieved from the API to fetch agreements</param>
        /// <returns>AgreementStatusUpdateResponse</returns>
        Task<Stream> GetFormData(string agreementId);
        
        /// <summary>
        /// Creates an webhook. Creates a webhook and Sends it out with agreement.
        /// </summary>
        /// <param name="agreementId">Information about the agreement</param>
        /// <param name="agreementViewInfo">Information about the agreement</param>        
        /// <returns>AgreementCreationResponse</returns>
        Task<AgreementViews> ViewAgreement(string agreementId, AgreementViewInfo agreementViewInfo);
        
        /// <summary>
        /// Creates an webhook. Creates a webhook and Sends it out with agreement.
        /// </summary>
        /// <param name="newWebHook">Information about the agreement</param>
        /// <returns>AgreementCreationResponse</returns>
        Task<WebhookCreationResponse> CreateWebHook(WebhookInfo newWebHook);
    }
}
