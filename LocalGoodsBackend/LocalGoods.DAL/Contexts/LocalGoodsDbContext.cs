﻿using System;
using LocalGoods.DAL.Configurations;
using LocalGoods.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LocalGoods.DAL.Contexts
{
    public class LocalGoodsDbContext: IdentityDbContext<User, Role, Guid>
    {
        public LocalGoodsDbContext(DbContextOptions<LocalGoodsDbContext> options): base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
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