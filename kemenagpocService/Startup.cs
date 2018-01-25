using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(kemenagpocService.Startup))]

namespace kemenagpocService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
          
        }
    }
}