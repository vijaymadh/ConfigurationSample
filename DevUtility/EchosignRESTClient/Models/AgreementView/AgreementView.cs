//  -------------------------------------------------------------------------
//  <copyright file="IEchoSignRestHelper.cs"  company="Icertis Inc.">
//      Copyright (c) 2014 Icertis Inc. All Rights Reserved.
//  </copyright>
// 
//  <summary>
//       EchoSing Helper
//  </summary>
//  -------------------------------------------------------------------------
namespace EchosignRESTClient.Models.AgreementView
{
    public class AgreementView
    {

        /// <summary>
        /// True if this view is the current view
        /// </summary>
        public bool isCurrent { get; set; }

        /// <summary>
        /// ['COMPOSE' or 'MODIFY' or 'PREFILL' or 'AUTHORING' or 'SEND_PROGRESS' or 'POST_CREATE' or 'DOCUMENT' or 'MANAGE' or 'SIGNING' or 'ALL']: Name of the requested agreement view
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// optional: Embedded code of url of resource
        /// </summary>
        public string embeddedCode { get; set; }

        /// <summary>
        /// optional: Expiration of user url
        /// </summary>
        public string expiration { get; set; }

        /// <summary>
        /// optional: Url of resource location
        /// </summary>
        public string url { get; set; }
    }
}