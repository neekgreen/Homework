﻿namespace WebHost.Models.Products
{
    using System;
    using System.Linq;
    using Domain.Features.Products;
    using PaginableCollections;

    public class IndexViewModel
    {
        public IndexViewModel(IPaginable<ListItem> paginable, ListQuery query)
        {
            this.Items = paginable;
            this.FilterText = query.FilterText;
        }

        public string FilterText { get; set; }
        public IPaginable<ListItem> Items { get; set; }
    }
}