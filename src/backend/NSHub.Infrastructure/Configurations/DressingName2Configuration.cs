// <copyright file="DressingName2Configuration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class DressingName2Configuration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<DressingName2>
{
    public void Configure(EntityTypeBuilder<DressingName2> builder)
    {
        _ = builder.ToTable("DressingName2", "dbo");

        _ = builder.Property(e => e.LanguageId).IsRequired();
        _ = builder.Property(e => e.Retreat).IsRequired();
        _ = builder.Property(e => e.Chip).IsRequired();
        _ = builder.Property(e => e.Ancl).IsRequired();
        _ = builder.Property(e => e.AllInt).IsRequired();
        _ = builder.Property(e => e.AllExt).IsRequired();
        _ = builder.Property(e => e.OutVel).IsRequired();
        _ = builder.Property(e => e.Vel).IsRequired();
        _ = builder.Property(e => e.Removal).IsRequired();
        _ = builder.Property(e => e.Cycle2).IsRequired();
        _ = builder.Property(e => e.Cycle3).IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
