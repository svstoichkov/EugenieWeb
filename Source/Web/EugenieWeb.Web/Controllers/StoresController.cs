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
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            var stores = this.stores.All().Where(x => x.UserId == userId).To<StoreViewModel>().ToList();
            return View(stores);
        }
    }
}