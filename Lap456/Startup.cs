using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lap456.Startup))]
namespace Lap456
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
