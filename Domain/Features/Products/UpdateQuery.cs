namespace Domain.Features.Products
{
    using System;
    using System.Linq;
    using MediatR;

    public class UpdateQuery : IAsyncRequest<UpdateCommand>
    {
        public Guid Id { get; set; }
    }
}