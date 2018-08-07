using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpecWheels.Startup))]
namespace SpecWheels
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
