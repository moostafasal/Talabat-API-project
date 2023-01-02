using AutoMapper;
using System;
using Talabat.core.Entites;
using Talabat.core.Entites.Identity;
using Talabat.core.Entites.OrderAgregt;
using Talabat.DTOS;

namespace Talabat.Helper
{
    public class ProfilsDTO:Profile
    {
        public ProfilsDTO()
        {
            CreateMap<product, ProductDTO>()
                .ForMember(D => D.productbrand, O => O.MapFrom(S => S.productbrand.Name))
                .ForMember(D => D.ProductType, O => O.MapFrom(S => S.ProductType.Name))
                .ForMember(D => D.PictureUrl, O => O.MapFrom < ProductPictuerUrlResolver>());
            //creat map for addressDto
            CreateMap<AddressDto,core.Entites.Identity.Address>().ReverseMap();
            //creat map for orderDto
            CreateMap<AddressDto,core.Entites.OrderAgregt.Address>().ReverseMap();
            
            CreateMap<CustmuerBasketDto, CustmerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<Order, OrderToDto>().ForMember(D => D.DeleveryMethod, O => O.MapFrom(S => S.DelveryMethod.ShortName)).
                ForMember(D => D.DelverMethodCost, O => O.MapFrom(S => S.DelveryMethod.Cost));
            CreateMap<OrderItem, OrderItemDto>().ForMember(D => D.ProductId, O => O.MapFrom(S => S.product.ProductId)).
                ForMember(D => D.productName, O => O.MapFrom(S => S.product.productName)).
                ForMember(D => D.pictuerUrl, O => O.MapFrom(S => S.product.pictuerUrl)).
                ForMember(D => D.pictuerUrl, O => O.MapFrom<OrderpictuerUrlResorlver>());






        }


    }
}
