using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites.Identity;

namespace TalabatReposatrey.Identitey
{
    public class AppDIdentityDBseed
    {
        public static async Task SeedUserAysnc(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                    DesplyName = "Mostafa Salem",
                    Email = "Mosyafa@gmail.com",
                    UserName = "Mostafa",
                    PhoneNumber = "01010010101010101"
                };
                await userManager.CreateAsync(user, "P@ssWo0rd");

            }
        }
    }
}
