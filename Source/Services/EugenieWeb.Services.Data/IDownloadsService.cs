namespace EugenieWeb.Services.Data
{
    using System.Linq;

    using EugenieWeb.Data.Models;

    public interface IDownloadsService
    {
        void Add(string ip, DownloadTarget target);

        IQueryable<Download> Get();
    }
}
