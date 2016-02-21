namespace EugenieWeb.Web.Areas.Management.Controllers
{
    using System.Web.Mvc;

    using Web.Controllers;

    [Authorize]
    public class ReportsController : BaseController
    {
        // GET: Reports
        public ActionResult Index()
        {
            return this.View();
        }
    }
}