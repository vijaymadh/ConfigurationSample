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
    public class ComposeViewConfiguration
    {
        /// <summary>
        /// optional : Controls various file upload options available on the compose page
        /// </summary>
        public FileUploadOptions fileUploadOptions { get; set; }

        /// <summary>
        /// optional : Should the compose page be provided with authoring mode selected?
        /// </summary>
        public bool isPreviewSelected { get; set; }

    }
}