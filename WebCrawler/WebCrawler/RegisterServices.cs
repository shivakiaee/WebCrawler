using Microsoft.Extensions.DependencyInjection;
using WebCrawler.Services;
using WebCrawler.Services.Interfaces;

namespace WebCrawler
{
    /// <summary>
    /// Is responsible for registering services to support DI
    /// </summary>
    public static class RegisterServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IHtmlDocumentHandler, HtmlDocumentHandler>();
            return services;
        }
    }
}
