namespace Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Shared;

    public class Cart : Entity
    {
        public Cart()
        {
            this.CartItems = new HashSet<CartItem>();
        }


        public ICollection<CartItem> CartItems { get; private set; }
        public decimal CartTotal { get; private set; }


        public void Include(Product product, int quantity)
        {
            var cartItem =
                this.CartItems.Where(t => t.Product == product)
                    .FirstOrDefault();

            if (cartItem == null)
            {
                cartItem = new CartItem(this, product, quantity);
                this.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.UpdateQuantity(quantity);
            }

            UpdateTotalPrice();

            OnUpdated(
                new CartUpdated(this),
                new CartTotalRecalculated(this));
        }

        public void Clear()
        {
            this.CartItems.Clear();

            UpdateTotalPrice();

            OnUpdated(
                new CartUpdated(this),
                new CartTotalRecalculated(this));
        }

        private void UpdateTotalPrice()
        {
            if (this.CartItems == null)
                this.CartTotal = decimal.Zero;
            else
                this.CartTotal = Math.Round(this.CartItems.Where(t => !t.IsDeleted).Sum(t => t.TotalPrice), 2);
        }

        public Order Submit(string orderNumber)
        {
            return new Order(orderNumber, this);
        }
    }
}