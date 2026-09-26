// <copyright file="TicketConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class TicketConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        _ = builder.ToTable("Ticket", "dbo");

        _ = builder.Property(e => e.UserId).IsRequired();
        _ = builder.Property(e => e.CustomerId).IsRequired(false);
        _ = builder.Property(e => e.MachineId).IsRequired(false);
        _ = builder.Property(e => e.TicketStatusTypeId).IsRequired();
        _ = builder.Property(e => e.Title).HasMaxLength(256).IsRequired();
        _ = builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        _ = builder.Property(e => e.ClosingDate).HasColumnType("datetime").IsRequired();
        _ = builder.Property(e => e.OpeningDate).HasColumnType("datetime").IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Customer)
            .WithMany(p => p.Tickets)
            .HasForeignKey(e => e.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Machine)
            .WithMany(p => p.Tickets)
            .HasForeignKey(e => e.MachineId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.TicketStatusType)
            .WithMany(p => p.Tickets)
            .HasForeignKey(e => e.TicketStatusTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.User)
            .WithMany(p => p.Tickets)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
