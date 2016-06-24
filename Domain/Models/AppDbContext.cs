namespace Domain.Models
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Interception;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using EntityFramework.Filters;
    using MediatR;
    using Serilog;
    using Domain.Shared;

    public class AppDbContext : DbContext, IAppDbContext
    {
        private DbContextTransaction currentTransaction;

        private readonly IMediator mediator;
        private readonly ILogger logger = Log.ForContext<AppDbContext>();

        public AppDbContext()
            : this(null) { }

        public AppDbContext(IMediator mediator)
            : base("name=AppDbContext")
        {
            this.ContextId = Guid.NewGuid();
            this.mediator = mediator;

            //# Disable database migrations.
            Database.SetInitializer<DbContext>(null);
        }

        public IDbSet<Product> Products { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<Cart> Carts { get; set; }

        public Guid ContextId { get; private set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            DbInterception.Add(new FilterInterceptor());

            modelBuilder
                .Types<IEntity>()
                .Configure(t => t.Ignore(e => e.Events));

            modelBuilder
                .Types<Entity>()
                .Configure(t =>
                    {
                        t.Property(p => p.Id).HasColumnName("RowId");
                        t.Property(p => p.InternalId).HasColumnName(t.ClrType.Name + "Id").IsKey();
                    });


            modelBuilder.Entity<Product>()
                .ToTable("Product");

            modelBuilder.Entity<Order>()
                .ToTable("Order");

            modelBuilder.Entity<Order>()
              .HasMany(t => t.OrderItems).WithRequired().HasForeignKey(t => t.OrderId);

            modelBuilder.Entity<OrderItem>()
                .ToTable("OrderItem");

            modelBuilder.Entity<OrderItem>()
                .HasRequired(t => t.Product).WithMany().HasForeignKey(t => t.ProductId);

            modelBuilder.Entity<Cart>()
                .ToTable("Cart");

            modelBuilder.Entity<Cart>()
              .HasMany(t => t.CartItems).WithRequired().HasForeignKey(t => t.CartId);

            modelBuilder.Entity<CartItem>()
                .ToTable("CartItem");

            modelBuilder.Entity<CartItem>()
                .HasRequired(t => t.Product).WithMany().HasForeignKey(t => t.ProductId);


            modelBuilder.Conventions.Add(
                FilterConvention.Create<IDeletable, bool>("ExcludeDeleted", (e, isDeleted) => e.IsDeleted == false));
        }

        public override int SaveChanges()
        {
            PublishDomainEvents();
            UpdateMultitenantEntities();

            return base.SaveChanges();
        }

        private void PublishDomainEvents()
        {
            var domainEventEntities =
                ChangeTracker.Entries<IEntity>()
                    .Select(po => po.Entity)
                    .Where(po => po.Events != null && po.Events.Any())
                    .ToArray();

            if (mediator != null)
            {
                foreach (var entity in domainEventEntities)
                {
                    var events = entity.Events.OfType<IAsyncNotification>().ToArray();
                    entity.Events.Clear();

                    foreach (var domainEvent in events)
                    {
                        this.mediator.PublishAsync(domainEvent);
                    }
                }
            }
        }

        private void UpdateMultitenantEntities()
        {
            //if (userContext == null)
            //    return;

            //ChangeTracker.Entries<ITenantEntity>()
            //    .Where(e => e.State == EntityState.Added)
            //    .Select(e => e.Entity)
            //    .ToList()
            //    .ForEach(e =>
            //    {
            //        e.SetTenant(userContext);
            //    });
        }

        public void BeginTransaction()
        {
            try
            {
                if (this.currentTransaction != null)
                {
                    return;
                }

                this.currentTransaction = Database.BeginTransaction(IsolationLevel.ReadCommitted);
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, "Begin Transaction");
                throw;
            }
        }

        public void CloseTransaction()
        {
            CloseTransaction(exception: null);
        }

        public void CloseTransaction(Exception exception)
        {
            try
            {
                if (this.currentTransaction != null && exception != null)
                {
                    this.logger.Error(exception, "Close transaction before Save Changes");
                    this.currentTransaction.Rollback();
                    return;
                }

                SaveChanges();

                if (this.currentTransaction != null)
                {
                    this.currentTransaction.Commit();
                }
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, "Close transaction during save changes.");
                if (this.currentTransaction != null && this.currentTransaction.UnderlyingTransaction.Connection != null)
                {
                    this.currentTransaction.Rollback();
                }

                throw;
            }
            finally
            {
                if (this.currentTransaction != null)
                {
                    this.currentTransaction.Dispose();
                    this.currentTransaction = null;
                }
            }
        }
    }
}