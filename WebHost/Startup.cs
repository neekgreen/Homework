[assembly: Microsoft.Owin.OwinStartupAttribute(typeof(WebHost.Startup))]

namespace WebHost
{
    using System;
    using System.Linq;
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}