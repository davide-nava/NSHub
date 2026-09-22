// <copyright file="InventoryMovementConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Warehouse.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Warehouse.ValueObjects;

/// <summary>
/// EF Core configuration for <see cref="InventoryMovement"/>.
/// </summary>
public class InventoryMovementConfiguration : IEntityTypeConfiguration<InventoryMovement>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<InventoryMovement> builder)
    {
        _ = builder.ToTable("InventoryMovements");

        _ = builder.HasKey(m => m.Id);
        _ = builder.Property(m => m.Id)
            .HasConversion(id => id.Value, value => new InventoryMovementId(value))
            .ValueGeneratedNever();

        _ = builder.Property(m => m.ArticleId)
            .HasConversion(id => id.Value, value => new ArticleId(value))
            .IsRequired();

        _ = builder.Property(m => m.SourceLocationId)
            .HasConversion(id => id.HasValue ? id.Value.Value : (Guid?)null, value => value.HasValue ? new StockLocationId(value.Value) : null);

        _ = builder.Property(m => m.DestinationLocationId)
            .HasConversion(id => id.HasValue ? id.Value.Value : (Guid?)null, value => value.HasValue ? new StockLocationId(value.Value) : null);

        _ = builder.Property(m => m.Quantity)
            .HasPrecision(18, 4)
            .IsRequired();

        _ = builder.Property(m => m.Type)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        _ = builder.Property(m => m.ReferenceNumber)
            .HasMaxLength(100)
            .IsRequired();

        _ = builder.Property(m => m.TimestampUtc)
            .IsRequired();

        _ = builder.Property(m => m.Notes)
            .HasMaxLength(1000);
    }
}
