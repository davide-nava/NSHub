// <copyright file="Dressing1Configuration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class Dressing1Configuration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<Dressing1>
{
    public void Configure(EntityTypeBuilder<Dressing1> builder)
    {
        _ = builder.ToTable("Dressing1", "dbo");

        _ = builder.Property(e => e.X).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.Y).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.Z).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.V).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.W).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.IsPos1).IsRequired();
        _ = builder.Property(e => e.IsPos2).IsRequired();
        _ = builder.Property(e => e.IsPos3).IsRequired();
        _ = builder.Property(e => e.IsCycle1).IsRequired();
        _ = builder.Property(e => e.IsCycle2).IsRequired();
        _ = builder.Property(e => e.IsCycle3).IsRequired();
        _ = builder.Property(e => e.IsOilOff).IsRequired();
        _ = builder.Property(e => e.IsOilnt).IsRequired();
        _ = builder.Property(e => e.IsOilOn).IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
