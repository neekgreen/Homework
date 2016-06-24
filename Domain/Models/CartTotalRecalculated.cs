namespace Domain.Models
{
    using System;
    using System.Linq;
    using Domain.Shared;
    using MediatR;

    public class CartTotalRecalculated : IDomainEvent, IAsyncNotification
    {
        public CartTotalRecalculated(Cart cart)
        {
            this.Cart = cart;
        }

        public Cart Cart { get; private set; }
    }
}