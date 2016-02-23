namespace EugenieWeb.Services.Data
{
    using System.Linq;

    using Contracts;

    using EugenieWeb.Data;
    using EugenieWeb.Data.Models;

    public class DownloadsService : IDownloadsService
    {
        private readonly IRepository<Download> downloadsRepository;

        public DownloadsService(IRepository<Download> downloadsRepository)
        {
            this.downloadsRepository = downloadsRepository;
        }

        public void Add(string ip, DownloadTarget target)
        {
            var download = new Download();
            download.Ip = ip;
            download.Target = target;
            this.downloadsRepository.Add(download);
            this.downloadsRepository.SaveChanges();
        }

        public IQueryable<Download> Get()
        {
            return this.downloadsRepository.All();
        }
    }
}
