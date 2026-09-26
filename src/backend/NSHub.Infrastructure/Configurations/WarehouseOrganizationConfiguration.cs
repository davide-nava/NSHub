// <copyright file="WarehouseOrganizationConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class WarehouseOrganizationConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<WarehouseOrganization>
{
    public void Configure(EntityTypeBuilder<WarehouseOrganization> builder)
    {
        _ = builder.ToTable("WarehouseOrganization", "dbo");

        _ = builder.Property(e => e.WarehouseId).IsRequired();
        _ = builder.Property(e => e.OrganizationId).IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Organization)
            .WithMany(p => p.WarehouseOrganizations)
            .HasForeignKey(e => e.OrganizationId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Warehouse)
            .WithMany(p => p.WarehouseOrganizations)
            .HasForeignKey(e => e.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
