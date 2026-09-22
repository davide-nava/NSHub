// <copyright file="InventoryStockConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Warehouse.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Warehouse.ValueObjects;

/// <summary>
/// EF Core configuration for <see cref="InventoryStock"/>.
/// </summary>
public class InventoryStockConfiguration : IEntityTypeConfiguration<InventoryStock>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<InventoryStock> builder)
    {
        _ = builder.ToTable("InventoryStocks");

        _ = builder.HasKey(s => s.Id);

        _ = builder.Property(s => s.ArticleId)
            .HasConversion(id => id.Value, value => new ArticleId(value))
            .IsRequired();

        _ = builder.Property(s => s.LocationId)
            .HasConversion(id => id.Value, value => new StockLocationId(value))
            .IsRequired();

        _ = builder.HasIndex(s => new { s.ArticleId, s.LocationId }).IsUnique();

        _ = builder.Property(s => s.QuantityOnHand)
            .HasPrecision(18, 4)
            .IsRequired();

        _ = builder.Property(s => s.QuantityReserved)
            .HasPrecision(18, 4)
            .IsRequired();

        _ = builder.Ignore(s => s.AvailableQuantity);
    }
}
