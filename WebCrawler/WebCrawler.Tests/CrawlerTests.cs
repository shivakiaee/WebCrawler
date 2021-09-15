using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebCrawler.Models;
using WebCrawler.Services.Interfaces;

namespace WebCrawler.Tests
{
    public class CrawlerTests:BaseTest
    {
        [Test]
        public async Task testSuccessToCrawlIfUrlIsValid()
        {
            var _crawler = (ICrawler)serviceProvider.GetRequiredService(typeof(ICrawler));

            var linkQueues = new List<LinkQueue>();
            linkQueues.Add(new LinkQueue()
            {
                Link = "https://tretton37.com",
                IsCrawled = true,
            });

            //better approch is using of Mock http server
            await _crawler.Crwal("https://tretton37.com/who-we-are", linkQueues);

            Assert.AreEqual(linkQueues[1].Link, "https://tretton37.com/who-we-are");
        }

        [Test]
        public async Task testFailedToCrawlIfUrlIsInvalid()
        {
            var _crawler = (ICrawler)serviceProvider.GetRequiredService(typeof(ICrawler));

            var linkQueues = new List<LinkQueue>();
            linkQueues.Add(new LinkQueue()
            {
                Link = "https://tretton37.com",
                IsCrawled = true,
            });

            //better approch is using of Mock http server
            string invalidUrl = "https://tretton37";
            await _crawler.Crwal(invalidUrl, linkQueues);

            Assert.AreEqual(linkQueues.Count, 1);
        }
    }
}
