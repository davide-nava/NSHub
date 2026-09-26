// <copyright file="BankAccountConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class BankAccountConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<BankAccount>
{
    public void Configure(EntityTypeBuilder<BankAccount> builder)
    {
        _ = builder.ToTable("BankAccount", "dbo");

        _ = builder.Property(e => e.BankId).IsRequired();
        _ = builder.Property(e => e.AccountHolder).HasMaxLength(255).IsRequired(false);
        _ = builder.Property(e => e.Iban).HasMaxLength(50).IsRequired();
        _ = builder.Property(e => e.Abi).HasMaxLength(10).IsRequired(false);
        _ = builder.Property(e => e.Cab).HasMaxLength(10).IsRequired(false);
        _ = builder.Property(e => e.Cin).HasMaxLength(5).IsRequired(false);
        _ = builder.Property(e => e.AccountNumber).HasMaxLength(50).IsRequired(false);
        _ = builder.Property(e => e.CurrencyCode).HasMaxLength(3).IsRequired().HasDefaultValueSql("('EUR')");
        _ = builder.Property(e => e.IsCompanyAccount).IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Bank)
            .WithMany(p => p.BankAccounts)
            .HasForeignKey(e => e.BankId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
