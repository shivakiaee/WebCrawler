using System.Collections.Generic;
using System.Threading.Tasks;
using WebCrawler.Models;

namespace WebCrawler.Services.Interfaces
{
    public interface ICrawler
    {
        Task Crwal(string url, List<LinkQueue> linkQueues);
    }
}
