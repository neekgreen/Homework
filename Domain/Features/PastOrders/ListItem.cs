namespace Domain.Features.PastOrders
{
    using System;
    using System.Linq;

    public class ListItem
    {
        public Guid Id { get; set; }
        public string OrderNumber { get; set; }
        public int ItemCount { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? LastUpdated { get; set; }
    }
}