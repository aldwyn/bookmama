using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookMama.Startup))]
namespace BookMama
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
