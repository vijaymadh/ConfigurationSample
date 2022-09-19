namespace EchosignRESTClient.Models.AgreementInfo
{
    public class Event
    {
        public string date { get; set; }
        public string description { get; set; }
        public string versionId { get; set; }
        public string actingUserEmail { get; set; }
        public string actingUserIpAddress { get; set; }
        public string participantEmail { get; set; }
        public string type { get; set; }
    }
}