// <copyright file="MonthlyCostConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class MonthlyCostConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<MonthlyCost>
{
    public void Configure(EntityTypeBuilder<MonthlyCost> builder)
    {
        builder.ToTable("MonthlyCost", "dbo");


        builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        builder.Property(e => e.Amount).HasPrecision(18, 8).IsRequired(false);
        builder.Property(e => e.StartDate).HasColumnType("datetime").IsRequired(false);
        builder.Property(e => e.EndDate).HasColumnType("datetime").IsRequired(false);

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
