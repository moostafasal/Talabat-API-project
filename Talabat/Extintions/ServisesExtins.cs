using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Talabat.core.IReposateres;
using Talabat.core.Services;
using Talabat.Errors;
using Talabat.Helper;
using Talabat.Serves;
using TalabatReposatrey;

namespace Talabat.Extintions
{
    public static class ServisesExtins
    {
        public static IServiceCollection AddApplicationServes(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenaricReposatery<>), typeof(GenaricReposatrey<>));
            //services.AddAutoMapper(M => M.AddProfile(new ProfilsDTO()));
            services.AddScoped(typeof(IBascketReposatry), typeof(BasketReposatry));
            services.AddScoped(typeof(IOrderServes), typeof(OrderServeis));
            services.AddScoped(typeof(IOrderServes), typeof(OrderServeis));
            services.AddScoped(typeof(IUnitOfWork), typeof(UintOfwork));


            services.AddScoped<ITookenServiice, TokenServes>();

            services.AddAutoMapper(typeof(ProfilsDTO));
            services.Configure<ApiBehaviorOptions>(Options =>
            {
                //momdel state was not valid acthin context its contan the action active now 
                Options.InvalidModelStateResponseFactory = ActionContext =>
                {
                    var errors = ActionContext.ModelState.Where(M => M.Value.Errors.Count() > 0)
                    //lisst of model has error  we use select meny
                    .SelectMany(M => M.Value.Errors).Select(E => E.ErrorMessage).ToArray();
                    var ErrorrRespons = new ApiValidationRespons()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(ErrorrRespons);
                };
            });
            return services;
        }
    }
}
