using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gopher.Startup))]
namespace Gopher
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
