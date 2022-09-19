namespace EchosignRESTClient.Models.WebHook
{
    public class WebhookLibraryDocumentEvents
    {
        /// <summary>
        /// optional: Determines whether agreement detailed info will be returned in the response payload
        /// </summary>
        public bool includeDetailedInfo { get; set; }

        /// <summary>
        /// optional: Determines whether document info will be returned in the response payload
        /// </summary>
        public bool includeDocumentsInfo { get; set; }
    }
}