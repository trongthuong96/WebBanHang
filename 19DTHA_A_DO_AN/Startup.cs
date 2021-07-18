using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_19DTHA_A_DO_AN.Startup))]
namespace _19DTHA_A_DO_AN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
