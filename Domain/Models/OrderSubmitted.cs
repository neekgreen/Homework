namespace Domain.Models
{
    using System;
    using System.Linq;
    using Domain.Shared;
    using MediatR;

    public class OrderSubmitted : IDomainEvent, IAsyncNotification
    {
        public OrderSubmitted(Order order, Cart cart)
        {
            this.Order = order;
            this.Cart = cart;
        }

        public Order Order { get; private set; }
        public Cart Cart { get; private set; }
    }
}