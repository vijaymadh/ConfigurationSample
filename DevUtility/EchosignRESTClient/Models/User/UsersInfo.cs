using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchosignRESTClient.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class UsersInfo
    {
        /// <summary>
        /// Pagination information for navigating through the response.
        /// </summary>

        public PageInfo page { get; set; }
        
        /// <summary>
        /// Gets or sets the user information list.
        /// </summary>        
        public List<UserInfo> userInfoList { get; set; }
    }
}
