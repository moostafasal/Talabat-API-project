using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.core.Entites.Identity
{
    public class AppUser:IdentityUser
    {
        public string DesplyName { get; set; }
        public Address Address { get; set; }//navigtional Proparty [ONE]
    }
}
