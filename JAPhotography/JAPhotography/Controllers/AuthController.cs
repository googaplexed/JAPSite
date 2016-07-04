using JAPhotography.Classes;
using JAPhotography.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JAPhotography.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        //[AllowAnonymous] // This is for Un-Authorized User
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //[Authorize]
        //public ActionResult MyProfile()
        //{
        //    return View();
        //}

        private readonly UserManager<AppUser> userManager;

        public AuthController() : this (Startup.UserManagerFactory.Invoke())
        {

        }

        public AuthController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && userManager != null)
            {
                userManager.Dispose();
            }

            base.Dispose(disposing);
        }

        [HttpPost]
        public async Task<ActionResult> LogIn(AuthenticationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await userManager.FindAsync(model.Email, model.Password);

            if (user != null)
            {
                var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

                GetAuthenticationManager().SignIn(identity);

                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }

            ModelState.AddModelError("", "Invalid email or password");

            return View();
        }

        public ActionResult LogIn()
        {
            return View("~/Views/Accounts/Login.cshtml");
        }

        [HttpGet]
        public ActionResult LogIn(string returnUrl)
        {
            var model = new AuthenticationModel
            {
                ReturnUrl = returnUrl
            };

            return View("~/Views/Accounts/Login.cshtml", model);
        }

        //[HttpPost]
        //public ActionResult LogIn(AuthenticationModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }

        //    // Don't do this in production!
        //    if (model.Email == "admin@admin.com" && model.Password == "password")
        //    {
        //        var identity = new ClaimsIdentity(new[]
        //        {
        //            new Claim(ClaimTypes.Name, "Ben"),
        //            new Claim(ClaimTypes.Email, "a@b.com"),
        //            new Claim(ClaimTypes.Country, "England")
        //        },
        //        "ApplicationCookie");

        //        var ctx = Request.GetOwinContext();
        //        var authManager = ctx.Authentication;

        //        authManager.SignIn(identity);

        //        return Redirect(GetRedirectUrl(model.ReturnUrl));
        //    }

        //    ModelState.AddModelError("", "Invalid email or password");
        //    return View();
        //}

        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("index", "login");
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "login");
            }

            return returnUrl;
        }

        private IAuthenticationManager GetAuthenticationManager()
        {
            var ctx = Request.GetOwinContext();
            return ctx.Authentication;
        }
    }
}