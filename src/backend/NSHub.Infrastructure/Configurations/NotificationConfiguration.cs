// <copyright file="NotificationConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Entities;
using NSHub.Application.Interfaces;

namespace NSHub.Infrastructure.Configurations;

/// <summary>
/// Entity configuration for <see cref="Notification"/>.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="NotificationConfiguration"/> class.
/// </remarks>
/// <param name="requestContext">The request context providing tenant information.</param>
public class NotificationConfiguration(IRequestContext requestContext) : BaseConfiguration<Notification>, IEntityTypeConfiguration<Notification>
{
    /// <inheritdoc/>
    public   void Configure(EntityTypeBuilder<Notification> builder) =>  base.Configure(builder, requestContext);
}
