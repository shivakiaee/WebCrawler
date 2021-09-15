using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using WebCrawler.Services.Interfaces;

namespace WebCrawler.Services
{
    /// <summary>
    /// Is responsible for handling httpClient requests
    /// </summary>
    public class HttpHandler: IHttpHandler
    {
        /// <summary>
        /// Is a instance of HttpClient
        /// </summary>
        public HttpClient Client
        {
            get
            {
                return new HttpClient();
            }
        }

        /// <summary>
        /// Sends a request to specified url.If remote url is accessible fetch the content
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> GetStringAsync(string url)
        {
            try
            {
               return await Client.GetStringAsync(url);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Download a web page with specified url and save in path 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task Download(string url,string path)
        {
            using (var stream = await Client.GetStreamAsync(url))
            {
                using (var fileStream = new FileStream(path, FileMode.CreateNew))
                {
                    await stream.CopyToAsync(fileStream);
                }
            }
        }
    }
}
