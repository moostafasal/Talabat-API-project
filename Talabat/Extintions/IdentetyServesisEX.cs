using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Talabat.core.Entites.Identity;
using TalabatReposatrey.Identitey;

namespace Talabat.Extintions
{
    public static class IdentetyServesisEX
    {
        public static IServiceCollection  IdentityServesiszz(this IServiceCollection Services,IConfiguration configuration)
        {
            Services.AddIdentity<AppUser, IdentityRole>(op =>
            {
                //op.Password.RequireLowercase
            })
            .AddEntityFrameworkStores<AppIdenentiyDB>();
            Services.AddAuthentication(/*JwtBearerDefaults.AuthenticationScheme*/ options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    ValidateAudience = true,
                    ValidAudience=configuration["JWT:validAudience"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:key"]))





                };
            });

            return Services;

        }

    }
    }
