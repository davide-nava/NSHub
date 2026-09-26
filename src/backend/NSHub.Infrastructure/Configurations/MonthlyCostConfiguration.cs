// <copyright file="MonthlyCostConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class MonthlyCostConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<MonthlyCost>
{
    public void Configure(EntityTypeBuilder<MonthlyCost> builder)
    {
        _ = builder.ToTable("MonthlyCost", "dbo");

        _ = builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        _ = builder.Property(e => e.Amount).HasPrecision(18, 8).IsRequired(false);
        _ = builder.Property(e => e.StartDate).HasColumnType("datetime").IsRequired(false);
        _ = builder.Property(e => e.EndDate).HasColumnType("datetime").IsRequired(false);

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
