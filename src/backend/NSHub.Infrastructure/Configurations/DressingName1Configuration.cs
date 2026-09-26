// <copyright file="DressingName1Configuration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class DressingName1Configuration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<DressingName1>
{
    public void Configure(EntityTypeBuilder<DressingName1> builder)
    {
        builder.ToTable("DressingName1", "dbo");


        builder.Property(e => e.LanguageId).IsRequired();
        builder.Property(e => e.Pos).IsRequired();
        builder.Property(e => e.Pos2).IsRequired();
        builder.Property(e => e.Pos3).IsRequired();
        builder.Property(e => e.Cycle1).IsRequired();
        builder.Property(e => e.Cycle2).IsRequired();
        builder.Property(e => e.Cycle3).IsRequired();
        builder.Property(e => e.OilOff).IsRequired();
        builder.Property(e => e.OilInt).IsRequired();
        builder.Property(e => e.OilOn).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
