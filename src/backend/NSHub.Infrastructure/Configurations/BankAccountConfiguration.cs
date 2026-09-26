// <copyright file="BankAccountConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class BankAccountConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<BankAccount>
{
    public void Configure(EntityTypeBuilder<BankAccount> builder)
    {
        builder.ToTable("BankAccount", "dbo");


        builder.Property(e => e.BankId).IsRequired();
        builder.Property(e => e.AccountHolder).HasMaxLength(255).IsRequired(false);
        builder.Property(e => e.Iban).HasMaxLength(50).IsRequired();
        builder.Property(e => e.Abi).HasMaxLength(10).IsRequired(false);
        builder.Property(e => e.Cab).HasMaxLength(10).IsRequired(false);
        builder.Property(e => e.Cin).HasMaxLength(5).IsRequired(false);
        builder.Property(e => e.AccountNumber).HasMaxLength(50).IsRequired(false);
        builder.Property(e => e.CurrencyCode).HasMaxLength(3).IsRequired().HasDefaultValueSql("('EUR')");
        builder.Property(e => e.IsCompanyAccount).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Bank)
            .WithMany(p => p.BankAccounts)
            .HasForeignKey(e => e.BankId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
