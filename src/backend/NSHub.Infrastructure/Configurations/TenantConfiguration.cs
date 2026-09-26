// <copyright file="TenantConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Common.Interfaces;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

/// <summary>
/// Entity configuration for <see cref="Tenant"/>.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="TenantConfiguration"/> class.
/// </remarks>
/// <param name="requestContext">The request context providing tenant information.</param>
public class TenantConfiguration(IRequestContext requestContext) : BaseConfiguration<Tenant>, IEntityTypeConfiguration<Tenant>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Tenant> builder) => _ = Configure(builder, requestContext);
}
