namespace Domain.Models
{
    using System;
    using System.Linq;
    using Domain.Shared;

    public class OrderItem : Entity
    {
        public OrderItem(Order order, CartItem cartItem)
        {
            this.OrderId = order.InternalId;
            this.Product = cartItem.Product;

            this.Quantity = cartItem.Quantity;
            this.UnitPrice = cartItem.UnitPrice;
            this.TotalPrice = cartItem.TotalPrice;
        }

        private OrderItem() { }


        public long OrderId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice { get; private set; }

        public long ProductId { get; private set; }
        public Product Product { get; private set; }
    }
}