// <copyright file="WarehouseConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class WarehouseConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        builder.ToTable("Warehouse", "dbo");


        builder.Property(e => e.PersonId).IsRequired();
        builder.Property(e => e.AddressId).IsRequired();
        builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        builder.Property(e => e.IsExternal).IsRequired(false);
        builder.Property(e => e.OpeningTime).HasMaxLength(50).IsRequired(false);
        builder.Property(e => e.ClosingTime).HasMaxLength(50).IsRequired(false);
        builder.Property(e => e.Name).HasMaxLength(255).IsRequired(false);
        builder.Property(e => e.Notes).IsRequired(false);

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Address)
            .WithMany(p => p.Warehouses)
            .HasForeignKey(e => e.AddressId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Person)
            .WithMany(p => p.Warehouses)
            .HasForeignKey(e => e.PersonId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
