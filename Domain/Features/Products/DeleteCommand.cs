namespace Domain.Features.Products
{
    using System;
    using System.Linq;
    using MediatR;

    public class DeleteCommand : IAsyncRequest<int>
    {
        public Guid Id { get; set; }
    }
}