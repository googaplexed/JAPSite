using JAPhotography.Classes;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;

namespace JAPhotography
{
    public class Startup
    {
        public static Func<UserManager<AppUser>> UserManagerFactory { get; private set; }
        public void Configuration(IAppBuilder app)
        {
            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    // UseCookieAuthentication tesll the ASP.NET identity framework to use cookie based authentication.
            //    // AuthenticationType is a string value that indentifies the cookie. This is necessary since we may have several instances
            //    // of the Cookie middleware.
            //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            //    // LoginPath is the path to which the user agent (browser) should be redirected to when your application returns an unauthorized 
            //    // (401) response. This should correspond to your "login" controller.
            //    LoginPath = new PathString("/auth/login")
            //});

            //UserManagerFactory = () =>
            //{
            //    var usermanager = new UserManager<AppUser>(
            //        new UserStore<AppUser>(new AppDbContext()));
            //    usermanager.UserValidator = new UserValidator<AppUser>(usermanager)
            //    {
            //        AllowOnlyAlphanumericUserNames = false
            //    };

            //    return usermanager;
            //};
        }
    }
}
