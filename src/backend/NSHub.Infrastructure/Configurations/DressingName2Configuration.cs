// <copyright file="DressingName2Configuration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class DressingName2Configuration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<DressingName2>
{
    public void Configure(EntityTypeBuilder<DressingName2> builder)
    {
        builder.ToTable("DressingName2", "dbo");


        builder.Property(e => e.LanguageId).IsRequired();
        builder.Property(e => e.Retreat).IsRequired();
        builder.Property(e => e.Chip).IsRequired();
        builder.Property(e => e.Ancl).IsRequired();
        builder.Property(e => e.AllInt).IsRequired();
        builder.Property(e => e.AllExt).IsRequired();
        builder.Property(e => e.OutVel).IsRequired();
        builder.Property(e => e.Vel).IsRequired();
        builder.Property(e => e.Removal).IsRequired();
        builder.Property(e => e.Cycle2).IsRequired();
        builder.Property(e => e.Cycle3).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
