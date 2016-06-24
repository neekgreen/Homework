namespace Domain.Features.Carts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Summary
    {
        public Guid Id { get; set; }
        public decimal CartTotal { get; set; }
        public List<Item> Items { get; set; }


        public class Item
        {
            public Guid Id { get; set; }
            public string CommonName { get; set; }
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; }
            public decimal TotalPrice { get; set; }
        }
    }
}