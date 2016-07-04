using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace JAPhotography.Controllers
{
    public class LoginController : AppController
    {
        public ActionResult Index()
        {
            return View("~/Views/Accounts/Profile.cshtml");
        }
    }
}