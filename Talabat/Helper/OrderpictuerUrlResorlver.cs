using AutoMapper;
using Microsoft.Extensions.Configuration;
using Talabat.core.Entites.OrderAgregt;
using Talabat.DTOS;

namespace Talabat.Helper
{
    public class OrderpictuerUrlResorlver : IValueResolver<OrderItem, OrderItemDto, string>
    {
        public IConfiguration Configuration { get; }
        public OrderpictuerUrlResorlver(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.product.pictuerUrl))
                return $"{Configuration["ApiBaseUrl"]}{source.product.pictuerUrl}";
            return null;
        }
    }
}
