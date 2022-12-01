using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LocalGoods.DAL.Configurations;
using LocalGoods.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;

namespace LocalGoods.DAL.Contexts
{
    public class LocalGoodsDbContext: IdentityDbContext<User, Role, Guid>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LocalGoodsDbContext(
            DbContextOptions<LocalGoodsDbContext> options,
            IHttpContextAccessor httpContextAccessor): base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
        }
        
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddAuditEntityProperties();
            
            return base.SaveChangesAsync(cancellationToken);
        }

        private void AddAuditEntityProperties()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditEntity<Guid> &&
                            (e.State == EntityState.Added ||
                             e.State == EntityState.Modified));

            var currentUser =
                _httpContextAccessor.HttpContext.User.Claims
                    .Where(c => c.ValueType == JwtRegisteredClaimNames.Sub)
                    .Select(c => c.Value)
                    .FirstOrDefault()
                ?? Guid.Empty.ToString();

            foreach (var entityEntry in entries)
            {
                var auditEntity = (AuditEntity<Guid>)entityEntry.Entity;
                auditEntity.ModifiedAt = DateTime.UtcNow;
                auditEntity.ModifiedBy = new Guid(currentUser);

                if (entityEntry.State == EntityState.Added)
                {
                    auditEntity.CreatedAt = DateTime.UtcNow;
                    auditEntity.CreatedBy = new Guid(currentUser);
                }
            }
        }

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
    }
}