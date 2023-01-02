using AutoMapper;
using Microsoft.Extensions.Configuration;
using Talabat.core.Entites;
using Talabat.DTOS;
using System.Linq;


namespace Talabat.Helper
{
    public class ProductPictuerUrlResolver :IValueResolver
        <product,ProductDTO,string>
    {
        public IConfiguration Configuration { get; }
        public ProductPictuerUrlResolver(IConfiguration configuration)
        {
            Configuration = configuration;
        }
      


        public string Resolve(product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{Configuration["ApiBaseUrl"]}{source.PictureUrl}";
            return null;
        }
    }
}
