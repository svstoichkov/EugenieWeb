using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(EugenieWeb.Web.Startup))]

namespace EugenieWeb.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
