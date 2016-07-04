using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JAPhotography.Controllers
{
    public class AccountController : Controller
    {
        // GET: MyAccount
        public ActionResult Login()
        {
            return View();
        }
    }
}