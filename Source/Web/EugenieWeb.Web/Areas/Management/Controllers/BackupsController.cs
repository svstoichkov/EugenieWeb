﻿namespace EugenieWeb.Web.Areas.Management.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using Services.Data;
    using Services.Data.Contracts;

    using ViewModels.Backups;

    [Authorize]
    public class BackupsController : BaseManagementController
    {
        private readonly IStoresService storesService;
        private readonly IBackupsService backupsService;

        public BackupsController(IStoresService storesService, IBackupsService backupsService)
        {
            this.storesService = storesService;
            this.backupsService = backupsService;
        }

        public ActionResult Index()
        {
            var stores = this.storesService.GetStoresByUserId(this.User.Identity.GetUserId());
            if (!stores.Any())
            {
                return this.RedirectToAction("AddStore", "Stores");
            }

            var backups = this.backupsService.GetBackupsByStoreIds(stores.Select(x => x.Id));
            var viewModels = backups.Select(x => new BackupViewModel { CreatedOn = x.CreatedOn, Id = x.Id });

            return this.View(viewModels);
        }

        [HttpGet]
        public ActionResult Upload()
        {
            var stores = this.storesService.GetStoresByUserId(this.User.Identity.GetUserId());
            if (!stores.Any())
            {
                return this.RedirectToAction("AddStore", "Stores");
            }

            var model = new BackupUploadViewModel();
            model.Stores = stores;

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase file, int selectedStoreId)
        {
            var stores = this.storesService.GetStoresByUserId(this.User.Identity.GetUserId());
            if (stores.Any(x => x.Id == selectedStoreId))
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    Directory.CreateDirectory(this.Server.MapPath("~/App_Data/Backups"));
                    var path = Path.Combine(this.Server.MapPath("~/App_Data/Backups"), fileName);
                    file.SaveAs(path);
                    this.backupsService.Add(fileName, selectedStoreId, (double)file.ContentLength / (1024 * 1024));
                }
            }

            return this.RedirectToAction("Upload");
        }

        [HttpGet]
        public ActionResult Download(int id)
        {
            var fileName = this.backupsService.GetFileName(id);
            var path = this.Server.MapPath($"~/App_Data/Backups/{fileName}");
            if (System.IO.File.Exists(path))
            {
                return this.File(path, "application/x-rar-compressed", fileName);
            }

            return this.HttpNotFound();
        }
    }
}