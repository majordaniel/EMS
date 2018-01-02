using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EMS.Startup))]
namespace EMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
