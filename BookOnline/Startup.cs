using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookOnline.Startup))]
namespace BookOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
