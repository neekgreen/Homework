namespace Domain.Models
{
    using System;
    using System.Linq;
    using Domain.Shared;

    public class CartItem : Entity, IDeletable
    {
        public CartItem(Cart cart, Product product, int quantity)
        {
            this.CartId = cart.InternalId;
            this.Product = product;

            this.Quantity = quantity;
            this.UnitPrice = product.UnitPrice;
            UpdateTotalPrice();
        }

        private CartItem() { }


        public long CartId { get; private set; }

        public long ProductId { get; private set; }
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice { get; private set; }
        public bool IsDeleted { get; private set; }


        public void UpdateQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException();

            this.Quantity = quantity;
            UpdateTotalPrice();
        }

        private void UpdateTotalPrice()
        {
            this.TotalPrice = Math.Round(this.Quantity * this.UnitPrice, 2);
        }

        public void MarkAsDeleted()
        {
            this.IsDeleted = true;
            OnUpdated();
        }
    }
}