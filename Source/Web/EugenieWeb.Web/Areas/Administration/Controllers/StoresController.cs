namespace EugenieWeb.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Common;

    using Data.Models;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Services.Data.Contracts;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class StoresController : Controller
    {
        private readonly IStoresService storesService;

        public StoresController(IStoresService storesService)
        {
            this.storesService = storesService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Stores_Read([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.storesService.GetStores().ToDataSourceResult(request, store => new
            {
                Id = store.Id,
                Name = store.Name,
                Username = store.Username,
                Password = store.Password,
                Url = store.Url,
                UserId = store.UserId
            });

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Stores_Update([DataSourceRequest]DataSourceRequest request, Store store)
        {
            if (this.ModelState.IsValid)
            {
                this.storesService.Update(store.Id, store.Name, store.Username, store.Password, store.Url);
            }

            return this.Json(new[] { store }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Stores_Destroy([DataSourceRequest]DataSourceRequest request, Store store)
        {
            if (this.ModelState.IsValid)
            {
                this.storesService.Delete(store.Id);
            }

            return this.Json(new[] { store }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
