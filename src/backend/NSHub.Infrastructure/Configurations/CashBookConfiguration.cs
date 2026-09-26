// <copyright file="CashBookConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class CashBookConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<CashBook>
{
    public void Configure(EntityTypeBuilder<CashBook> builder)
    {
        builder.ToTable("CashBook", "dbo");


        builder.Property(e => e.Date).HasColumnType("datetime").IsRequired(false);
        builder.Property(e => e.Balance).HasPrecision(18, 8).IsRequired(false);
        builder.Property(e => e.Notes).IsUnicode(false).IsRequired(false);
        builder.Property(e => e.Credit).HasPrecision(18, 8).IsRequired(false);
        builder.Property(e => e.Debit).HasPrecision(18, 8).IsRequired(false);

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
