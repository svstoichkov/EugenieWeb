namespace EugenieWeb.Web.Areas.Management.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Helpers;
    using Helpers.WebApiModels;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Microsoft.AspNet.Identity;

    using Services.Data;

    [Authorize]
    public class ProductsController : BaseManagementController
    {
        private readonly IStoresService storesService;
        private readonly IWebApiClient apiClient;

        public ProductsController(IStoresService storesService, IWebApiClient apiClient)
        {
            this.storesService = storesService;
            this.apiClient = apiClient;
        }

        public ActionResult Index()
        {
            var stores = this.storesService.GetStoresByUserId(this.User.Identity.GetUserId());
            if (!stores.Any())
            {
                return this.RedirectToAction("AddStore", "Stores");
            }
            return View();
        }

        public ActionResult Products_Read([DataSourceRequest]DataSourceRequest request)
        {
            var stores = this.storesService.GetStoresByUserId(this.User.Identity.GetUserId());
            if (!stores.Any())
            {
                return this.RedirectToAction("AddStore", "Stores");
            }

            var client = this.GetClient(stores.First());
            if (client != null)
            {
                var result = this.apiClient.GetProducts(client).AsQueryable().ToDataSourceResult(request, product => new {
                    Id = product.Id,
                    Name = product.Name,
                    BuyingPrice = product.BuyingPrice,
                    SellingPrice = product.SellingPrice,
                    Measure = product.Measure,
                    Quantity = product.Quantity
                });
                return Json(result);
            }
            else
            {
                return this.RedirectToAction("AddStore", "Stores");
            }

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Products_Create([DataSourceRequest]DataSourceRequest request, Product product)
        {
            var stores = this.storesService.GetStoresByUserId(this.User.Identity.GetUserId());
            if (!stores.Any())
            {
                return this.RedirectToAction("AddStore", "Stores");
            }

            var client = this.GetClient(stores.First());
            if (client != null)
            {
                var model = new AddProductModel
                            {
                                Name = product.Name,
                                BuyingPrice = product.BuyingPrice,
                                SellingPrice = product.SellingPrice,
                                Measure = product.Measure,
                                QuantityToAdd = product.Quantity
                            };
                this.apiClient.AddOrUpdate(client, model);
            }

            return Json(new[] { product }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Products_Update([DataSourceRequest]DataSourceRequest request, Product product)
        {
            var stores = this.storesService.GetStoresByUserId(this.User.Identity.GetUserId());
            if (!stores.Any())
            {
                return this.RedirectToAction("AddStore", "Stores");
            }

            var client = this.GetClient(stores.First());
            if (client != null)
            {
                var model = new AddProductModel
                {
                    OldName = product.Name,
                    Name = product.Name,
                    BuyingPrice = product.BuyingPrice,
                    SellingPrice = product.SellingPrice,
                    Measure = product.Measure,
                    QuantityToAdd = product.Quantity
                };
                this.apiClient.AddOrUpdate(client, model);
            }

            return Json(new[] { product }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Products_Destroy([DataSourceRequest]DataSourceRequest request, Product product)
        {
            var stores = this.storesService.GetStoresByUserId(this.User.Identity.GetUserId());
            if (!stores.Any())
            {
                return this.RedirectToAction("AddStore", "Stores");
            }

            var client = this.GetClient(stores.First());
            if (client != null)
            {
                this.apiClient.DeleteProduct(client, product.Name);
            }

            return Json(new[] { product }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
