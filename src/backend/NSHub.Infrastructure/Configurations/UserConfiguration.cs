// <copyright file="UserConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Entities;
using NSHub.Application.Interfaces;

namespace NSHub.Infrastructure.Configurations;

/// <summary>
/// Entity configuration for <see cref="User"/>.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UserConfiguration"/> class.
/// </remarks>
/// <param name="requestContext">The request context providing tenant information.</param>
public class UserConfiguration(IRequestContext requestContext) : BaseConfiguration<User>, IEntityTypeConfiguration<User>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder = base.Configure(builder, requestContext);


        _ = builder.ComplexProperty(b => b.Configuration, b => b.ToJson());
    }
}
