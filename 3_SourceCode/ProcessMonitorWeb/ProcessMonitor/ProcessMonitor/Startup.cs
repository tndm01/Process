using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProcessMonitor.Startup))]
namespace ProcessMonitor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          
        }
    }
}
