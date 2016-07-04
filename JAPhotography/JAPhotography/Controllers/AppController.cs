using JAPhotography.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JAPhotography.Controllers
{
    public abstract class AppController : Controller
    {
        public AppUserPrincipal CurrentUser
        {
            get
            {
                return new AppUserPrincipal(this.User as ClaimsPrincipal);
            }
        }
    }
}
