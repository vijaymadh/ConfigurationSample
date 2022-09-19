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
    public class CommonViewConfiguration
    {
        /// <summary>
        /// optional : Auto LogIn Flag.If true, the URL returned will automatically log the user in. If false, the URL returned will require the credentials.By default its value is false
        /// </summary>
        public bool autoLoginUser { get; set; }

        /// <summary>
        /// optional: Message template locale
        /// </summary>
        public bool locale { get; set; }
        
        /// <summary>
        /// optional : No Chrome Flag.If true, the embedded page is shown without a navigation header or footer.If false, the standard page header and footer will be present.By default its value is false
        /// </summary>
        public bool noChrome { get; set; }
    }
}