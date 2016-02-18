using System.Web.Mvc;

namespace EugenieWeb.Web.Areas.Management
{
    public class ManagementAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Management";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Management_default",
                "Management/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}