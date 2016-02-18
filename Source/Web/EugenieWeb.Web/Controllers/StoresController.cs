namespace EugenieWeb.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Data.Models;

    using Eugenie.Data;

    using Infrastructure.Mapping;

    using Microsoft.AspNet.Identity;

    using ViewModels.Stores;

    public class StoresController : Controller
    {
        private readonly IRepository<Store> stores;

        public StoresController(IRepository<Store> stores)
        {
            this.stores = stores;
        }

        [HttpGet]
        public ActionResult ListStores()
        {
            var userId = this.User.Identity.GetUserId();
            var stores = this.stores.All().Where(x => x.UserId == userId).To<StoreViewModel>().ToList();
            return View(stores);
        }

        [HttpGet]
        public ActionResult AddStore()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStore(AddStoreViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.User.Identity.GetUserId();
            var store = new Store();
            store.UserId = userId;
            store.Name = model.Name;
            store.Username = model.Username;
            store.Password = model.Password;
            store.Url = model.Url;
            this.stores.Add(store);
            this.stores.SaveChanges();

            return this.View();
        }
    }
}