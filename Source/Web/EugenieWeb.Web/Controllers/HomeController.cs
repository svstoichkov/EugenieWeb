namespace EugenieWeb.Web.Controllers
{
    using System.Web.Mvc;

    using Services.Data;
    using Services.Data.Contracts;

    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IMessageService messageService;

        public HomeController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Message(AddMessageViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.messageService.Add(model.Email, model.Content);
                return this.RedirectToAction("Index");
            }

            return this.View("Index", model);
        }
    }
}
