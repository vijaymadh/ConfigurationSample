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
    public class FileUploadOptions
    {
        /// <summary>
        /// optional : Whether library documents link should appear or not.Default value is taken as true
        /// </summary>
        public bool libraryDocument { get; set; }

        /// <summary>
        /// optional : Whether local file upload button should appear or not.Default value is taken as true
        /// </summary>
        public bool localFile { get; set; }

        /// <summary>
        /// optional : Whether link to attach documents from web sources like Dropbox should appear or not. Default value is taken as true
        /// </summary>
        public bool webConnectors { get; set; }
    }
}