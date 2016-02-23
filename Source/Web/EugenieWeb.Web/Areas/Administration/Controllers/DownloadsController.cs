﻿namespace EugenieWeb.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Services.Data;
    using Services.Data.Contracts;

    public class DownloadsController : Controller
    {
        private readonly IDownloadsService downloadsService;

        public DownloadsController(IDownloadsService downloadsService)
        {
            this.downloadsService = downloadsService;
        }

        public ActionResult Index()
        {
            return this.View(this.downloadsService.Get().OrderByDescending(x => x.Time));
        }
    }
}
