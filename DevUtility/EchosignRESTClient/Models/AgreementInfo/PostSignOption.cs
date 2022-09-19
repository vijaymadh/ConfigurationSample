namespace EchosignRESTClient.Models.AgreementInfo
{
    public class PostSignOption
    {
        /// <summary>
        /// optional: The delay (in seconds) before the user is taken to the success page. If this value is greater than 0, the user will first see the standard Adobe Sign success message, 
        /// and then after a delay will be redirected to your success page
        /// </summary>
        public int redirectDelay { get; set; }

        /// <summary>
        /// optional: A publicly accessible url to which the user will be sent after successfully completing the signing process
        /// </summary>
        public string redirectUrl { get; set; }

    }
}