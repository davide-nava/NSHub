// <copyright file="CashBookConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class CashBookConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<CashBook>
{
    public void Configure(EntityTypeBuilder<CashBook> builder)
    {
        _ = builder.ToTable("CashBook", "dbo");

        _ = builder.Property(e => e.Date).HasColumnType("datetime").IsRequired(false);
        _ = builder.Property(e => e.Balance).HasPrecision(18, 8).IsRequired(false);
        _ = builder.Property(e => e.Notes).IsUnicode(false).IsRequired(false);
        _ = builder.Property(e => e.Credit).HasPrecision(18, 8).IsRequired(false);
        _ = builder.Property(e => e.Debit).HasPrecision(18, 8).IsRequired(false);

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
