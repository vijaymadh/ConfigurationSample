namespace EchosignRESTClient.Models
{
    public class PhoneInfo
    {
        /// <summary>
        ///  optional: The numeric country calling code (ISD code) required for the participant to view and sign the document if authentication type is PHONE
        /// </summary>
        public string countryCode { get; set; }
        
        /// <summary>
        ///  optional: The country ISO Alpha-2 code required for the participant to view and sign the document if authentication method is PHONE
        /// </summary>
        public string countryIsoCode { get; set; }

        /// <summary>
        ///  optional: The phone number required for the participant to view and sign the document if authentication method is PHONE. When replacing a participant that 
        ///  has PHONE authentication specified, you must supply a phone number for the new participant.
        /// </summary>
        public string phone { get; set; }

    }
}