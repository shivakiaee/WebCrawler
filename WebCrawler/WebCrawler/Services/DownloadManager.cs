using System;
using System.IO;
using System.Threading.Tasks;
using WebCrawler.Services.Interfaces;

namespace WebCrawler.Services
{
    /// <summary>
    /// Is responsible for downloading a url 
    /// </summary>
    public class DownloadManager : IDownloadManager
    {
        private readonly IHttpHandler _httpHandler;

        public DownloadManager(IHttpHandler httpHandler)
        {
            _httpHandler = httpHandler;
        }

        /// <summary>
        /// Downloads a page with specified url if url is valid
        /// </summary>
        /// <param name="pageUrl"></param>
        /// <returns></returns>
        public async Task<bool> DownloadPage(string pageUrl)
        {
            try
            {
                var downloadingPath = string.Empty;
                var directory = string.Empty;
                var rootDirectory = "C:\\tretton37";

                if (!Directory.Exists(rootDirectory))
                    Directory.CreateDirectory(rootDirectory);

                var uri = new Uri(pageUrl);
                var rootUrl = $"https://{uri.Host}";

                if (!string.IsNullOrEmpty(pageUrl))
                {
                    if (pageUrl != rootUrl && $"{rootUrl}/" != pageUrl)
                    {
                        var subFolders = pageUrl.Replace($"{rootUrl}/", string.Empty).Split("/");

                        if (subFolders.Length != 0)
                        {
                            for (int i = 0; i < subFolders.Length - 1; i++)
                            {
                                directory += $"/{subFolders[i]}";

                                var directoryToCreate = Path.Combine(rootDirectory, subFolders[i]);

                                if (!Directory.Exists(directoryToCreate))
                                    Directory.CreateDirectory(directoryToCreate);
                            }
                        }

                        var fileName = subFolders[subFolders.Length - 1];

                        if (!string.IsNullOrEmpty(directory))
                            downloadingPath = @$"{rootDirectory}\{directory}\{fileName}.html";
                        else
                            downloadingPath = $@"{rootDirectory}\{fileName}.html";

                        await _httpHandler.Download(pageUrl, downloadingPath);

                        if (File.Exists(downloadingPath))
                            return true;

                        return false;
                    }

                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
