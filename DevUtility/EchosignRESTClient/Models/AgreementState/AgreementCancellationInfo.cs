namespace EchosignRESTClient.Models
{
    public class AgreementCancellationInfo
    {
        /// <summary>
        /// Gets or sets comment: An optional comment describing to the recipients why you want to cancel the transaction
        /// </summary>
        public string comment { get; set; }

        /// <summary>
        /// Gets or sets comment: Whether or not you would like the recipients to be notified that the transaction has been cancelled. The default value is false
        /// </summary>
        public bool notifyOthers { get; set; }

    }
}