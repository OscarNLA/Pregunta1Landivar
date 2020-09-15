using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcLandivarPr1.Startup))]
namespace MvcLandivarPr1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
