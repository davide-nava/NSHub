// <copyright file="TenantConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Persistence.Configurations.Identity;

/// <summary>
/// Entity configuration for <see cref="Tenant"/>.
/// </summary>
public class TenantConfiguration : AuditableEntityConfigurationBase<Tenant>, IEntityTypeConfiguration<Tenant>
{
    /// <inheritdoc/>
    public override void Configure(EntityTypeBuilder<Tenant> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        base.Configure(builder);

        _ = builder.ToTable("Tenant", "dbo");
        _ = builder.Property(e => e.Name).HasMaxLength(256).IsRequired();
        _ = builder.Property(e => e.Description).HasMaxLength(512);
    }
}
