namespace EchosignRESTClient.Models
{
    public class PageInfo
    {
        /// <summary>
        /// Gets or sets the next cursor. Used to navigate to the next page. If not returned, there are no further pages
        /// </summary>
        public string nextCursor { get; set; }
    }
}