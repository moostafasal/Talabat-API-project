using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites.Identity;

namespace Talabat.core.Services
{
    public interface ITookenServiice
    {
        Task<string> CreateToken(AppUser user,UserManager<AppUser> userManager);

    }
}
