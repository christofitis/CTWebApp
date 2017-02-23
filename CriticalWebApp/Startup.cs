using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CriticalWebApp.Startup))]
namespace CriticalWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
