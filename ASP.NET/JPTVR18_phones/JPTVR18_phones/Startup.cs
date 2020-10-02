using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JPTVR18_phones.Startup))]
namespace JPTVR18_phones
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
