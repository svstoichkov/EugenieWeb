namespace EugenieWeb.Web.Controllers
{
    using System.Web.Mvc;

    using Data.Models;

    using Services.Data;
    using Services.Data.Contracts;

    public class DownloadsController : Controller
    {
        private readonly IDownloadsService downloadsService;

        public DownloadsController(IDownloadsService downloadsService)
        {
            this.downloadsService = downloadsService;
        }

        public ActionResult Admin()
        {
            var path = this.Server.MapPath("~/App_Data/Installs/eugenie-admin.exe");
            if (System.IO.File.Exists(path))
            {
                this.downloadsService.Add(this.Request.ServerVariables["REMOTE_ADDR"], DownloadTarget.Admin);
                return this.File(path, "application/x-ms-application", "eugenie-admin.exe");
            }

            return this.HttpNotFound();
        }

        public ActionResult Seller()
        {
            var path = this.Server.MapPath("~/App_Data/Installs/eugenie-seller.exe");
            if (System.IO.File.Exists(path))
            {
                this.downloadsService.Add(this.Request.ServerVariables["REMOTE_ADDR"], DownloadTarget.Seller);
                return this.File(path, "application/x-ms-application", "eugenie-seller.exe");
            }

            return this.HttpNotFound();
        }
    }
}
