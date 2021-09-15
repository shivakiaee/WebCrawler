using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Linq;
using WebCrawler.Services.Interfaces;

namespace WebCrawler.Tests
{
    public class HtmlDocumentHandlerTests:BaseTest
    {
        [Test]
        public void testSuccessToGetDescendantsNodeIfGivenHtmlIsValid()
        {
            var _htmlDocumentHandler = (IHtmlDocumentHandler)serviceProvider.GetRequiredService(typeof(IHtmlDocumentHandler));
            var html = "<!DOCTYPE html><a href=\"https://www.w3schools.com\">Visit W3Schools.com!</a></html>";
            var nodes = _htmlDocumentHandler.GetDescendantsNode(html, "a").ToList();

            Assert.AreEqual(nodes.Count, 1);
        }

        [Test]
        public void testFailedToGetDescendantsNodeIfGivenHtmlIsNull()
        {
            var _htmlDocumentHandler = (IHtmlDocumentHandler)serviceProvider.GetRequiredService(typeof(IHtmlDocumentHandler));
            var nodes = _htmlDocumentHandler.GetDescendantsNode(null, "a");

            Assert.AreEqual(nodes, null);
        }
    }
}
