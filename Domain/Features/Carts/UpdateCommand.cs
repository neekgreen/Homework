namespace Domain.Features.Carts
{
    using System;
    using System.Linq;
    using Domain.Models;
    using MediatR;

    public class UpdateCommand : IAsyncRequest<Summary>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}