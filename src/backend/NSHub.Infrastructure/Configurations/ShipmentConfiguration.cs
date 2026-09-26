// <copyright file="ShipmentConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class ShipmentConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {
        _ = builder.ToTable("Shipment", "dbo");

        _ = builder.Property(e => e.Notes).IsUnicode(false).IsRequired(false);
        _ = builder.Property(e => e.CourierId).IsRequired();
        _ = builder.Property(e => e.UserId).IsRequired();
        _ = builder.Property(e => e.MachineId).IsRequired(false);
        _ = builder.Property(e => e.CustomerId).IsRequired();
        _ = builder.Property(e => e.Date).HasColumnType("datetime").IsRequired();
        _ = builder.Property(e => e.ArrivalDate).HasColumnType("datetime").IsRequired();
        _ = builder.Property(e => e.SendDate).HasColumnType("datetime").IsRequired();
        _ = builder.Property(e => e.IsClosed).IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Courier)
            .WithMany(p => p.Shipments)
            .HasForeignKey(e => e.CourierId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Customer)
            .WithMany(p => p.Shipments)
            .HasForeignKey(e => e.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Machine)
            .WithMany(p => p.Shipments)
            .HasForeignKey(e => e.MachineId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.User)
            .WithMany(p => p.Shipments)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
