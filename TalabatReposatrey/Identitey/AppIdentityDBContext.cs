using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites.Identity;

namespace TalabatReposatrey.Identitey
{
    public class AppIdenentiyDB :IdentityDbContext<AppUser>
    {
        public AppIdenentiyDB(DbContextOptions<AppIdenentiyDB> options):base(options)
        {

        }
    }
}
