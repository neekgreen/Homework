namespace Domain.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Domain.Shared;

    public interface IAppDbContext : IDbContext
    {
        IDbSet<Product> Products { get; }
        IDbSet<Order> Orders { get; }
        IDbSet<Cart> Carts { get; }

        int SaveChanges();

        void BeginTransaction();
        void CloseTransaction();
    }
}