namespace EugenieWeb.Web.Areas.Management.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Helpers;

    using Microsoft.AspNet.Identity;

    using Services.Data;

    [Authorize]
    public class ReportDetailsController : BaseManagementController
    {
        private readonly IStoresService storesService;
        private readonly IWebApiClient apiClient;

        public ReportDetailsController(IStoresService storesService, IWebApiClient apiClient)
        {
            this.storesService = storesService;
            this.apiClient = apiClient;
        }

        public ActionResult Index(DateTime id)
        {
            var stores = this.storesService.GetStoresByUserId(this.User.Identity.GetUserId());
            if (!stores.Any())
            {
                return this.RedirectToAction("AddStore", "Stores");
            }

            var client = this.GetClient(stores.First());
            if (client != null)
            {
                var reportDetails = this.apiClient.GetReportDetails(client, id);
                return this.View(reportDetails);
            }

            return this.View();
        }
    }
}