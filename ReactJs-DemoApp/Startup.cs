using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReactJs_DemoApp.Startup))]
namespace ReactJs_DemoApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
