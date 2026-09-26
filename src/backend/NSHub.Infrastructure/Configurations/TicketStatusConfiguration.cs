// <copyright file="TicketStatusConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class TicketStatusConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<TicketStatus>
{
    public void Configure(EntityTypeBuilder<TicketStatus> builder)
    {
        builder.ToTable("TicketStatus", "dbo");


        builder.Property(e => e.TicketId).IsRequired();
        builder.Property(e => e.MachineId).IsRequired();
        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.TicketStatusTypeId).IsRequired();
        builder.Property(e => e.Date).HasColumnType("datetime").IsRequired();
        builder.Property(e => e.Notes).IsRequired(false);

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Machine)
            .WithMany(p => p.TicketStatuses)
            .HasForeignKey(e => e.MachineId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Ticket)
            .WithMany(p => p.TicketStatuses)
            .HasForeignKey(e => e.TicketId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.TicketStatusType)
            .WithMany(p => p.TicketStatuses)
            .HasForeignKey(e => e.TicketStatusTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.User)
            .WithMany(p => p.TicketStatuses)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
