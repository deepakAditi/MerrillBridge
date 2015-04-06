using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MerrillBridgeCloud.Startup))]
namespace MerrillBridgeCloud
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
