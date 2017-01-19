using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoLogistic.Startup))]
namespace AutoLogistic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
