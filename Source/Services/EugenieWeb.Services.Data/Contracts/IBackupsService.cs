namespace EugenieWeb.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Linq;

    using EugenieWeb.Data.Models;

    public interface IBackupsService
    {
        void Add(string fileName, int storeId, double fileSize);

        IQueryable<Backup> GetBackupsByStoreIds(IEnumerable<int> storeIds);

        string GetFileName(int backupId);

        IQueryable<Backup> GetAll();

        void Delete(int backupId);
    }
}
