// <copyright file="StockMovementConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class StockMovementConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<StockMovement>
{
    public void Configure(EntityTypeBuilder<StockMovement> builder)
    {
        builder.ToTable("StockMovement", "dbo");


        builder.Property(e => e.MovementDate).HasColumnType("datetime").IsRequired();
        builder.Property(e => e.MovementType).HasMaxLength(30).IsRequired();
        builder.Property(e => e.ArticleId).IsRequired();
        builder.Property(e => e.WarehouseId).IsRequired();
        builder.Property(e => e.TargetWarehouseId).IsRequired(false);
        builder.Property(e => e.Quantity).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.UnitCost).HasPrecision(18, 4).IsRequired(false);
        builder.Property(e => e.DeliveryNoteRowId).IsRequired(false);
        builder.Property(e => e.InvoiceRowId).IsRequired(false);
        builder.Property(e => e.OrderRowId).IsRequired(false);
        builder.Property(e => e.BatchNumber).HasMaxLength(100).IsRequired(false);
        builder.Property(e => e.SerialCode).HasMaxLength(100).IsRequired(false);
        builder.Property(e => e.Notes).IsRequired(false);

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Article)
            .WithMany(p => p.StockMovements)
            .HasForeignKey(e => e.ArticleId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.DeliveryNoteRow)
            .WithMany(p => p.StockMovements)
            .HasForeignKey(e => e.DeliveryNoteRowId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.OrderRow)
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
