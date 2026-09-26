// <copyright file="Dressing3Configuration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class Dressing3Configuration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<Dressing3>
{
    public void Configure(EntityTypeBuilder<Dressing3> builder)
    {
        builder.ToTable("Dressing3", "dbo");


        builder.Property(e => e.IsHfSpindle).IsRequired();
        builder.Property(e => e.IsNormalSpindle).IsRequired();
        builder.Property(e => e.WorkSpeed).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.HfSpeed).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.NormalSpeed).HasPrecision(18, 4).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
