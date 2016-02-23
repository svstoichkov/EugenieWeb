namespace EugenieWeb.Web.Areas.Management.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Helpers;

    using Microsoft.AspNet.Identity;

    using Services.Data;
    using Services.Data.Contracts;

    [Authorize]
    public class ReportsController : BaseManagementController
    {
        private readonly IStoresService storesService;
        private readonly IWebApiClient apiClient;

        public ReportsController(IStoresService storesService, IWebApiClient apiClient)
        {
            this.storesService = storesService;
            this.apiClient = apiClient;
        }

        [HttpGet]
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
                var reports = this.apiClient.GetReports(client);
                return this.View(reports);
            }

            return this.View();
        }
    }
}