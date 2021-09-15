using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;
using WebCrawler.Services.Interfaces;

namespace WebCrawler.Tests
{
    public class HttpHandlerTests:BaseTest
    {
        [Test]
        public async Task testSuccessToGetStringAsyncIfGivenUrlIsValid()
        {
            string url = "https://tretton37.com";
            var _httpHandler = (IHttpHandler)serviceProvider.GetRequiredService(typeof(IHttpHandler));
            //better approch is using of Mock http server
            var result = await _httpHandler.GetStringAsync(url);

            Assert.AreEqual(result != null, true);
        }

        [Test]
        public async Task testFailedToGetStringAsyncIfGivenUrlIsInvalid()
        {
            string url = "https://tretton37";
            var _httpHandler = (IHttpHandler)serviceProvider.GetRequiredService(typeof(IHttpHandler));
            //better approch is using of Mock http server
            var result = await _httpHandler.GetStringAsync(url);

            Assert.AreEqual(result == null, true);
        }
    }
}
