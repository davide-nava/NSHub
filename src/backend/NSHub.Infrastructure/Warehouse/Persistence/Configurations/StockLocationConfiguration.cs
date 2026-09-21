// <copyright file="StockLocationConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Infrastructure.Warehouse.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Warehouse.Entities;
using NSHub.Domain.Warehouse.ValueObjects;

/// <summary>
/// EF Core configuration for <see cref="StockLocation"/>.
/// </summary>
public class StockLocationConfiguration : IEntityTypeConfiguration<StockLocation>
{
    public void Configure(EntityTypeBuilder<StockLocation> builder)
    {
        _ = builder.ToTable("StockLocations");

        _ = builder.HasKey(sl => sl.Id);
        _ = builder.Property(sl => sl.Id)
            .HasConversion(id => id.Value, value => new StockLocationId(value))
            .ValueGeneratedNever();

        _ = builder.Property(sl => sl.Code)
            .HasMaxLength(50)
            .IsRequired();

        _ = builder.HasIndex(sl => sl.Code).IsUnique();

        _ = builder.Property(sl => sl.Name)
            .HasMaxLength(150)
            .IsRequired();

        _ = builder.Property(sl => sl.WarehouseCode)
            .HasMaxLength(50)
            .IsRequired();

        _ = builder.Property(sl => sl.IsActive)
            .IsRequired();
    }
}
