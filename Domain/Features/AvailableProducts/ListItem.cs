namespace Domain.Features.AvailableProducts
{
    using System;
    using System.Linq;

    public class ListItem
    {
        public ListItem()
        {
            this.Quantity = 1;
        }

        public Guid Id { get; set; }
        public string CommonName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}