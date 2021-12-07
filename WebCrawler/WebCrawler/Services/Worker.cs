using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCrawler.Models;
using WebCrawler.Services.Interfaces;

namespace WebCrawler.Services
{
    /// <summary>
    /// Is responsible for reading from a queue and creates and runs some tasks (limited)
    /// </summary>
    public class Worker : IWorker
    {
        public List<LinkQueue> _linkQueues = new List<LinkQueue>();
        public List<LinkQueue> LinksQueue => _linkQueues;
        private List<Task> TaskList;
        private readonly IDownloader _downloader;

        public string StartUrl { get; set; }

        public Worker(IDownloader downloader)
        {
            _downloader = downloader;
        }

        /// <summary>
        /// Starts reading links from queue and creates and runs tasks
        /// </summary>
        public void Do()
        {
            _linkQueues.Add(new LinkQueue()
            {
                Link = StartUrl,
                IsCrawled = false,
            });

            while (_linkQueues.Where(l => !l.IsCrawled).Count()>0)
            {
                //It is better to get number of parallel tasks(5 hardcoded) from input
                var linksToCrawl = _linkQueues.Where(l => !l.IsCrawled).Take(5).ToList();
                TaskList = new List<Task>();
                for (int i = 0; i < linksToCrawl.Count; i++)
                {
                    TaskList.Add(_downloader.Download(linksToCrawl[i].Link, _linkQueues));
                }
                Task.WaitAll(TaskList.ToArray());
            }

        }
    }
}
