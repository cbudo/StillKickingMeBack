using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StillKickingMeBack.Startup))]
namespace StillKickingMeBack
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
