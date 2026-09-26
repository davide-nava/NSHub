// <copyright file="InvoiceConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class InvoiceConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        _ = builder.ToTable("Invoice", "dbo");

        _ = builder.Property(e => e.InvoiceNumber).HasMaxLength(50).IsRequired();
        _ = builder.Property(e => e.Year).IsRequired();
        _ = builder.Property(e => e.Date).HasColumnType("datetime").IsRequired(false);
        _ = builder.Property(e => e.InvoiceTypeId).IsRequired(false);
        _ = builder.Property(e => e.CustomerId).IsRequired(false);
        _ = builder.Property(e => e.SupplierId).IsRequired(false);
        _ = builder.Property(e => e.IsPurchase).IsRequired();
        _ = builder.Property(e => e.Amount).HasPrecision(18, 8).IsRequired(false);
        _ = builder.Property(e => e.Quantity).HasPrecision(18, 8).IsRequired(false);
        _ = builder.Property(e => e.TotalTaxableAmount).HasPrecision(18, 8).IsRequired();
        _ = builder.Property(e => e.TotalVatAmount).HasPrecision(18, 8).IsRequired();
        _ = builder.Property(e => e.CurrencyCode).HasMaxLength(3).IsRequired().HasDefaultValueSql("('EUR')");
        _ = builder.Property(e => e.ExchangeRate).HasPrecision(18, 6).IsRequired();
        _ = builder.Property(e => e.IsSplitPayment).IsRequired();
        _ = builder.Property(e => e.SdiStatus).HasMaxLength(50).IsRequired(false);
        _ = builder.Property(e => e.InsertionDate).HasColumnType("datetime").IsRequired(false);
        _ = builder.Property(e => e.Notes).IsUnicode(false).IsRequired(false);
        _ = builder.Property(e => e.IsClosed).IsRequired(false);
        _ = builder.Property(e => e.VatId).IsRequired(false);
        _ = builder.Property(e => e.PaymentId).IsRequired(false);
        _ = builder.Property(e => e.ClosingDate).HasColumnType("datetime").IsRequired(false);
        _ = builder.Property(e => e.DeliveryNoteReference).HasMaxLength(50).IsUnicode(false).IsRequired(false);
        _ = builder.Property(e => e.TheirReference).HasColumnType("text").IsRequired(false);
        _ = builder.Property(e => e.OurReference).HasColumnType("text").IsRequired(false);
        _ = builder.Property(e => e.OrderReference).HasColumnType("text").IsRequired(false);

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Customer)
            .WithMany(p => p.Invoices)
            .HasForeignKey(e => e.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.InvoiceType)
            .WithMany(p => p.Invoices)
            .HasForeignKey(e => e.InvoiceTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Payment)
            .WithMany(p => p.Invoices)
            .HasForeignKey(e => e.PaymentId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Supplier)
            .WithMany(p => p.Invoices)
            .HasForeignKey(e => e.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Vat)
            .WithMany(p => p.Invoices)
            .HasForeignKey(e => e.VatId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
