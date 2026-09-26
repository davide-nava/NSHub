// <copyright file="Dressing3Configuration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class Dressing3Configuration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<Dressing3>
{
    public void Configure(EntityTypeBuilder<Dressing3> builder)
    {
        _ = builder.ToTable("Dressing3", "dbo");

        _ = builder.Property(e => e.IsHfSpindle).IsRequired();
        _ = builder.Property(e => e.IsNormalSpindle).IsRequired();
        _ = builder.Property(e => e.WorkSpeed).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.HfSpeed).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.NormalSpeed).HasPrecision(18, 4).IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
