﻿namespace EugenieWeb.Web.Areas.Management
{
    using System.Web.Mvc;

    public class ManagementAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Management";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Management_default",
                "Management/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
}
