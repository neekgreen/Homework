namespace Domain.Features.Orders
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
            var orders =
                this.context.Orders
                    .Single(t=> t.Id == message.Id);

            var orderSummary =
                this.mapper.Map<Summary>(orders);

            return orderSummary;
        }
    }
}