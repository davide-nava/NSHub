// <copyright file="OrderConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class OrderConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Order", "dbo");


        builder.Property(e => e.OrderNumber).HasMaxLength(50).IsRequired();
        builder.Property(e => e.Year).IsRequired();
        builder.Property(e => e.Date).HasColumnType("datetime").IsRequired();
        builder.Property(e => e.OrderType).HasMaxLength(20).IsRequired();
        builder.Property(e => e.CustomerId).IsRequired(false);
        builder.Property(e => e.SupplierId).IsRequired(false);
        builder.Property(e => e.QuotationId).IsRequired(false);
        builder.Property(e => e.PaymentId).IsRequired(false);
        builder.Property(e => e.ShippingAddressId).IsRequired(false);
        builder.Property(e => e.CurrencyCode).HasMaxLength(3).IsRequired().HasDefaultValueSql("('EUR')");
        builder.Property(e => e.ExchangeRate).HasPrecision(18, 6).IsRequired();
        builder.Property(e => e.TotalNetAmount).HasPrecision(18, 8).IsRequired();
        builder.Property(e => e.TotalVatAmount).HasPrecision(18, 8).IsRequired();
        builder.Property(e => e.TotalGrossAmount).HasPrecision(18, 8).IsRequired();
        builder.Property(e => e.StatusCode).HasMaxLength(30).IsRequired().HasDefaultValueSql("('Draft')");
        builder.Property(e => e.Notes).IsRequired(false);

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Customer)
            .WithMany(p => p.Orders)
            .HasForeignKey(e => e.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Payment)
            .WithMany(p => p.Orders)
            .HasForeignKey(e => e.PaymentId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Quotation)
            .WithMany(p => p.Orders)
            .HasForeignKey(e => e.QuotationId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Supplier)
            .WithMany(p => p.Orders)
            .HasForeignKey(e => e.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
