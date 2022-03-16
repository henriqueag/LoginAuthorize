﻿using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Web.Helpers;

[assembly: OwinStartup(typeof(LoginAuthorize.Startup))]

namespace LoginAuthorize
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Autenticacao/Login")
            });
            AntiForgeryConfig.UniqueClaimTypeIdentifier = "Login";
        }
    }
}
