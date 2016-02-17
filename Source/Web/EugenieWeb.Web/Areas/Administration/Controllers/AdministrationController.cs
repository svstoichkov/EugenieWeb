namespace EugenieWeb.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using EugenieWeb.Common;
    using EugenieWeb.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}
