// <copyright file="OrderRowConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class OrderRowConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<OrderRow>
{
    public void Configure(EntityTypeBuilder<OrderRow> builder)
    {
        _ = builder.ToTable("OrderRow", "dbo");

        _ = builder.Property(e => e.OrderId).IsRequired();
        _ = builder.Property(e => e.RowNumber).IsRequired();
        _ = builder.Property(e => e.ArticleId).IsRequired(false);
        _ = builder.Property(e => e.ArticleCode).HasMaxLength(255).IsRequired(false);
        _ = builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        _ = builder.Property(e => e.Quantity).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.DeliveredQuantity).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.InvoicedQuantity).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.UnitPrice).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.DiscountPercentage).HasPrecision(18, 8).IsRequired();
        _ = builder.Property(e => e.LineTotal).HasPrecision(18, 8).IsRequired();
        _ = builder.Property(e => e.VatId).IsRequired(false);
        _ = builder.Property(e => e.WarehouseId).IsRequired(false);
        _ = builder.Property(e => e.ExpectedDeliveryDate).HasColumnType("date").IsRequired(false);

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Article)
            .WithMany(p => p.OrderRows)
            .HasForeignKey(e => e.ArticleId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Order)
            .WithMany(p => p.OrderRows)
            .HasForeignKey(e => e.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Vat)
            .WithMany(p => p.OrderRows)
            .HasForeignKey(e => e.VatId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Warehouse)
            .WithMany(p => p.OrderRows)
            .HasForeignKey(e => e.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
