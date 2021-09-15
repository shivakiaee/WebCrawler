namespace WebCrawler.Models
{
    /// <summary>
    /// Keeps Links
    /// </summary>
    public class LinkQueue
    {
        public bool IsCrawled { get; set; }
        public string Link { get; set; }
    }
}
