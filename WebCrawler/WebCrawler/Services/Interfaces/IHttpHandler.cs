using System.Threading.Tasks;

namespace WebCrawler.Services.Interfaces
{
    public interface IHttpHandler
    {
        Task<string> GetStringAsync(string url);
        Task Download(string url, string path);
    }
}
