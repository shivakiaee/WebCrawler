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
            Console.WriteLine("Hello to web crawler console app");

            Thread.Sleep(1000);

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
                Console.WriteLine(@$"You can find downloaded files in C:\\tretton37 path");
                var crawledLinks = worker.LinksQueue.Count();
                Console.WriteLine($"{crawledLinks} was crawled");
                Thread.Sleep(500);
            }

           Console.WriteLine($"{worker.StartUrl} is already crawled.");
           Console.WriteLine("Hope you enjoyed the crawler app");

        }
    }
}
