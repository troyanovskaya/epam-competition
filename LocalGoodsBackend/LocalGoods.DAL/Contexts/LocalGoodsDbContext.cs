using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LocalGoods.DAL.Configurations;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Initializers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LocalGoods.DAL.Contexts
{
    public class LocalGoodsDbContext: IdentityDbContext<User, Role, Guid>
    {
        public LocalGoodsDbContext(DbContextOptions<LocalGoodsDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
            IdentityDataInitializer.SeedData(builder);
        }
        
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddAuditEntityProperties();
            //HandleProductDelete();

            return base.SaveChangesAsync(cancellationToken);
        }

        private void AddAuditEntityProperties()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditEntity<Guid> &&
                            (e.State == EntityState.Added ||
                             e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                var auditEntity = (AuditEntity<Guid>)entityEntry.Entity;
                auditEntity.ModifiedAt = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    auditEntity.CreatedAt = DateTime.UtcNow;
                }
            }
        }

        /*private void HandleProductDelete()
        {
            var entitiesToDelete = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted);

            foreach (var entity in entitiesToDelete)
            {
                if ((Type)entity.Entity != typeof(Product))
                {
                    continue;
                }

                entity.State = EntityState.Modified;
                entity.CurrentValues["IsDeleted"] = true;
            }
        }*/

        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UnitType> UnitTypes { get; set; }
        public DbSet<VendorPaymentMethod> VendorPaymentMethods { get; set; }
        public DbSet<VendorDeliveryMethod> VendorDeliveryMethods { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
    }
}