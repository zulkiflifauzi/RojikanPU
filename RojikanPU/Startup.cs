using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RojikanPU.Startup))]
namespace RojikanPU
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
