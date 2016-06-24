namespace Domain.Features.Products
{
    using System;
    using System.Linq;
    using MediatR;

    public class SummaryQuery : IAsyncRequest<Summary>
    {
        public Guid Id { get; set; }
    }
}