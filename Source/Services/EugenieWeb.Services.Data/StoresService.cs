namespace EugenieWeb.Services.Data
{
    using System.Linq;

    using Eugenie.Data;

    using EugenieWeb.Data.Models;

    public class StoresService : IStoresService
    {
        private readonly IRepository<Store> storesRepository;

        public StoresService(IRepository<Store> storesRepository)
        {
            this.storesRepository = storesRepository;
        }

        public IQueryable<Store> GetStoresByUserId(string userId)
        {
            return this.storesRepository.All().Where(x => x.UserId == userId);
        }
    }
}
