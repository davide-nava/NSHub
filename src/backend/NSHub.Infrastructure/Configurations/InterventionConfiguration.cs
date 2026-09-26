// <copyright file="InterventionConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class InterventionConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<Intervention>
{
    public void Configure(EntityTypeBuilder<Intervention> builder)
    {
        _ = builder.ToTable("Intervention", "dbo");

        _ = builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        _ = builder.Property(e => e.EndDate).HasColumnType("datetime").IsRequired(false);
        _ = builder.Property(e => e.StartDate).HasColumnType("datetime").IsRequired();
        _ = builder.Property(e => e.Notes).IsRequired(false);
        _ = builder.Property(e => e.Operator).IsRequired();
        _ = builder.Property(e => e.Title).HasMaxLength(256).IsRequired();
        _ = builder.Property(e => e.MachineId).IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Machine)
            .WithMany(p => p.Interventions)
            .HasForeignKey(e => e.MachineId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
