namespace Domain.Features.Products
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Domain.Models;

    public class MapProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Product, Summary>();
            CreateMap<Product, ListItem>();
            CreateMap<Product, UpdateCommand>();
        }
    }
}