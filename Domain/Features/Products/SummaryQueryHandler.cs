﻿namespace Domain.Features.Products
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain.Models;
    using MediatR;

    public class SummaryQueryHandler : IAsyncRequestHandler<SummaryQuery, Summary>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;

        public SummaryQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        Task<Summary> IAsyncRequestHandler<SummaryQuery, Summary>.Handle(SummaryQuery message)
        {
            return Task.FromResult(HandleInternal(message));
        }

        private Summary HandleInternal(SummaryQuery message)
        {
            var product =
                this.context.Products
                    .Single(t=> t.Id == message.Id);

            var productSummary =
                this.mapper.Map<Summary>(product);

            return productSummary;
        }
    }
}