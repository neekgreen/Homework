namespace Domain.Features.Orders
{
    using System;
    using System.Linq;

    public class CreateResult
    {
        public Guid Id { get; set; }
        public string CommonName { get; set; }
    }
}