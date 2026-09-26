// <copyright file="AddressConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class AddressConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        _ = builder.ToTable(t => t.HasCheckConstraint("CK_Address_ValidityRange", "([ValidTo] IS NULL OR [ValidTo]>=[ValidFrom])"));
        _ = builder.ToTable("Address", "dbo");

        _ = builder.Property(e => e.PartyId).IsRequired();
        _ = builder.Property(e => e.AddressTypeId).IsRequired();
        _ = builder.Property(e => e.NationId).IsRequired(false);
        _ = builder.Property(e => e.StreetName).HasMaxLength(200).IsRequired();
        _ = builder.Property(e => e.BuildingNumber).HasMaxLength(30).IsRequired(false);
        _ = builder.Property(e => e.AddressLine2).HasMaxLength(200).IsRequired(false);
        _ = builder.Property(e => e.PostalCode).HasMaxLength(20).IsRequired();
        _ = builder.Property(e => e.City).HasMaxLength(100).IsRequired();
        _ = builder.Property(e => e.StateProvince).HasMaxLength(100).IsRequired(false);
        _ = builder.Property(e => e.CountryCode).HasMaxLength(2).IsUnicode(false).IsRequired().HasDefaultValueSql("('CH')");
        _ = builder.Property(e => e.CareOf).HasMaxLength(150).IsRequired(false);
        _ = builder.Property(e => e.ValidFrom).HasColumnType("date").IsRequired();
        _ = builder.Property(e => e.ValidTo).HasColumnType("date").IsRequired(false);
        _ = builder.Property(e => e.IsDefault).IsRequired();
        _ = builder.Property(e => e.Street).HasMaxLength(255).IsRequired(false);
        _ = builder.Property(e => e.StreetNumber).HasMaxLength(50).IsRequired(false);
        _ = builder.Property(e => e.ZipCode).HasMaxLength(20).IsRequired(false);
        _ = builder.Property(e => e.Province).HasMaxLength(10).IsRequired(false);

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.AddressType)
            .WithMany(p => p.Addresses)
            .HasForeignKey(e => e.AddressTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Nation)
            .WithMany(p => p.Addresses)
            .HasForeignKey(e => e.NationId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Party)
            .WithMany(p => p.Addresses)
            .HasForeignKey(e => e.PartyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
