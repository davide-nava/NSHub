// <copyright file="TicketShipmentConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class TicketShipmentConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<TicketShipment>
{
    public void Configure(EntityTypeBuilder<TicketShipment> builder)
    {
        builder.ToTable("TicketShipment", "dbo");


        builder.Property(e => e.Date).HasColumnType("datetime").IsRequired();
        builder.Property(e => e.ShipmentId).IsRequired();
        builder.Property(e => e.TicketId).IsRequired();
        builder.Property(e => e.Notes).IsUnicode(false).IsRequired(false);

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Shipment)
            .WithMany(p => p.TicketShipments)
            .HasForeignKey(e => e.ShipmentId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Ticket)
            .WithMany(p => p.TicketShipments)
            .HasForeignKey(e => e.TicketId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
