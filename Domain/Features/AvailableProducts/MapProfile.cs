namespace Domain.Features.AvailableProducts
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Domain.Models;

    public class MapProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Product, ListItem>();
        }
    }
}