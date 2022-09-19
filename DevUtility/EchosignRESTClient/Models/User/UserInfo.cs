using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchosignRESTClient.Models
{
    public class UserInfo
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>        
        public string email { get; set; }

        /// <summary>
        /// A unique identifier of the user resource for REST APIs as issued by Sign
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Gets or sets if user is account admin.
        /// </summary>
        public bool isAccountAdmin { get; set; }

        /// <summary>
        /// Optional: Gets or sets the company.
        /// </summary>        
        public string company { get; set; }

        /// <summary>
        /// Optional: Gets or sets the first name.
        /// </summary>
        public string firstName { get; set; }
                
        /// <summary>
        /// Optional: Gets or sets the last name.
        /// </summary>
        public string lastName { get; set; }

    }
}
