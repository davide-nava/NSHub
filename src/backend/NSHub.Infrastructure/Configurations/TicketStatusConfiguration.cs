// <copyright file="TicketStatusConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class TicketStatusConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<TicketStatus>
{
    public void Configure(EntityTypeBuilder<TicketStatus> builder)
    {
        _ = builder.ToTable("TicketStatus", "dbo");

        _ = builder.Property(e => e.TicketId).IsRequired();
        _ = builder.Property(e => e.MachineId).IsRequired();
        _ = builder.Property(e => e.UserId).IsRequired();
        _ = builder.Property(e => e.TicketStatusTypeId).IsRequired();
        _ = builder.Property(e => e.Date).HasColumnType("datetime").IsRequired();
        _ = builder.Property(e => e.Notes).IsRequired(false);

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Machine)
            .WithMany(p => p.TicketStatuses)
            .HasForeignKey(e => e.MachineId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Ticket)
            .WithMany(p => p.TicketStatuses)
            .HasForeignKey(e => e.TicketId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.TicketStatusType)
            .WithMany(p => p.TicketStatuses)
            .HasForeignKey(e => e.TicketStatusTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.User)
            .WithMany(p => p.TicketStatuses)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
