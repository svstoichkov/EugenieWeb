namespace EugenieWeb.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using EugenieWeb.Data.Models;

    public interface IBackupsService
    {
        void Add(string fileName, int storeId);

        IQueryable<Backup> GetBackupsByStoreIds(IEnumerable<int> storeIds);

        string GetFileName(int backupId);
    }
}
