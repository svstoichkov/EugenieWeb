namespace EugenieWeb.Services.Data.Contracts
{
    using System.Linq;

    using EugenieWeb.Data.Models;

    public interface IStoresService
    {
        IQueryable<Store> GetStores();

        IQueryable<Store> GetStoresByUserId(string userId);

        void Update(int id, string name, string username, string password, string url);

        void Delete(int id);
    }
}
