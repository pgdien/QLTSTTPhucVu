using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof($rootnamespace$.Startup))]
namespace $rootnamespace$
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
