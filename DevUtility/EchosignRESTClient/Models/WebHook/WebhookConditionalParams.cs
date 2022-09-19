namespace EchosignRESTClient.Models.WebHook
{
    public class WebhookConditionalParams
    {
        /// <summary>
        /// optional: Conditional parameters for webhook agreement events
        /// </summary>
        public WebhookAgreementEvents webhookAgreementEvents { get; set; }

        /// <summary>
        /// optional: Conditional parameters for webhook library document events
        /// </summary>
        public WebhookLibraryDocumentEvents webhookLibraryDocumentEvents { get; set; }

        /// <summary>
        /// optional: Conditional parameters for webhook megasign events
        /// </summary>
        public WebhookMegaSignEvents webhookMegaSignEvents { get; set; }

        /// <summary>
        /// optional: Conditional parameters for webhook web form events
        /// </summary>
        public WebhookWidgetEvents webhookWidgetEvents { get; set; }
    }
}