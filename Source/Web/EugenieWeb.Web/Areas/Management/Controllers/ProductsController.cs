namespace EugenieWeb.Web.Areas.Management.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Helpers;
    using Helpers.WebApiModels;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Microsoft.AspNet.Identity;

    using Services.Data;
    using Services.Data.Contracts;

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

            var client = this.GetClient(stores.First());
            if (client != null)
            {
                var products = this.apiClient.GetProducts(client);
                this.Session["products"] = products;
            }

            return View();
        }

        public ActionResult Products_Read([DataSourceRequest]DataSourceRequest request)
        {
            var result = ((List<Product>)this.Session["products"]).ToDataSourceResult(request, product => new
            {
                Id = product.Id,
                Name = product.Name,
                BuyingPrice = product.BuyingPrice,
                SellingPrice = product.SellingPrice,
                Measure = product.Measure,
                Quantity = product.Quantity
            });

            return this.Json(result);

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Products_Create([DataSourceRequest]DataSourceRequest request, Product product)
        {
            if (this.ModelState.IsValid)
            {
                var stores = this.storesService.GetStoresByUserId(this.User.Identity.GetUserId());

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
            }

            return this.Json(new[] { product }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Products_Update([DataSourceRequest]DataSourceRequest request, Product product)
        {
            var stores = this.storesService.GetStoresByUserId(this.User.Identity.GetUserId());

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

            var client = this.GetClient(stores.First());
            if (client != null)
            {
                this.apiClient.DeleteProduct(client, product.Name);
            }

            return this.Json(new[] { product }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
