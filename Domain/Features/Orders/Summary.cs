namespace Domain.Features.Orders
{
    using System;
    using System.Linq;

    public class Summary
    {
        public Guid Id { get; set; }
        public string OrderNumber { get; set; }
    }
}