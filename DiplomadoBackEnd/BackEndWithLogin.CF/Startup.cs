using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BackEndWithLogin.CF.Startup))]
namespace BackEndWithLogin.CF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
