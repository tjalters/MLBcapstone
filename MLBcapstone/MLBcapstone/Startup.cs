using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MLBcapstone.Startup))]
namespace MLBcapstone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
