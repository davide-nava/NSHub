// <copyright file="SettingConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Entities;
using NSHub.Application.Interfaces;

namespace NSHub.Infrastructure.Configurations;

/// <summary>
/// Entity configuration for <see cref="Setting"/>.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="SettingConfiguration"/> class.
/// </remarks>
/// <param name="requestContext">The request context providing tenant information.</param>
public class SettingConfiguration(IRequestContext requestContext) : BaseConfiguration<Setting>, IEntityTypeConfiguration<Setting>
{
    /// <inheritdoc/>
    public   void Configure(EntityTypeBuilder<Setting> builder) =>  base.Configure(builder, requestContext);
}
