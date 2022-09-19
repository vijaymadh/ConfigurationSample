namespace EchosignRESTClient.Models.AgreementInfo
{
    public class OfflineDeviceInfo
    {
        /// <summary>
        /// Application Description
        /// </summary>
        public string applicationDescription { get; set; }

        /// <summary>
        ///  Device Description
        /// </summary>
        public string deviceDescription { get; set; }

        /// <summary>
        /// optional: The device local time. The device time provided should not be before 30 days of current date.Format should be yyyy-MM-dd'T'HH:mm:ssZ. For example, e.g 2016-02-25T18:46:19Z represents UTC time
        /// </summary>
        public string deviceTime { get; set; }
    }
}