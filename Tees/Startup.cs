using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tees.Startup))]
namespace Tees
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
