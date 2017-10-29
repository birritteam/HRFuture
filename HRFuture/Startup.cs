using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRFuture.Startup))]
namespace HRFuture
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
