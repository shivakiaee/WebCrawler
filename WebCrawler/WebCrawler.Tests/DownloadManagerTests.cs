using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;
using WebCrawler.Services.Interfaces;

namespace WebCrawler.Tests
{
    public class DownloadManagerTests:BaseTest
    {
        [Test]
        public async Task testSuccessToDownloadPageIfGivenUrlIsValid()
        {
            var _downloadManager = (IDownloadManager)serviceProvider.GetRequiredService(typeof(IDownloadManager));
            var result = await _downloadManager.DownloadPage("https://tretton37.com/who-we-are");
            Assert.AreEqual(result, true);
        }

        [Test]
        public async Task testFailedToDownloadPageIfGivenUrlIsInvalid()
        {
            var _downloadManager = (IDownloadManager)serviceProvider.GetRequiredService(typeof(IDownloadManager));
            var result = await _downloadManager.DownloadPage("www.google.com");
            Assert.AreEqual(result, false);
        }
    }
}
