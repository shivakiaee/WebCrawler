using HtmlAgilityPack;
using System.Collections.Generic;

namespace WebCrawler.Services.Interfaces
{
    public interface IHtmlDocumentHandler
    {
        IEnumerable<HtmlNode> GetDescendantsNode(string html, string tag);
    }
}
