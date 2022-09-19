using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchosignRESTClient.Models
{
    public class ParticipantSetInfo
    {
        public string status { get; set; }

        public string participantSetId { get; set; }

        /// <summary>
        /// Array of ParticipantInfo objects, containing participant-specific data (e.g. email). All participants in the array belong to the same set
        /// </summary>
        public IList<ParticipantInfo> participantSetMemberInfos { get; set; }

        /// <summary>
        /// Index indicating position at which signing group needs to sign. Signing group to sign at first place is assigned a 1 index. Different signingOrder specified in 
        /// input should form a valid consecutive increasing sequence of integers. Otherwise signingOrder will be considered invalid. No signingOrder should be specified for SHARE role
        /// </summary>
        public int signingOrder { get; set; }

        /// <summary>
        ///  ['SIGNER' or 'APPROVER' or 'ACCEPTOR' or 'CERTIFIED_RECIPIENT' or 'FORM_FILLER' or 'DELEGATE_TO_SIGNER' or 'DELEGATE_TO_APPROVER' or 'DELEGATE_TO_ACCEPTOR' or 
        ///  'DELEGATE_TO_CERTIFIED_RECIPIENT' or 'DELEGATE_TO_FORM_FILLER' or 'SHARE']: Role assumed by all participants in the set (signer, approver etc.),
        /// </summary>
        public List<string> roles { get; set; }

        /// <summary>
        ///  optional): The unique label of a participant set.
        ///  For custom workflows, label specified in the participation set should map it to the participation step in the custom workflow
        /// </summary>
        public string label { get; set; }

        /// <summary>
        ///  optional: Name of the participant set (it can be empty, but needs not to be unique in a single agreement). Maximum no of characters in participant set name is restricted to 255
        /// </summary>
        public string name { get; set; }

        /// <summary>
        ///   optional: Participant set's private message - all participants in the set will receive the same message
        /// </summary>
        public string privateMessage { get; set; }

        /// <summary>
        ///   optional): When you enable limited document visibility (documentVisibilityEnabled), you can specify which file (fileInfo) should be made visible to which specific participant set. 
        ///   Specify one or more label values of a fileInfos element. Each signer participant sets must contain at least one required signature field in at least one visible file included in 
        ///   this API call; if not a page with a signature field is automatically appended for any missing participant sets.If there is a possibility that one or more participant sets 
        ///   do not have a required signature field in the files included in the API call, all signer participant sets should include a special index value of '0' to make this 
        ///   automatically appended signature page visible to the signer. Not doing so may result in an error. For all other roles, you may omit this value to exclude this page
        /// </summary>
        public string visiblePages { get; set; }       

    }
}
