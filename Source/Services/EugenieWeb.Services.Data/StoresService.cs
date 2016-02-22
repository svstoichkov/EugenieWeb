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

        public IQueryable<Store> GetStores()
        {
            return this.storesRepository.All();
        }

        public IQueryable<Store> GetStoresByUserId(string userId)
        {
            return this.storesRepository.All().Where(x => x.UserId == userId);
        }

        public void Update(int id, string name, string username, string password, string url)
        {
            var store = this.storesRepository.GetById(id);

            store.Name = name;
            store.Username = username;
            store.Password = password;

            this.storesRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            this.storesRepository.Delete(id);
            this.storesRepository.SaveChanges();
        }
    }
}
