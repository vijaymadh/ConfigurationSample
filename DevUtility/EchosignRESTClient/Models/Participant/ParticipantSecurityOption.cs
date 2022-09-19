namespace EchosignRESTClient.Models
{
    public class ParticipantSecurityOption
    {
        /// <summary>
        ///  ['NONE' or 'PASSWORD' or 'PHONE' or 'KBA' or 'WEB_IDENTITY' or 'ADOBE_SIGN' or 'GOV_ID']: The authentication method for the participants to have access to view 
        ///  and sign the document. When replacing a participant that has PASSWORD or PHONE authentication specified, you must supply a password or phone number for the new 
        ///  participant, and you cannot change the authentication method,
        /// </summary>
        public string authenticationMethod { get; set; }

        /// <summary>
        /// optional: The password required for the participant to view and sign the document. 
        /// Note that AdobeSign will never show this password to anyone, so you will need to separately communicate it to any relevant parties. 
        /// The password will not be returned in GET call. When replacing a participant that has PASSWORD authentication specified, you must supply a password for the new participant
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// optional: The phoneInfo required for the participant to view and sign the document
        /// </summary>
        public PhoneInfo phoneInfo { get; set; }

    }
}