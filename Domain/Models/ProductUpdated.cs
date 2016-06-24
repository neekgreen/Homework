namespace Domain.Models
{
    using System;
    using System.Linq;
    using Domain.Shared;
    using MediatR;

    public class ProductUpdated : IDomainEvent, IAsyncNotification
    {
        public ProductUpdated(Product product)
        {
            this.Product = product;
        }

        public Product Product { get; private set; }
    }
}