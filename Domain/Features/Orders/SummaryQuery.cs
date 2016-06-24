namespace Domain.Features.Orders
{
    using System;
    using System.Linq;
    using MediatR;

    public class SummaryQuery : IAsyncRequest<Summary>
    {
        public Guid Id { get; set; }
    }
}