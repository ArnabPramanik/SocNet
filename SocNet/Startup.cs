using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SocNet.Startup))]
namespace SocNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
