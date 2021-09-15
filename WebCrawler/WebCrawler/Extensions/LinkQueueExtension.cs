using System.Collections.Generic;
using System.Linq;
using WebCrawler.Models;

namespace WebCrawler.Extensions
{
    public static class LinkQueueExtension
    {
        public static LinkQueue Find(this List<LinkQueue> linkQueues,string link)
        {
            if (string.IsNullOrEmpty(link))
                return null;

            if (linkQueues.Count == 0)
                return null;

            return linkQueues.Where(lq => lq.Link == link).FirstOrDefault();
        }

        public static LinkQueue FirstItem(this List<LinkQueue> linkQueues)
        {
            if (linkQueues.Count == 0)
                return null;

            return linkQueues.FirstOrDefault();
        }
    }
}
