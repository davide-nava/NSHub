// <copyright file="MachineTypeConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class MachineTypeConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<MachineType>
{
    public void Configure(EntityTypeBuilder<MachineType> builder)
    {
        builder.ToTable("MachineType", "dbo");


        builder.Property(e => e.Number).HasMaxLength(255).IsRequired();
        builder.Property(e => e.Image).HasColumnType("text").IsRequired(false);
        builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        builder.Property(e => e.Date).HasColumnType("datetime").IsRequired();
        builder.Property(e => e.Axes).IsRequired();
        builder.Property(e => e.Spindles).IsRequired();
        builder.Property(e => e.Cnc).HasMaxLength(255).IsRequired(false);
        builder.Property(e => e.Specialty).IsRequired(false);
        builder.Property(e => e.Details).IsRequired(false);

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
