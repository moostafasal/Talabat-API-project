using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Talabat.core.Entites.Identity;
using Talabat.DTOS;

namespace Talabat.Extintions
{
    public static class userManegerEx
    {
        ////fun to lode all address of user
        ////public static async Task<List<AddressDto>> GetAddress(this UserManager<AppUser> input, ClaimsPrincipal user)
        ////{
        ////    var appUser = await input.GetUserAsync(user);
        ////    if (appUser == null) return null;
        ////    return appUser.Address.Select(a => new AddressDto
        ////    {
        ////        Id = a.Id,
        ////        FirstName = a.FirstName,
        ////        LastName = a.LastName,
        ////        Country = a.Country,
        ////        Street = a.Street
        ////    }).ToList();
        ////}
        /////
        ///
        //fun to get address by email eger loding

        public static async Task<AppUser> FindUserWithAddersByEmailAsync(this UserManager<AppUser> userManger, ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);
            var userwithAddress = await userManger.Users.Include(U => U.Address).SingleOrDefaultAsync(U => U.Email == email);
            return userwithAddress;

        }
        

        

    }
}
