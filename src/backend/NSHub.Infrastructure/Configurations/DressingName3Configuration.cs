// <copyright file="DressingName3Configuration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class DressingName3Configuration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<DressingName3>
{
    public void Configure(EntityTypeBuilder<DressingName3> builder)
    {
        builder.ToTable("DressingName3", "dbo");


        builder.Property(e => e.LanguageId).IsRequired();
        builder.Property(e => e.WorkSpiende).IsRequired();
        builder.Property(e => e.OptHfSpindle).IsRequired();
        builder.Property(e => e.OptNormSpendle).IsRequired();
        builder.Property(e => e.Direction).IsRequired();
        builder.Property(e => e.Hf).IsRequired();
        builder.Property(e => e.WheelHand).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
