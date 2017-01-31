using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GeoMusicServer.Startup))]
namespace GeoMusicServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
