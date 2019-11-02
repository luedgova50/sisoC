using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(sisoC.Startup))]
namespace sisoC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
