namespace Domain.Features.Carts
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Domain.Models;

    public class MapProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Order, SubmitResult>();

            CreateMap<Cart, Summary>()
                .ForMember(t => t.Items, o => o.MapFrom(s => s.CartItems));

            CreateMap<CartItem, Summary.Item>()
                .ForMember(t => t.CommonName, o => o.MapFrom(s => s.Product.CommonName));
        }
    }
}