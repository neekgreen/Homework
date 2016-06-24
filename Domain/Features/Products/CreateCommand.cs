namespace Domain.Features.Products
{
    using System;
    using System.Linq;
    using Domain.Models;
    using MediatR;

    public class CreateCommand : IAsyncRequest<Summary>
    {
        public string CommonName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}