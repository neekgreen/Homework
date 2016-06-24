namespace Domain.Models
{
    using System;
    using System.Linq;
    using Domain.Shared;
    using MediatR;

    public class CartUpdated : IDomainEvent, IAsyncNotification
    {
        public CartUpdated(Cart cart)
        {
            this.Cart = cart;
        }

        public Cart Cart { get; private set; }
    }
}