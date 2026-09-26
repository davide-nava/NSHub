// <copyright file="TicketShipmentConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class TicketShipmentConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<TicketShipment>
{
    public void Configure(EntityTypeBuilder<TicketShipment> builder)
    {
        _ = builder.ToTable("TicketShipment", "dbo");

        _ = builder.Property(e => e.Date).HasColumnType("datetime").IsRequired();
        _ = builder.Property(e => e.ShipmentId).IsRequired();
        _ = builder.Property(e => e.TicketId).IsRequired();
        _ = builder.Property(e => e.Notes).IsUnicode(false).IsRequired(false);

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Shipment)
            .WithMany(p => p.TicketShipments)
            .HasForeignKey(e => e.ShipmentId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Ticket)
            .WithMany(p => p.TicketShipments)
            .HasForeignKey(e => e.TicketId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
