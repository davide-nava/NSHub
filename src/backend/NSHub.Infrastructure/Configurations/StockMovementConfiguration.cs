// <copyright file="StockMovementConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class StockMovementConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<StockMovement>
{
    public void Configure(EntityTypeBuilder<StockMovement> builder)
    {
        _ = builder.ToTable("StockMovement", "dbo");

        _ = builder.Property(e => e.MovementDate).HasColumnType("datetime").IsRequired();
        _ = builder.Property(e => e.MovementType).HasMaxLength(30).IsRequired();
        _ = builder.Property(e => e.ArticleId).IsRequired();
        _ = builder.Property(e => e.WarehouseId).IsRequired();
        _ = builder.Property(e => e.TargetWarehouseId).IsRequired(false);
        _ = builder.Property(e => e.Quantity).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.UnitCost).HasPrecision(18, 4).IsRequired(false);
        _ = builder.Property(e => e.DeliveryNoteRowId).IsRequired(false);
        _ = builder.Property(e => e.InvoiceRowId).IsRequired(false);
        _ = builder.Property(e => e.OrderRowId).IsRequired(false);
        _ = builder.Property(e => e.BatchNumber).HasMaxLength(100).IsRequired(false);
        _ = builder.Property(e => e.SerialCode).HasMaxLength(100).IsRequired(false);
        _ = builder.Property(e => e.Notes).IsRequired(false);

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Article)
            .WithMany(p => p.StockMovements)
            .HasForeignKey(e => e.ArticleId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.DeliveryNoteRow)
            .WithMany(p => p.StockMovements)
            .HasForeignKey(e => e.DeliveryNoteRowId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.OrderRow)
            .WithMany(p => p.StockMovements)
            .HasForeignKey(e => e.OrderRowId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.TargetWarehouse)
            .WithMany(p => p.TargetStockMovements)
            .HasForeignKey(e => e.TargetWarehouseId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Warehouse)
            .WithMany(p => p.StockMovements)
            .HasForeignKey(e => e.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
