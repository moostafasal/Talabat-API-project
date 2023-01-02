using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talabat.core.Entites.Identity;
using TalabatReposatrey.Data;
using TalabatReposatrey.Identitey;

namespace Talabat
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
      var Host=  CreateHostBuilder(args).Build();
      using      var Scope = Host.Services.CreateScope();
            var serves = Scope.ServiceProvider;
            var LogerFactory = serves.GetRequiredService<ILoggerFactory>();
            try
            {
      
            var context = serves.GetRequiredService<StoreContext>();
                await context.Database.MigrateAsync();
                var IdentityDB = serves.GetRequiredService<AppIdenentiyDB>();
                await IdentityDB.Database.MigrateAsync();


                await StorContextSeed.seedAsync(context, LogerFactory);
                var UserManger = serves.GetRequiredService<UserManager<AppUser>>();
                await AppDIdentityDBseed.SeedUserAysnc(UserManger);

            }
            catch (Exception ex)
            {
                var loger = LogerFactory.CreateLogger<Program>();
                loger.LogError(ex, "an errorr occurrd apply Migration");
            }


            Host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
