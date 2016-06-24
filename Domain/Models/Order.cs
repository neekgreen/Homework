namespace Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Shared;

    public class Order : Entity
    {
        public Order(string orderNumber, Cart cart)
        {
            this.OrderNumber = orderNumber;
            this.OrderItems =
                new HashSet<OrderItem>(
                    cart.CartItems.Select(t =>
                       new OrderItem(this, t)));

            this.OrderTotal = this.OrderItems.Sum(t => t.TotalPrice);

            CaptureEvent(new OrderSubmitted(this, cart));
        }

        private Order() { }


        public string OrderNumber { get; private set; }
        public ICollection<OrderItem> OrderItems { get; private set; }
        public decimal OrderTotal { get; private set; }
    }
}