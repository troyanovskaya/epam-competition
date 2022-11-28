﻿using LocalGoods.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalGoods.DAL.Configurations
{
    public class ProductStorageConfiguration: IEntityTypeConfiguration<ProductStorage>
    {
        public void Configure(EntityTypeBuilder<ProductStorage> builder)
        {
            builder
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductStorages);

            builder
                .HasOne(ps => ps.UnitType)
                .WithMany(ut => ut.ProductStorages);
        }
    }
}