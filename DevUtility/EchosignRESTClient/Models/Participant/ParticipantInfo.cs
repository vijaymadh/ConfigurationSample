using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchosignRESTClient.Models
{
    public class ParticipantInfo
    {
        /// <summary>
        /// Email of the participant. In case of creating new Agreements(POST/PUT), this is a required field. In case of GET, this is the required field and will 
        /// always be returned unless it is a fax workflow( legacy agreements) that were created using fax as input
        /// </summary>
        public string email { get; set; }

        public string name { get; set; }

        public string participantId { get; set; }

        /// <summary>
        /// optional: Security options that apply to the participant
        /// </summary>
        public ParticipantSecurityOption securityOption { get; set; }        
    }
}
