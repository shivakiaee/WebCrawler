using System.Collections.Generic;
using System.Threading.Tasks;
using WebCrawler.Models;

namespace WebCrawler.Services.Interfaces
{
    public interface IDownloader
    {
        Task Download(string url, List<LinkQueue> linkQueues);
    }
}
