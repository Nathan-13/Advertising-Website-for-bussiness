using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManoVerslas.Startup))]
namespace ManoVerslas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
