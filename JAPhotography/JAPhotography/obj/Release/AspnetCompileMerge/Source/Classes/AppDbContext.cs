using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAPhotography.Classes
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext() : base("DefaultConnection")
        {

        }
    }
}
