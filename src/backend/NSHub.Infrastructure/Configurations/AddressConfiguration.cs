// <copyright file="AddressConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class AddressConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable(t => t.HasCheckConstraint("CK_Address_ValidityRange", "([ValidTo] IS NULL OR [ValidTo]>=[ValidFrom])"));
        builder.ToTable("Address", "dbo");


        builder.Property(e => e.PartyId).IsRequired();
        builder.Property(e => e.AddressTypeId).IsRequired();
        builder.Property(e => e.NationId).IsRequired(false);
        builder.Property(e => e.StreetName).HasMaxLength(200).IsRequired();
        builder.Property(e => e.BuildingNumber).HasMaxLength(30).IsRequired(false);
        builder.Property(e => e.AddressLine2).HasMaxLength(200).IsRequired(false);
        builder.Property(e => e.PostalCode).HasMaxLength(20).IsRequired();
        builder.Property(e => e.City).HasMaxLength(100).IsRequired();
        builder.Property(e => e.StateProvince).HasMaxLength(100).IsRequired(false);
        builder.Property(e => e.CountryCode).HasMaxLength(2).IsUnicode(false).IsRequired().HasDefaultValueSql("('CH')");
        builder.Property(e => e.CareOf).HasMaxLength(150).IsRequired(false);
        builder.Property(e => e.ValidFrom).HasColumnType("date").IsRequired();
        builder.Property(e => e.ValidTo).HasColumnType("date").IsRequired(false);
        builder.Property(e => e.IsDefault).IsRequired();
        builder.Property(e => e.Street).HasMaxLength(255).IsRequired(false);
        builder.Property(e => e.StreetNumber).HasMaxLength(50).IsRequired(false);
        builder.Property(e => e.ZipCode).HasMaxLength(20).IsRequired(false);
        builder.Property(e => e.Province).HasMaxLength(10).IsRequired(false);

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.AddressType)
            .WithMany(p => p.Addresses)
            .HasForeignKey(e => e.AddressTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Nation)
            .WithMany(p => p.Addresses)
            .HasForeignKey(e => e.NationId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Party)
            .WithMany(p => p.Addresses)
            .HasForeignKey(e => e.PartyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
