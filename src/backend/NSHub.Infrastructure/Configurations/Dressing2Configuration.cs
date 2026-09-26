// <copyright file="Dressing2Configuration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class Dressing2Configuration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<Dressing2>
{
    public void Configure(EntityTypeBuilder<Dressing2> builder)
    {
        _ = builder.ToTable("Dressing2", "dbo");

        _ = builder.Property(e => e.Retraction).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.Chip).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.Chip2).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.Chip3).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.Ancl).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.AllInt).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.AllExt).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.WorkAdv).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.ExtAxVel).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.ExtAxVel2).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.ExtAxVel3).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.Removal).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.Removal2).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.Removal3).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.IsCycle2).IsRequired();
        _ = builder.Property(e => e.IsCycle3).IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
