using HtmlAgilityPack;
using System.Collections.Generic;
using WebCrawler.Services.Interfaces;

namespace WebCrawler.Services
{
    /// <summary>
    /// Is responsible for working with html documents
    /// </summary>
    public class HtmlDocumentHandler: IHtmlDocumentHandler
    {

        /// <summary>
        /// Is responsible for loading a html doc and go through it to find specified tag
        /// </summary>
        /// <param name="html"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public IEnumerable<HtmlNode> GetDescendantsNode(string html,string tag)
        {
            try
            {
                var HtmllDoc = new HtmlDocument();
                HtmllDoc.LoadHtml(html);
                var node = HtmllDoc.DocumentNode;
                return node.Descendants(tag);
            }
            catch
            {
                return null;
            }
   
        }
    }
}
