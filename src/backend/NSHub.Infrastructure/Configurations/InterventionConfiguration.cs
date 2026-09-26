// <copyright file="InterventionConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class InterventionConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<Intervention>
{
    public void Configure(EntityTypeBuilder<Intervention> builder)
    {
        builder.ToTable("Intervention", "dbo");


        builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        builder.Property(e => e.EndDate).HasColumnType("datetime").IsRequired(false);
        builder.Property(e => e.StartDate).HasColumnType("datetime").IsRequired();
        builder.Property(e => e.Notes).IsRequired(false);
        builder.Property(e => e.Operator).IsRequired();
        builder.Property(e => e.Title).HasMaxLength(256).IsRequired();
        builder.Property(e => e.MachineId).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Machine)
            .WithMany(p => p.Interventions)
            .HasForeignKey(e => e.MachineId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
