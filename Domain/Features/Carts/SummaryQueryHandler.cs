namespace Domain.Features.Carts
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain.Models;
    using MediatR;
    using System.Data.Entity;

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
            var carts =
                this.context.Carts
                    .Include(t => t.CartItems)
                    .Include(t => t.CartItems.Select(u => u.Product))
                    .Single(t => t.Id == message.Id);

            var summary =
                this.mapper.Map<Summary>(carts);

            return summary;
        }
    }
}