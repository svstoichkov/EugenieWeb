namespace EugenieWeb.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Data.Models;

    using Kendo.Mvc.Extensions;

    using Services.Data;
    using Services.Data.Contracts;

    public class MessagesController : Controller
    {
        private readonly IMessageService messageService;

        public MessagesController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        public ActionResult Index()
        {
            return this.View(this.messageService.Get());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Messages_Destroy(Message message)
        {
            this.messageService.Delete(message.Id);

            var routeValues = this.GridRouteValues();

            return this.RedirectToAction("Index", routeValues);
        }
    }
}
