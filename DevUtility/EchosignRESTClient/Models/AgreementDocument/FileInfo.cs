using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchosignRESTClient.Models
{
    public class FileInfo
    {
        /// <summary>
        /// A document that is associated with the agreement. This field cannot be provided in POST call. In case of GET call, this is the only field returned in the response
        /// </summary>
        public Document document { get; set; }


        /// <summary>
        /// Optional: The unique label value of a file info element. In case of custom workflow this will map a file to corresponding file element in workflow definition. This must be specified in case of custom workflow agreement creation request 
        /// </summary>
        public string label { get; set; }


        /// <summary>
        /// Optional: D for an existing Library document that will be added to the agreement
        /// </summary>
        public string libraryDocumentId { get; set; }


        /// <summary>
        ///  Optional: ID for a transient document that will be added to the agreement
        /// </summary>
        public string transientDocumentId { get; set; }

        /// <summary>
        /// Optional:  URL for an external document to add to the agreement
        /// </summary>
        public URLFileInfo documentURL { get; set; }
        
    }
}
