namespace Domain.Features.AvailableProducts
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
                this.context.Products
                    .AsExpandable()
                    .Where(BuildWherePredicate(message))
                    .OrderBy(t=> t.CommonName)
                    .ProjectTo<ListItem>(mapper.ConfigurationProvider)
                    .ToPaginable(message);

            return paginable;
        }

        private Expression<Func<Product, bool>> BuildWherePredicate(ListQuery message)
        {
            var result =
                PredicateBuilder.True<Product>()
                    .And(GetFilterPredicateFromFilters(message))
                    .And(GetFilterPredicateFromFilterText(message));

            return result;
        }

        private Expression<Func<Product, bool>> GetFilterPredicateFromFilterText(ListQuery message)
        {
            var result = PredicateBuilder.True<Product>();

            if (!string.IsNullOrWhiteSpace(message.FilterText))
            {
                var predicate = PredicateBuilder.False<Product>();
                predicate = predicate.Or(t => t.CommonName.Contains(message.FilterText));

                result = result.And(predicate);
            }

            return result;
        }

        private Expression<Func<Product, bool>> GetFilterPredicateFromFilters(ListQuery message)
        {
            return PredicateBuilder.True<Product>();
        }
    }
}