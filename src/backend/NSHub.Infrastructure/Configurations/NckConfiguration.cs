// <copyright file="NckConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class NckConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<Nck>
{
    public void Configure(EntityTypeBuilder<Nck> builder)
    {
        builder.ToTable("Nck", "dbo");


        builder.Property(e => e.Config).IsRequired();
        builder.Property(e => e.State).IsRequired();
        builder.Property(e => e.Affair).IsRequired();
        builder.Property(e => e.StateEnh).IsRequired();
        builder.Property(e => e.FbName).IsRequired();
        builder.Property(e => e.Version).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
