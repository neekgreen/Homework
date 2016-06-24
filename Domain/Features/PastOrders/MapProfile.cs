namespace Domain.Features.PastOrders
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Domain.Models;

    public class MapProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Order, ListItem>()
                .ForMember(t => t.ItemCount, o => o.MapFrom(s => s.OrderItems.Count()));
        }
    }
}