namespace Domain.Features.Products
{
    using System;
    using System.Linq;

    public class ListItem
    {
        public Guid Id { get; set; }
        public string CommonName { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? LastUpdated { get; set; }
    }
}