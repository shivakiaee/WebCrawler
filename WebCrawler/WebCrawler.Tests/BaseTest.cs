using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace WebCrawler.Tests
{
    public class BaseTest
    {
        public ServiceProvider serviceProvider { get; set; }

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddServices();
            serviceProvider = services.BuildServiceProvider();
        }
    }
}
