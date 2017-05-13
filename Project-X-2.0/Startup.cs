using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_X_2._0.Startup))]
namespace Project_X_2._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
