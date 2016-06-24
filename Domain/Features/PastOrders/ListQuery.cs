namespace Domain.Features.PastOrders
{
    using System;
    using System.Linq;
    using MediatR;
    using PaginableCollections;

    public class ListQuery : IAsyncRequest<IPaginable<ListItem>>, IPaginableInfo
    {
        public ListQuery()
        {
            this.ItemCountPerPage = 20;
            this.PageNumber = 1;
        }

        public int ItemCountPerPage { get; set; }
        public int PageNumber { get; set; }

        public string FilterText { get; set; }
    }
}