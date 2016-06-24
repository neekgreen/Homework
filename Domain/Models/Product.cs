namespace Domain.Models
{
    using System;
    using System.Linq;
    using Domain.Shared;

    public class Product : Entity, IDeletable
    {
        public Product(string commonName, decimal unitPrice)
        {
            this.CommonName = commonName;
            this.UnitPrice = unitPrice;
        }

        private Product() { }


        public string CommonName { get; private set; }
        public decimal UnitPrice { get; private set; }
        public bool IsDeleted { get; private set; }


        public void Update(string commonName, decimal unitPrice)
        {
            this.CommonName = commonName;
            this.UnitPrice = unitPrice;

            OnUpdated(new ProductUpdated(this));
        }

        public void MarkAsDeleted()
        {
            this.IsDeleted = true;

            OnUpdated(new ProductDeleted(this));
        }
    }
}