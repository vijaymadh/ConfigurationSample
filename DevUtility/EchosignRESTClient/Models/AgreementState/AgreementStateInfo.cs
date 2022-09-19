using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchosignRESTClient.Models
{
    public class AgreementStateInfo    
    {
        /// <summary>
        /// Gets or sets the state. ['AUTHORING' or 'CANCELLED' or 'IN_PROCESS']: The state in which the agreement should land
        /// </summary>
        public string state { get; set; }
        public AgreementCancellationInfo agreementCancellationInfo { get; set; }        
    }
}
