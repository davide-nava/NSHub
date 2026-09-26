// <copyright file="TicketConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class TicketConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Ticket", "dbo");


        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.CustomerId).IsRequired(false);
        builder.Property(e => e.MachineId).IsRequired(false);
        builder.Property(e => e.TicketStatusTypeId).IsRequired();
        builder.Property(e => e.Title).HasMaxLength(256).IsRequired();
        builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        builder.Property(e => e.ClosingDate).HasColumnType("datetime").IsRequired();
        builder.Property(e => e.OpeningDate).HasColumnType("datetime").IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Customer)
            .WithMany(p => p.Tickets)
            .HasForeignKey(e => e.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Machine)
            .WithMany(p => p.Tickets)
            .HasForeignKey(e => e.MachineId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.TicketStatusType)
            .WithMany(p => p.Tickets)
            .HasForeignKey(e => e.TicketStatusTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.User)
            .WithMany(p => p.Tickets)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
