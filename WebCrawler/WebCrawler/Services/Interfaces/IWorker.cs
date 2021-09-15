using System.Collections.Generic;
using WebCrawler.Models;

namespace WebCrawler.Services.Interfaces
{
    public interface IWorker
    {
        public string StartUrl { get; set; }
        public List<LinkQueue> LinksQueue { get; }
        void Do();
    }
}
