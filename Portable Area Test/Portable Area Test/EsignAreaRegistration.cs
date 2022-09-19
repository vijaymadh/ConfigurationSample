//  -------------------------------------------------------------------------
//  <copyright file="SalesforceAreaRegistration.cs"  company="Icertis Inc.">
//      Copyright (c) 2014 Icertis Inc. All Rights Reserved.
//  </copyright>
// 
//  <summary>
//      SalesForce Area Registration
//  </summary>
//  -------------------------------------------------------------------------

namespace Icertis.CLM.UI.Areas.Salesforce
{
    using System.Web.Mvc;
    /// <summary>
    /// SalesForce Area Registration
    /// </summary>
    public class EsignAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// Namespace for root controllers
        /// </summary>
        private static string rootNamespace = "Icertis.CLM.UI.Controllers";

        /// <summary>
        /// Namespace for area specific controllers
        /// </summary>
        private static string areaNamespace = "Portable_Area_Test.Controllers";

        /// <summary>
        /// Area specific namespaces
        /// </summary>
        private static string[] areaNamespaces = new[] { areaNamespace };

        /// <summary>
        /// Gets area name
        /// </summary>
        public override string AreaName
        {
            get
            {
                return "Esign";
            }
        }

        /// <summary>
        /// Register Area
        /// </summary>
        /// <param name="context">Area Registration Context</param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            RegisterRoutes(context);
        }

        private void RegisterRoutes(AreaRegistrationContext context)
        {

            context.MapRoute(
              name: AreaName,
               url: AreaName+ "/{controller}/{action}/{id}",
              defaults: new { Controller = "EsignCallBack", action = "EchoSignCallBack", id = UrlParameter.Optional },
               namespaces: new[] { areaNamespace });
        }

    }
}
