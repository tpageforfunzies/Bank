using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bank.Web.Startup))]
namespace Bank.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
