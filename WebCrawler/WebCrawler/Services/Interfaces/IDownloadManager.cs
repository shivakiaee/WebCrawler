using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler.Services.Interfaces
{
    public interface IDownloadManager
    {
        Task<bool> DownloadPage(string url);
    }
}
