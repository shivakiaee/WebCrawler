using System.Collections.Generic;
using System.Threading.Tasks;
using WebCrawler.Extensions;
using WebCrawler.Models;
using WebCrawler.Services.Interfaces;

namespace WebCrawler.Services
{
    /// <summary>
    /// Is responsible for crawling and downloading a page with specified url
    /// </summary>
    public class Downloader : IDownloader
    {
        private readonly ICrawler _crawler;
        private readonly IDownloadManager _downloalManager;

        public Downloader(ICrawler crawler, IDownloadManager downloalManager)
        {
            _crawler = crawler;
            _downloalManager = downloalManager;
        }


        /// <summary>
        /// Downloads a page with specified url
        /// </summary>
        /// <param name="url"></param>
        /// <param name="linkQueues"></param>
        /// <returns></returns>
        public async Task Download(string url, List<LinkQueue> linkQueues)
        {
            try
            {
                await _crawler.Crwal(url, linkQueues);

                var result = await _downloalManager.DownloadPage(url);

                if (result)
                {
                    var link = linkQueues.Find(url);
                    link.IsCrawled = true;
                }
            }
            catch
            {
                //todo: WriteLogError for all exceptions
            }

        }
    }
}
