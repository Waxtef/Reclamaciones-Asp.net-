using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Reclamaciones.Startup))]
namespace Reclamaciones
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
