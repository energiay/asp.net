using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNet.Startup))]
namespace AspNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
