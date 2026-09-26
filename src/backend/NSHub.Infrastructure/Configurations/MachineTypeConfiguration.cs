// <copyright file="MachineTypeConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class MachineTypeConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<MachineType>
{
    public void Configure(EntityTypeBuilder<MachineType> builder)
    {
        _ = builder.ToTable("MachineType", "dbo");

        _ = builder.Property(e => e.Number).HasMaxLength(255).IsRequired();
        _ = builder.Property(e => e.Image).HasColumnType("text").IsRequired(false);
        _ = builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        _ = builder.Property(e => e.Date).HasColumnType("datetime").IsRequired();
        _ = builder.Property(e => e.Axes).IsRequired();
        _ = builder.Property(e => e.Spindles).IsRequired();
        _ = builder.Property(e => e.Cnc).HasMaxLength(255).IsRequired(false);
        _ = builder.Property(e => e.Specialty).IsRequired(false);
        _ = builder.Property(e => e.Details).IsRequired(false);

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
