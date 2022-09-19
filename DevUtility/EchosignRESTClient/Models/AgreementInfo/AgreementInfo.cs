using System.Collections.Generic;

namespace EchosignRESTClient.Models.AgreementInfo
{
    public class AgreementInfo
    {
        /// <summary>
        ///  list of one or more files (or references to files) that will be sent out for signature. If more than one file is provided, 
        ///  they will be combined into one PDF before being sent out. Note: Only one of the four parameters in every FileInfo object must be specified
        /// </summary>
        public List<FileInfo> fileInfos { get; set; }

        /// <summary>
        /// The name of the agreement that will be used to identify it, in emails, website and other places
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// A list of one or more participant set. A participant set may have one or more participant. If any member of the participant set takes the action that has been assigned to
        /// the set(Sign/Approve/Acknowledge etc ), the action is considered as the action taken by whole participation set. For regular (non-MegaSign) documents, there
        /// is no limit on the number of electronic signatures in a single document. Written signatures are limited to four per document
        /// </summary>
        public List<ParticipantSetInfo> participantSetInfos { get; set; }

        /// <summary>
        /// ['ESIGN' or 'WRITTEN']: Specifies the type of signature you would like to request - written or e-signature. The possible values are ESIGN : Agreement
        /// needs to be signed electronically , WRITTEN : Agreement will be signed using handwritten signature and signed document will be uploaded into the system
        /// </summary>
        public string signatureType { get; set; }

        /// <summary>
        /// ['AUTHORING' or 'DRAFT' or 'IN_PROCESS']: The state in which the agreement should land. The state field can only be provided in POST calls, will never get returned
        /// in GET /agreements/{ID} and will be ignored if provided in PUT /agreements/{ID} call. The eventual status of the agreement can be obtained from GET /agreements/ID
        /// </summary>
        public string state { get; set; }

        /// <summary>
        /// optional: A list of one or more CCs that will be copied in the agreement transaction. The CCs will each receive an email at the beginning of 
        /// the transaction and also when the final document is signed. The email addresses will also receive a copy of the document, attached as a PDF file. Should not be provided in offline agreement creation
        /// </summary>
        public List<CcInfo> ccs { get; set; }

        /// <summary>
        /// optional: An arbitrary value from your system, which can be specified at sending time and then later returned or queried. Should not be provided in offline agreement creation.
        /// </summary>
        public string externalId { get; set; }

        /// <summary>
        /// optional: An optional message to the participants, describing what is being sent or why their signature is required
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// The locale associated with this agreement - for example, en_US or fr_FR
        /// </summary>
        public string locale { get; set; }
        
        /// <summary>
        ///  ['OUT_FOR_SIGNATURE' or 'WAITING_FOR_REVIEW' or 'SIGNED' or 'APPROVED' or 'ABORTED' or 'DOCUMENT_LIBRARY' or 
        ///  'WIDGET' or 'EXPIRED' or 'ARCHIVED' or 'PREFILL' or 'AUTHORING' or 'WAITING_FOR_FAXIN' or 'WAITING_FOR_VERIFICATION' 
        ///  or 'WIDGET_WAITING_FOR_VERIFICATION' or 'WAITING_FOR_PAYMENT' or 'OUT_FOR_APPROVAL' or 'OTHER']: The current status of the document
        /// </summary>
        public string status { get; set; } 
        
        public List<Event> events { get; set; }
    }
}
