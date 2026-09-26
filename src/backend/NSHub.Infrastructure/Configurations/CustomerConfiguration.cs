// <copyright file="CustomerConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class CustomerConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        _ = builder.ToTable("Customer", "dbo");

        _ = builder.Property(e => e.Code).HasMaxLength(256).IsRequired();
        _ = builder.Property(e => e.CompanyName).HasMaxLength(255).IsRequired();
        _ = builder.Property(e => e.VatNumber).HasMaxLength(50).IsRequired(false);
        _ = builder.Property(e => e.TaxCode).HasMaxLength(50).IsRequired(false);
        _ = builder.Property(e => e.SdiCode).HasMaxLength(10).IsRequired(false);
        _ = builder.Property(e => e.PecEmail).HasMaxLength(255).IsRequired(false);
        _ = builder.Property(e => e.Email).HasMaxLength(255).IsRequired(false);
        _ = builder.Property(e => e.Phone).HasMaxLength(50).IsRequired(false);
        _ = builder.Property(e => e.Website).HasMaxLength(255).IsRequired(false);
        _ = builder.Property(e => e.LegalAddressId).IsRequired(false);
        _ = builder.Property(e => e.ShippingAddressId).IsRequired(false);
        _ = builder.Property(e => e.PaymentId).IsRequired(false);
        _ = builder.Property(e => e.VatId).IsRequired(false);
        _ = builder.Property(e => e.BankAccountId).IsRequired(false);
        _ = builder.Property(e => e.CreditLimit).HasPrecision(18, 8).IsRequired(false);
        _ = builder.Property(e => e.IsActive).IsRequired();
        _ = builder.Property(e => e.Notes).IsRequired(false);

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.BankAccount)
            .WithMany(p => p.Customers)
            .HasForeignKey(e => e.BankAccountId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Payment)
            .WithMany(p => p.Customers)
            .HasForeignKey(e => e.PaymentId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Vat)
            .WithMany(p => p.Customers)
            .HasForeignKey(e => e.VatId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
