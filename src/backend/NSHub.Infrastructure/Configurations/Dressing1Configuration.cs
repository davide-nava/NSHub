// <copyright file="Dressing1Configuration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class Dressing1Configuration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<Dressing1>
{
    public void Configure(EntityTypeBuilder<Dressing1> builder)
    {
        builder.ToTable("Dressing1", "dbo");


        builder.Property(e => e.X).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.Y).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.Z).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.V).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.W).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.IsPos1).IsRequired();
        builder.Property(e => e.IsPos2).IsRequired();
        builder.Property(e => e.IsPos3).IsRequired();
        builder.Property(e => e.IsCycle1).IsRequired();
        builder.Property(e => e.IsCycle2).IsRequired();
        builder.Property(e => e.IsCycle3).IsRequired();
        builder.Property(e => e.IsOilOff).IsRequired();
        builder.Property(e => e.IsOilnt).IsRequired();
        builder.Property(e => e.IsOilOn).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
