// <copyright file="SupplierConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class SupplierConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        _ = builder.ToTable("Supplier", "dbo");

        _ = builder.Property(e => e.Name).HasMaxLength(100).IsUnicode(false).IsRequired();
        _ = builder.Property(e => e.Search).IsUnicode(false).IsRequired(false);
        _ = builder.Property(e => e.Number).IsUnicode(false).IsRequired(false);
        _ = builder.Property(e => e.VatNumber).HasMaxLength(50).IsRequired(false);
        _ = builder.Property(e => e.TaxCode).HasMaxLength(50).IsRequired(false);
        _ = builder.Property(e => e.SdiCode).HasMaxLength(10).IsRequired(false);
        _ = builder.Property(e => e.PecEmail).HasMaxLength(255).IsRequired(false);
        _ = builder.Property(e => e.Email).HasMaxLength(255).IsRequired(false);
        _ = builder.Property(e => e.Phone).HasMaxLength(50).IsRequired(false);
        _ = builder.Property(e => e.AddressId).IsRequired(false);
        _ = builder.Property(e => e.PaymentId).IsRequired(false);
        _ = builder.Property(e => e.BankAccountId).IsRequired(false);
        _ = builder.Property(e => e.IsActive).IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.BankAccount)
            .WithMany(p => p.Suppliers)
            .HasForeignKey(e => e.BankAccountId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Payment)
            .WithMany(p => p.Suppliers)
            .HasForeignKey(e => e.PaymentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
