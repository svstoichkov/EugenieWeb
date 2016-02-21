namespace EugenieWeb.Services.Data
{
    using System.Linq;
    using EugenieWeb.Data.Models;

    public interface IStoresService
    {
        IQueryable<Store> GetStoresByUserId(string userId);
    }
}
