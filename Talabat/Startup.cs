using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Talabat.core.IReposateres;
using Talabat.Errors;
using Talabat.Extintions;
using Talabat.Helper;
using Talabat.Middelwaer;
using TalabatReposatrey;
using TalabatReposatrey.Data;
using TalabatReposatrey.Identitey;

namespace Talabat
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Talabat", Version = "v1" });
            });
            services.AddDbContext<StoreContext>(optionsAction =>
            optionsAction.UseSqlServer(Configuration.GetConnectionString("DefultConnection")));
            services.AddDbContext<AppIdenentiyDB>(optionsAction =>
                            optionsAction.UseSqlServer(Configuration.GetConnectionString("IdentityDB")));
            services.AddApplicationServes();
            services.IdentityServesiszz(Configuration);

            //services.AddControllers().AddJsonOptions(x =>
            //    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            services.AddSingleton<IConnectionMultiplexer>(S =>
            {
                var conn = ConfigurationOptions.Parse( Configuration.GetConnectionString("RedisConn"));
                return ConnectionMultiplexer.Connect(conn);
            });




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
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
        }
    }
}
