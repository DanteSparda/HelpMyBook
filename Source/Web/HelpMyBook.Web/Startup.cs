using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(HelpMyBook.Web.Startup))]

namespace HelpMyBook.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
