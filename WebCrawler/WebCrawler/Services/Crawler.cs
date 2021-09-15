using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCrawler.Extensions;
using WebCrawler.Models;
using WebCrawler.Services.Interfaces;

namespace WebCrawler.Services
{
    /// <summary>
    /// Crawls a url to extract <a> tags
    /// </summary>
    public class Crawler : ICrawler
    {
        private readonly IHttpHandler _httpHandler;
        private readonly IHtmlDocumentHandler _htmlDocumentHandler;

        public Crawler(IHttpHandler httpHandler, IHtmlDocumentHandler htmlDocumentHandler)
        {
            _httpHandler = httpHandler;
            _htmlDocumentHandler = htmlDocumentHandler;
        }

        /// <summary>
        /// Crawls a url to find <a> tags and add crawled link to linkQueues
        /// </summary>
        /// <param name="url"></param>
        /// <param name="linkQueues"></param>
        /// <returns></returns>
        public async Task Crwal(string url, List<LinkQueue> linkQueues)
        {
            try
            {
                var link = string.Empty;
                var rootUrl = string.Empty;

                var firstItem = linkQueues.FirstItem();

                if (firstItem == null)
                    throw new Exception("linkQueues is empty");

                rootUrl = firstItem.Link;

                var html = await _httpHandler.GetStringAsync(url);

                if (string.IsNullOrEmpty(html))
                    throw new Exception("url not valid");

                var nodes = _htmlDocumentHandler.GetDescendantsNode(html, "a");

                if (nodes==null)
                    throw new Exception("Not found <a> nodes");

                foreach (var item in nodes)
                {
                    var href = item.Attributes["href"];

                    if (href == null)
                        continue;

                    link = PrepareLink(href.Value, rootUrl);

                    if (string.IsNullOrEmpty(link))
                        continue;

                    if (!linkQueues.Any(l => l.Link == link))
                    {
                        linkQueues.Add(new LinkQueue()
                        {
                            Link = link,
                            IsCrawled = false,
                        });
                    }
                }
            }
            catch 
            {

            }
        }

        /// <summary>
        /// Prepare proper link to crawl
        /// </summary>
        /// <param name="link"></param>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        private string PrepareLink(string link,string baseUrl)
        {
            if (link.StartsWith(baseUrl))
            {
                return link;
            }

            if (link.StartsWith("/"))
            {
               return $"{baseUrl}{link}";
            }

            return null;
        }
    }
}
