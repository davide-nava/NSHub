// <copyright file="MachineEventConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Persistence.Configurations.Production;

public class MachineEventConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<MachineEvent>
{
    public void Configure(EntityTypeBuilder<MachineEvent> builder)
    {
        _ = builder.ToTable("MachineEvent", "dbo");

        _ = builder.Property(e => e.Notes).IsUnicode(false).IsRequired(false);
        _ = builder.Property(e => e.MachineEventTypeId).IsRequired();
        _ = builder.Property(e => e.MachineId).IsRequired();
        _ = builder.Property(e => e.Date).HasColumnType("datetime").IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Machine)
            .WithMany()
            .HasForeignKey(e => e.MachineId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<MachineEventType>()
            .WithMany()
            .HasForeignKey(e => e.MachineEventTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
