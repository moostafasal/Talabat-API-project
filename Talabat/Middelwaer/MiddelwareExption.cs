using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Errors;

namespace Talabat.Middelwaer
{
    public class MiddelwareExption
    {
        private readonly RequestDelegate next;
        private readonly ILogger<MiddelwareExption> logger;
        private readonly IHostEnvironment host;

        public MiddelwareExption(RequestDelegate Next,ILogger<MiddelwareExption> Logger,IHostEnvironment Host)
        {
            next = Next;
            logger = Logger;
            host = Host;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);


            }
            catch (System.Exception Ex)
            {//save log in DB
                logger.LogError(Ex, Ex.Message);
                context.Response.ContentType="application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var errorRespons = host.IsDevelopment() ?
                    new ApiExptionRespons((int)HttpStatusCode.InternalServerError, Ex.Message, Ex.StackTrace) :
                    new ApiExptionRespons((int)HttpStatusCode.InternalServerError);
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(errorRespons, options);
                await context.Response.WriteAsync(json);  
            }
        }
    }
}
