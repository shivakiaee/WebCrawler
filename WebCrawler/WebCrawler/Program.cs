using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebCrawler.Services.Interfaces;

namespace WebCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello To Web Crawler Console App");

            var _serviceCollection = new ServiceCollection();
            var _serviceProvider = _serviceCollection.AddServices()
                                 .BuildServiceProvider();

            var worker = _serviceProvider.GetRequiredService<IWorker>();
            var task = new Task(() =>
            {
                worker.StartUrl = "https://tretton37.com";
                worker.Do();
            });

            task.Start();
            while (!task.IsCompleted)
            {
                //in this approach, When crawling starts, we are not aware of total counts of links.
                //so, we can not show progress with the specific end point.
                //That is why very simple counter is used which displays only crawled links's count not necessary downloaded links's count
                Console.Clear();
                var crawledLinks = worker.LinksQueue.Count();
                Console.WriteLine($"{crawledLinks} was crawled");
                Thread.Sleep(500);
            }
            // task.Wait();//show message "finish"
        }
    }
}
