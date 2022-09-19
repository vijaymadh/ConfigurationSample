using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EchosignRESTClient.Models
{
    public class AgreementStatusUpdateInfo
    {
        /// <summary>
        /// Gets or sets The Value
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets The value of Comment
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets The value of Notify Signer
        /// </summary>
        [JsonProperty("notifySigner")]
        public string NotifySigner { get; set; }

    }
}
