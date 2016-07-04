using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JAPhotography.Classes
{
    public abstract class AppViewPage<TModel> : WebViewPage<TModel>
    {
        protected AppUserPrincipal CurrentUser
        {
            get
            {
                return new AppUserPrincipal(this.User as ClaimsPrincipal);
            }
        }
    }

    public abstract class AppViewPage : AppViewPage<dynamic>
    {

    }
}
