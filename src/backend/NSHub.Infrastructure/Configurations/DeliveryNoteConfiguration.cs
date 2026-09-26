// <copyright file="DeliveryNoteConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class DeliveryNoteConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<DeliveryNote>
{
    public void Configure(EntityTypeBuilder<DeliveryNote> builder)
    {
        _ = builder.ToTable("DeliveryNote", "dbo");

        _ = builder.Property(e => e.DeliveryNoteNumber).HasMaxLength(50).IsRequired();
        _ = builder.Property(e => e.Year).IsRequired();
        _ = builder.Property(e => e.Date).HasColumnType("datetime").IsRequired(false);
        _ = builder.Property(e => e.OrderId).IsRequired(false);
        _ = builder.Property(e => e.InvoiceCustomerId).IsRequired(false);
        _ = builder.Property(e => e.GoodsCustomerId).IsRequired(false);
        _ = builder.Property(e => e.ShippingAddressId).IsRequired(false);
        _ = builder.Property(e => e.TransportReasonCode).HasMaxLength(50).IsRequired();
        _ = builder.Property(e => e.GoodsAppearanceCode).HasMaxLength(50).IsRequired();
        _ = builder.Property(e => e.TransportCareCode).HasMaxLength(50).IsRequired();
        _ = builder.Property(e => e.CarriageCode).HasMaxLength(50).IsRequired();
        _ = builder.Property(e => e.Notes).IsRequired(false);
        _ = builder.Property(e => e.PackageCount).HasPrecision(18, 8).IsRequired(false);
        _ = builder.Property(e => e.Weight).HasPrecision(18, 8).IsRequired(false);
        _ = builder.Property(e => e.InsertionDate).HasColumnType("datetime").IsRequired(false);
        _ = builder.Property(e => e.Carriers).IsRequired(false);
        _ = builder.Property(e => e.IsClosed).IsRequired(false);
        _ = builder.Property(e => e.OurReference).HasColumnType("text").IsRequired(false);
        _ = builder.Property(e => e.OrderReference).HasColumnType("text").IsRequired(false);
        _ = builder.Property(e => e.TheirReference).HasColumnType("text").IsRequired(false);

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.GoodsCustomer)
            .WithMany(p => p.GoodsDeliveryNotes)
            .HasForeignKey(e => e.GoodsCustomerId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.InvoiceCustomer)
            .WithMany(p => p.InvoiceDeliveryNotes)
            .HasForeignKey(e => e.InvoiceCustomerId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Order)
            .WithMany(p => p.DeliveryNotes)
            .HasForeignKey(e => e.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
