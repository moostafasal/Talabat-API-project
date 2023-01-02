using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites.Identity;
using Talabat.core.Services;

namespace Talabat.Serves
{
    public class TokenServes : ITookenServiice
    {
        public IConfiguration Configuration { get; }
        public TokenServes(IConfiguration configuration)
        {

            Configuration = configuration;
        }


        public async Task<string> CreateToken(AppUser user, UserManager<AppUser> userManager)
        {
            //privet claim (UsrtDefind)
            var aouthClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName,user.DesplyName)

            };
            var userRoles = await userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
                aouthClaim.Add(new Claim(ClaimTypes.Role, role));

            //secret key
            var aouthKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes( Configuration["JWT:key"]));


            var token = new JwtSecurityToken(
                issuer: Configuration["JWT:ValidIssuer"],
                audience: Configuration["JWT:validAudience"],
                //expires: Configuration["JWT:DuratiinInDay"]
                expires: DateTime.Now.AddDays(double.Parse(Configuration["JWT:DuratiinInDay"])),
                claims: aouthClaim,
                signingCredentials: new SigningCredentials(aouthKey, SecurityAlgorithms.HmacSha256)



                ) ;
            return new JwtSecurityTokenHandler().WriteToken(token);
            


        }
    }
}
