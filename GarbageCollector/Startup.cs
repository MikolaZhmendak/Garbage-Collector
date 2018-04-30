using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GarbageCollector.Startup))]
namespace GarbageCollector
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
