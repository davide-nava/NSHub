// <copyright file="MachineEventConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class MachineEventConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<MachineEvent>
{
    public void Configure(EntityTypeBuilder<MachineEvent> builder)
    {
        builder.ToTable("MachineEvent", "dbo");


        builder.Property(e => e.Notes).IsUnicode(false).IsRequired(false);
        builder.Property(e => e.MachineEventTypeId).IsRequired();
        builder.Property(e => e.MachineId).IsRequired();
        builder.Property(e => e.Date).HasColumnType("datetime").IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Machine)
            .WithMany(p => p.MachineEvents)
            .HasForeignKey(e => e.MachineId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.MachineEventType)
            .WithMany(p => p.MachineEvents)
            .HasForeignKey(e => e.MachineEventTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
