using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchosignRESTClient.Models
{
    public class SupportingDocument
    {
        /// <summary>
        /// Display name of the document
        /// </summary>
        public string displayLabel { get; set; }

        /// <summary>
        /// The name of the supporting document field
        /// </summary>
        public string fieldName { get; set; }

        /// <summary>
        /// The name of the supporting document field
        /// </summary>
        public string id { get; set; }
        
        /// <summary>
        /// Mime-type of the document
        /// </summary>
        public string mimeType { get; set; }

        /// <summary>
        /// Number of pages in the document
        /// </summary>
        public int numPages { get; set; }

        /// <summary>
        /// Id representing the document
        /// </summary>
        public string participantId { get; set; }
    }
}
