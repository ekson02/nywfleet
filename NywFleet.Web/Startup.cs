﻿using Microsoft.Owin;
using NywFleet.Web;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace NywFleet.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
