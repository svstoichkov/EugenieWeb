namespace EugenieWeb.Web.Controllers
{
    using System.Web.Mvc;

    public class ErrorsController : Controller
    {
        public ViewResult Index()
        {
            return this.View("404");
        }

        public ViewResult InternalServerError()
        {
            return this.View("500");
        }
    }
}