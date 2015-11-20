using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebLibero.Startup))]
namespace WebLibero
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
