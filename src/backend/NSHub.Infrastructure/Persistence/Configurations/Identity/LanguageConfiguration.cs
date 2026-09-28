// <copyright file="LanguageConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Persistence.Configurations.Identity;

/// <summary>
/// Entity configuration for <see cref="Language"/>.
/// </summary>
/// <param name="requestContext">The request context providing tenant information.</param>
public class LanguageConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<Language>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        _ = builder.ToTable("Language", "dbo");
        _ = builder.Property(e => e.Code).HasMaxLength(10).IsRequired();
        _ = builder.Property(e => e.Description).HasMaxLength(255).IsRequired();
    }
}
