// <copyright file="SettingConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Persistence.Configurations.Identity;

/// <summary>
/// Entity configuration for <see cref="Setting"/>.
/// </summary>
/// <param name="requestContext">The request context providing tenant information.</param>
public class SettingConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<Setting>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Setting> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        _ = builder.ToTable("Setting", "dbo");
        _ = builder.Property(e => e.Key).HasMaxLength(256).IsRequired();
        _ = builder.Property(e => e.Value).HasMaxLength(2048);
    }
}
