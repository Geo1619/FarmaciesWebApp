using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FarmaciesWebApp.Startup))]
namespace FarmaciesWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
