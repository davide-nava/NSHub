// <copyright file="LanguageConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Common.Interfaces;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

/// <summary>
/// Entity configuration for <see cref="Language"/>.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="LanguageConfiguration"/> class.
/// </remarks>
/// <param name="requestContext">The request context providing tenant information.</param>
public class LanguageConfiguration(IRequestContext requestContext) : BaseConfiguration<Language>, IEntityTypeConfiguration<Language>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Language> builder) => _ = Configure(builder, requestContext);
}
