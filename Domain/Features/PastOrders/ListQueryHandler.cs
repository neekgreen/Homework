namespace Domain.Features.PastOrders
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Domain.Models;
    using LinqKit;
    using MediatR;
    using PaginableCollections;

    public class ListQueryHandler : IAsyncRequestHandler<ListQuery, IPaginable<ListItem>>
    {
        private readonly IAppDbContext context;
        private readonly IMapper mapper;

        public ListQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        Task<IPaginable<ListItem>> IAsyncRequestHandler<ListQuery, IPaginable<ListItem>>.Handle(ListQuery message)
        {
            return Task.FromResult(HandleInternal(message));
        }

        private IPaginable<ListItem> HandleInternal(ListQuery message)
        {
            var paginable =
                this.context.Orders
                    .AsExpandable()
                    .Where(BuildWherePredicate(message))
                    .OrderByDescending(t => t.Created)
                    .ProjectTo<ListItem>(mapper.ConfigurationProvider)
                    .ToPaginable(message);

            return paginable;
        }

        private Expression<Func<Order, bool>> BuildWherePredicate(ListQuery message)
        {
            var result =
                PredicateBuilder.True<Order>()
                    .And(GetFilterPredicateFromFilters(message))
                    .And(GetFilterPredicateFromFilterText(message));

            return result;
        }

        private Expression<Func<Order, bool>> GetFilterPredicateFromFilterText(ListQuery message)
        {
            var result = PredicateBuilder.True<Order>();

            if (!string.IsNullOrWhiteSpace(message.FilterText))
            {
                var predicate = PredicateBuilder.False<Order>();
                predicate = predicate.Or(t => t.OrderNumber.Contains(message.FilterText));

                result = result.And(predicate);
            }

            return result;
        }

        private Expression<Func<Order, bool>> GetFilterPredicateFromFilters(ListQuery message)
        {
            return PredicateBuilder.True<Order>();
        }
    }
}