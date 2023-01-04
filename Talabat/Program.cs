using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Talabat.core.Entites.Identity;
using Talabat.Extintions;
using Talabat.Middelwaer;
using TalabatReposatrey.Data;
using TalabatReposatrey.Identitey;

namespace Talabat
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            #region Configration
            var builder = WebApplication.CreateBuilder(args);
            //config 
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(c =>
               {
                   c.SwaggerDoc("v1", new OpenApiInfo { Title = "Talabat", Version = "v1" });
               });
            builder.Services.AddDbContext<StoreContext>(optionsAction =>
            optionsAction.UseSqlServer(builder.Configuration.GetConnectionString("DefultConnection")));
            builder.Services.AddDbContext<AppIdenentiyDB>(optionsAction =>
                            optionsAction.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDB")));
            builder.Services.AddApplicationServes();
            builder.Services.IdentityServesiszz(builder.Configuration);

            //services.AddControllers().AddJsonOptions(x =>
            //    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            builder.Services.AddSingleton<IConnectionMultiplexer>(S =>
            {
                var conn = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("RedisConn"));
                return ConnectionMultiplexer.Connect(conn);
            });

            #endregion

            var app = builder.Build();

            #region Aplly seeding and migration
            var serves = app.Services;
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
            #endregion


            #region Configure
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Talabat v1"));
            }

            app.UseMiddleware<MiddelwareExption>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            #endregion

            app.Run();
        }




    }
}
