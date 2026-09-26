// <copyright file="DressingName3Configuration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class DressingName3Configuration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<DressingName3>
{
    public void Configure(EntityTypeBuilder<DressingName3> builder)
    {
        _ = builder.ToTable("DressingName3", "dbo");

        _ = builder.Property(e => e.LanguageId).IsRequired();
        _ = builder.Property(e => e.WorkSpiende).IsRequired();
        _ = builder.Property(e => e.OptHfSpindle).IsRequired();
        _ = builder.Property(e => e.OptNormSpendle).IsRequired();
        _ = builder.Property(e => e.Direction).IsRequired();
        _ = builder.Property(e => e.Hf).IsRequired();
        _ = builder.Property(e => e.WheelHand).IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
