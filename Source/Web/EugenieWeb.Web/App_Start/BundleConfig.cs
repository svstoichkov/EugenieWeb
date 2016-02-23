namespace EugenieWeb.Web
{
    using System.Web.Optimization;

    public static class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScripts(bundles);
            RegisterStyles(bundles);
        }

        private static void RegisterScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-scrollbar").Include("~/Scripts/jquery.scrollbar.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/landing/loader").Include("~/Scripts/Landing/loader.js"));
            bundles.Add(new ScriptBundle("~/bundles/landing/main").Include("~/Scripts/Landing/main.js"));
            bundles.Add(new ScriptBundle("~/bundles/landing/modernizr").Include("~/Scripts/Landing/modernizr.custom.js"));
            bundles.Add(new ScriptBundle("~/bundles/landing/vendor").Include("~/Scripts/Landing/vendor.js"));
            bundles.Add(new ScriptBundle("~/bundles/pace").Include("~/Scripts/pace.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/pages").Include("~/Scripts/pages.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/kendo").Include("~/Scripts/KendoUI/kendo.all.min.js", "~/Scripts/KendoUI/kendo.aspnetmvc.min.js"));
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/site.css",
                "~/Content/pages-icons.css",
                "~/Content/jquery.scrollbar.css",
                "~/Content/pages.css",
                "~/Content/pace-theme-flash.css"));
            bundles.Add(new StyleBundle("~/Content/KendoUI/css").Include(
                "~/Content/KendoUI/kendo.common-material.min.css",
                "~/Content/KendoUI/kendo.material.min.css"));
            bundles.Add(new StyleBundle("~/Content/Landing/css").Include("~/Content/Landing/material-design-iconic-font.min.css", "~/Content/Landing/bootstrap.css", "~/Content/Landing/main.css"));
        }
    }
}
