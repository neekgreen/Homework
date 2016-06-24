namespace Domain.Models
{
    using System;
    using System.Linq;
    using Domain.Shared;
    using MediatR;

    public class ProductDeleted : IDomainEvent, IAsyncNotification
    {
        public ProductDeleted(Product product)
        {
            this.Product = product;
        }

        public Product Product { get; private set; }
    }
}