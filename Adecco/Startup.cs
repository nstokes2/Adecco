using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Adecco.Startup))]
namespace Adecco
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
