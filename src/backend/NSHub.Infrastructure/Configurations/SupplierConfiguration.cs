// <copyright file="SupplierConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class SupplierConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("Supplier", "dbo");


        builder.Property(e => e.Name).HasMaxLength(100).IsUnicode(false).IsRequired();
        builder.Property(e => e.Search).IsUnicode(false).IsRequired(false);
        builder.Property(e => e.Number).IsUnicode(false).IsRequired(false);
        builder.Property(e => e.VatNumber).HasMaxLength(50).IsRequired(false);
        builder.Property(e => e.TaxCode).HasMaxLength(50).IsRequired(false);
        builder.Property(e => e.SdiCode).HasMaxLength(10).IsRequired(false);
        builder.Property(e => e.PecEmail).HasMaxLength(255).IsRequired(false);
        builder.Property(e => e.Email).HasMaxLength(255).IsRequired(false);
        builder.Property(e => e.Phone).HasMaxLength(50).IsRequired(false);
        builder.Property(e => e.AddressId).IsRequired(false);
        builder.Property(e => e.PaymentId).IsRequired(false);
        builder.Property(e => e.BankAccountId).IsRequired(false);
        builder.Property(e => e.IsActive).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.BankAccount)
            .WithMany(p => p.Suppliers)
            .HasForeignKey(e => e.BankAccountId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Payment)
            .WithMany(p => p.Suppliers)
            .HasForeignKey(e => e.PaymentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
