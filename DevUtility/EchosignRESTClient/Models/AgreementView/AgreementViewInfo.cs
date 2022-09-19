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
    public class AgreementViewInfo
    {
        /// <summary>
        /// ['COMPOSE' or 'MODIFY' or 'PREFILL' or 'AUTHORING' or 'SEND_PROGRESS' or 'POST_CREATE' or 'DOCUMENT' or 'MANAGE' or 'SIGNING' or 'ALL']: Name of the requested agreement view
        /// </summary>
        public string name  { get; set; }

        /// <summary>
        /// optional: Common view configuration for all the available views
        /// </summary>
        public CommonViewConfiguration commonViewConfiguration { get; set; }

        /// <summary>
        /// optional: Compose page view configuration
        /// </summary>
        public ComposeViewConfiguration composeViewConfiguration { get; set; }        

    }
}