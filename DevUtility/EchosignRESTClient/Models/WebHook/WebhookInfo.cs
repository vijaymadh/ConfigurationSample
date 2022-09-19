using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchosignRESTClient.Models.WebHook
{
    public class WebhookInfo
    {           
        /// <summary>
        /// The name of the webhook
        /// </summary>        
        public string name { get; set; }

        /// <summary>
        ///  ['ACCOUNT' or 'GROUP' or 'USER' or 'RESOURCE']: Scope of webhook. Can't be modified in PUT request. The possible values are ACCOUNT, GROUP, USER or RESOURCE
        /// </summary>
        public string scope { get; set; }

        /// <summary>
        /// ['ACTIVE']: The state in which the webhook should be created
        /// </summary>
        public string state { get; set; }

        /// <summary>
        /// ['AGREEMENT_CREATED' or 'AGREEMENT_ACTION_DELEGATED' or 'AGREEMENT_RECALLED' or 'AGREEMENT_REJECTED' or 'AGREEMENT_EXPIRED' or 'AGREEMENT_ACTION_COMPLETED' or 
        /// 'AGREEMENT_WORKFLOW_COMPLETED' or 'AGREEMENT_EMAIL_VIEWED' or 'AGREEMENT_MODIFIED' or 'AGREEMENT_SHARED' or 'AGREEMENT_VAULTED' or 'AGREEMENT_ACTION_REQUESTED' or 
        /// 'AGREEMENT_ACTION_REPLACED_SIGNER' or 'AGREEMENT_AUTO_CANCELLED_CONVERSION_PROBLEM' or 'AGREEMENT_DOCUMENTS_DELETED' or 'AGREEMENT_EMAIL_BOUNCED' or 'AGREEMENT_KBA_AUTHENTICATED' 
        /// or 'AGREEMENT_OFFLINE_SYNC' or 'AGREEMENT_USER_ACK_AGREEMENT_MODIFIED' or 'AGREEMENT_UPLOADED_BY_SENDER' or 'AGREEMENT_WEB_IDENTITY_AUTHENTICATED' or 'AGREEMENT_ALL' or 
        /// 'MEGASIGN_CREATED' or 'MEGASIGN_RECALLED' or 'MEGASIGN_SHARED' or 'MEGASIGN_ALL' or 'WIDGET_CREATED' or 'WIDGET_MODIFIED' or 'WIDGET_SHARED' or 'WIDGET_ENABLED' or 
        /// 'WIDGET_DISABLED' or 'WIDGET_AUTO_CANCELLED_CONVERSION_PROBLEM' or 'WIDGET_ALL' or 'LIBRARY_DOCUMENT_CREATED' or 'LIBRARY_DOCUMENT_AUTO_CANCELLED_CONVERSION_PROBLEM' or 
        /// 'LIBRARY_DOCUMENT_MODIFIED' or 'LIBRARY_DOCUMENT_ALL']: Determines events for which the webhook is triggered. The possible values are AGREEMENT_CREATED : When an agreement 
        /// is created , AGREEMENT_ACTION_DELEGATED : When an agreement is delegated , AGREEMENT_RECALLED : When an agreement is recalled , AGREEMENT_REJECTED : When an agreement is 
        /// rejected , AGREEMENT_EXPIRED : When an agreement expires, AGREEMENT_ACTION_COMPLETED : When an agreement action is completed , AGREEMENT_WORKFLOW_COMPLETED : When an agreement
        /// workflow is completed , AGREEMENT_EMAIL_VIEWED : When an agreement's email is viewed , AGREEMENT_MODIFIED : When an agreement is modified , AGREEMENT_SHARED : When an 
        /// agreement is shared , AGREEMENT_VAULTED : When an agreement is vaulted , AGREEMENT_ACTION_REQUESTED : When an agreement action is requested , AGREEMENT_ACTION_REPLACED_SIGNER :
        /// When signer is replaced for an agreement, AGREEMENT_AUTO_CANCELLED_CONVERSION_PROBLEM : When an agreement is auto-cancelled due to conversion problem , 
        /// AGREEMENT_DOCUMENTS_DELETED : When an agreement documents are deleted, AGREEMENT_EMAIL_BOUNCED : When an agreement email gets bounced, AGREEMENT_KBA_AUTHENTICATED : When an 
        /// agreement KBA is authenticated , AGREEMENT_OFFLINE_SYNC : When an agreement is synced offline, AGREEMENT_USER_ACK_AGREEMENT_MODIFIED : User Acknowledgement when an agreement 
        /// is modified , AGREEMENT_UPLOADED_BY_SENDER : When an agreement is uploaded by sender , AGREEMENT_WEB_IDENTITY_AUTHENTICATED : When an agreement web identity is authenticated , 
        /// AGREEMENT_ALL : All the supported agreement events for Webhooks , MEGASIGN_CREATED : When a megaSign is created , MEGASIGN_RECALLED : When a megaSign is recalled , 
        /// MEGASIGN_SHARED : When a megaSign is shared , MEGASIGN_ALL : All the supported megaSign events for Webhooks , WIDGET_CREATED : When a web form is created , WIDGET_MODIFIED : 
        /// When a web form is modified , WIDGET_SHARED : When a web form is shared , WIDGET_ENABLED : When a web form is enabled , WIDGET_DISABLED : When a web form is disabled , 
        /// WIDGET_AUTO_CANCELLED_CONVERSION_PROBLEM : When a web form is auto-cancelled due to conversion problem , WIDGET_ALL : All the supported web form events for Webhooks , 
        /// LIBRARY_DOCUMENT_CREATED : When a library document is created , LIBRARY_DOCUMENT_AUTO_CANCELLED_CONVERSION_PROBLEM : When a library document is auto-cancelled due to 
        /// conversion problem , LIBRARY_DOCUMENT_MODIFIED : When a library document is modified , LIBRARY_DOCUMENT_ALL : All the supported library document events for Webhooks
        /// </summary>
        public List<string> webhookSubscriptionEvents { get; set; }

        /// <summary>
        /// Info of webhook ur
        /// </summary>
        public WebhookUrlInfo webhookUrlInfo { get; set; }

        /// <summary>
        /// Optional
        /// </summary>
        public string applicationDisplayName { get; set; }

        /// <summary>
        /// Optional
        /// </summary>
        public string applicationName { get; set; }

        /// <summary>
        /// Optional
        /// </summary>
        public string created { get; set; }

        /// <summary>
        /// Optional-the unique identifier of the webhook. Will only be returned in GET request. Can't be modified in PUT request,
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Optional-Timestamp when the webhook was last updated. Will only be returned in GET request. Can't be modified in PUT reques
        /// </summary>
        public string lastModified { get; set; }

        /// <summary>
        /// Optional-Id of the resource type for which you want to create webhook. Provide agreementId if webhook needs to be created for an agreement. Similarly,
        /// widgetId if webhook needs to be created for a web form, megaSignId if webhook needs to be created for a megaSign and libraryDocumentId if 
        /// webhook needs to be created for a library document. Need to specify only if scope is 'RESOURCE'. Can't be modified in PUT request
        /// </summary>
        public string resourceId { get; set; }

        /// <summary>
        /// optional ['AGREEMENT' or 'WIDGET' or 'MEGASIGN' or 'LIBRARY_DOCUMENT']: The resource for which you want to create webhook. Need to specify only if scope is 'RESOURCE'. 
        /// Can't be modified in PUT request. The possible values are AGREEMENT, WIDGET, MEGASIGN AND LIBRARY_DOCUMENT,
        /// </summary>
        public string resourceType { get; set; }

        /// <summary>
        /// optional ['ACTIVE' or 'INACTIVE']: Status of the webhook. Determines whether the webhook will be actually triggered. Default: ACTIVE, if ACTIVE, this webhook will receive 
        /// event requests. If INACTIVE, this webhook will not receive event requests. Can't provide status in POST/PUT requests.,
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// optional: Conditions which webhook creator can specify for the payload while creating or updating a webhook
        /// </summary>
        public WebhookConditionalParams webhookConditionalParams { get; set; }

    }
}
