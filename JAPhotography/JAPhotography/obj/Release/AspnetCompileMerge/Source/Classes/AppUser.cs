using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAPhotography.Classes
{
    public class AppUser : IdentityUser
    {
        public string Country { get; set; }
        public int Age { get; set; }
    }
}
