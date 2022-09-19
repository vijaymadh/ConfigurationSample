using System.Threading.Tasks;
using EchosignRESTClient.Models;
using System.IO;
using EchosignRESTClient.Models.AgreementInfo;

namespace EchosignRESTClient
{
    public interface IEchosignREST
    {
        string AccessToken { get; set; }
        int AccessTokenExpires { get; }
        string ApiEndpointVer { get; set; }
        string RefreshToken { get; }

        ////Task<AlternateParticipantResponse> AddParticipant(string agreementId, string participantSetId, string participantId, AlternateParticipantInfo participantInfo);
        Task Authorize(string refreshToken);
        Task Authorize(string authCode, string redirect_uri);
        Task<bool> CancelAgreement(string agreementId, string comment, bool notifySigner);          
        Task DeleteAgreement(string agreementId);
        void Dispose();
        Task<AgreementInfo> GetAgreement(string agreementId);
        //Task<UserAgreements> GetAgreements();
        Task<Stream> GetAgreementDocument(string agreementId, string documentId);
        Task<AgreementDocuments> GetAgreementDocuments(string agreementId);        
        Task Revoke(string token);        
        Task<TransientDocument> UploadTransientDocument(string fileName, byte[] file, string mimeType = null);        
        Task GetUser();
    }
}