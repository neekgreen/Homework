namespace Domain.Features.Carts
{
    using System;
    using System.Linq;
    using MediatR;

    public class SubmitCommand : IAsyncRequest<SubmitResult>
    {
        public Guid Id { get; set; }
    }
}