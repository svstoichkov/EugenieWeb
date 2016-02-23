namespace EugenieWeb.Web.Areas.Administration.Controllers
{
    using System.IO;
    using System.Web.Mvc;

    using Data.Models;

    using Kendo.Mvc.Extensions;

    using Services.Data;
    using Services.Data.Contracts;

    public class BackupsController : Controller
    {
        private readonly IBackupsService backupsService;

        public BackupsController(IBackupsService backupsService)
        {
            this.backupsService = backupsService;
        }

        public ActionResult Index()
        {
            return this.View(this.backupsService.GetAll());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Backups_Destroy(Backup backup)
        {
            System.IO.File.Delete(Path.Combine(this.Server.MapPath("~/App_Data/Backups"), this.backupsService.GetFileName(backup.Id)));
            this.backupsService.Delete(backup.Id);

            var routeValues = this.GridRouteValues();

            return this.RedirectToAction("Index", routeValues);
        }
    }
}
