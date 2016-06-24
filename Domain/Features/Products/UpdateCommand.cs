namespace Domain.Features.Products
{
    using System;
    using System.Linq;
    using Domain.Models;
    using MediatR;

    public class UpdateCommand : IAsyncRequest<Summary>
    {
        public Guid Id { get; set; }
        public string CommonName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}