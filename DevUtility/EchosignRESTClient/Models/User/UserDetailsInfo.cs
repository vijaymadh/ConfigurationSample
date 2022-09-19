namespace Icertis.CLM.ESignAdapter.Model.EchoSignRest
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Details of User
    /// </summary>
    public class UserDetailsInfo
    {
        /// <summary>
        /// The email address of the user
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets The Status of the user  ['ACTIVE' or 'INACTIVE' or 'CREATED' or 'PENDING' or 'UNVERIFIED']
        /// </summary>
        [JsonProperty("userStatus")]
        public string UserStatus { get; set; }

        /// <summary>
        /// The first name of the user
        /// </summary>
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the user
        /// </summary>
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Name of the group to which the user belongs
        /// </summary>
        [JsonProperty("group")]
        public string group { get; set; }

        /// <summary>
        /// The identifier that can be used in group management methods
        /// </summary>
        [JsonProperty("groupId")]
        public string groupId { get; set; }

    }
}
