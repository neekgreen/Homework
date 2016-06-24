namespace Domain.Features.Products
{
    using System;
    using System.Linq;

    public class Summary
    {
        public Guid Id { get; set; }
        public string CommonName { get; set; }
        public decimal UnitPrice { get; set; }

        public int OrderCount { get; set; }
    }
}