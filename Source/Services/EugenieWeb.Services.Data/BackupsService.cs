namespace EugenieWeb.Services.Data
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Eugenie.Data;

    using EugenieWeb.Data.Models;

    public class BackupsService : IBackupsService
    {
        private readonly IRepository<Backup> backupsRepository;

        public BackupsService(IRepository<Backup> backupsRepository)
        {
            this.backupsRepository = backupsRepository;
        }

        public void Add(string fileName, int storeId)
        {
            var backup = new Backup();
            backup.StoreId = storeId;
            backup.FileName = fileName;

            this.backupsRepository.Add(backup);
            this.backupsRepository.SaveChanges();
        }

        public IQueryable<Backup> GetBackupsByStoreIds(IEnumerable<int> storeIds)
        {
            return this.backupsRepository.All().Where(x => storeIds.Any(y => x.StoreId == y));
        }

        public string GetFileName(int backupId)
        {
            return this.backupsRepository.All().First(x => x.Id == backupId).FileName;
        }
    }
}
