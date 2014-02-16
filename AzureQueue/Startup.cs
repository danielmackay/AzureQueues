using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AzureQueue.Startup))]
namespace AzureQueue
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
