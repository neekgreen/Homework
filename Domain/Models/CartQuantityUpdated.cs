namespace Domain.Models
{
    using System;
    using System.Linq;
    using Domain.Shared;
    using MediatR;

    public class CartQuantityUpdated : IDomainEvent, IAsyncNotification
    {
        public CartQuantityUpdated(Cart cart, Product product)
        {
            this.Cart = cart;
        }

        public Cart Cart { get; private set; }
    }
}