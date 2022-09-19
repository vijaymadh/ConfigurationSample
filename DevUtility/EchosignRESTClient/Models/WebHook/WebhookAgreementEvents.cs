namespace EchosignRESTClient.Models.WebHook
{
    public class WebhookAgreementEvents
    {
        /// <summary>
        /// optional: Determines whether agreement detailed info will be returned in the response payload
        /// </summary>
        public bool includeDetailedInfo { get; set; }

        /// <summary>
        /// optional : Determines whether document info will be returned in the response payload
        /// </summary>
        public bool includeDocumentsInfo { get; set; }

        /// <summary>
        /// optional : Determines whether participants info will be returned in the response payload
        /// </summary>
        public bool includeParticipantsInfo { get; set; }

        /// <summary>
        /// optional : Determines whether documents will be returned in webhook response payload.If set to true, signed document will be returned in base 64 encoded format in JSON when signing is complete
        /// </summary>
        public bool includeSignedDocuments { get; set; }

    }
}