using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JAPhotography.Classes
{
    public class AppUserPrincipal : ClaimsPrincipal
    {
        public AppUserPrincipal(ClaimsPrincipal principal) : base(principal)
        {

        }

        public string Name
        {
            get
            {
                return this.FindFirst(ClaimTypes.Name).Value;
            }
        }

        public string Country
        {
            get
            {
                return this.FindFirst(ClaimTypes.Country).Value;
            }
        }
    }
}
