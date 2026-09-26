// <copyright file="WarehouseConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class WarehouseConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        _ = builder.ToTable("Warehouse", "dbo");

        _ = builder.Property(e => e.PersonId).IsRequired();
        _ = builder.Property(e => e.AddressId).IsRequired();
        _ = builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        _ = builder.Property(e => e.IsExternal).IsRequired(false);
        _ = builder.Property(e => e.OpeningTime).HasMaxLength(50).IsRequired(false);
        _ = builder.Property(e => e.ClosingTime).HasMaxLength(50).IsRequired(false);
        _ = builder.Property(e => e.Name).HasMaxLength(255).IsRequired(false);
        _ = builder.Property(e => e.Notes).IsRequired(false);

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Address)
            .WithMany(p => p.Warehouses)
            .HasForeignKey(e => e.AddressId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Person)
            .WithMany(p => p.Warehouses)
            .HasForeignKey(e => e.PersonId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
