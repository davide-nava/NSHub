// <copyright file="BaseConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Entities;
using NSHub.Application.Interfaces;

namespace NSHub.Infrastructure.Configurations;

/// <summary>
/// Base entity configuration for entities inheriting from <see cref="BaseEntity"/>.
/// </summary>
/// <typeparam name="T">The entity type.</typeparam>
public class BaseConfiguration<T>
    where T : BaseEntity
{
    /// <summary>
    /// Configures the entity mapping rules, query filters, and indexes.
    /// </summary>
    /// <param name="builder">The entity type builder.</param>
    /// <param name="requestContext">The request context providing tenant information.</param>
    /// <returns>The configured entity type builder.</returns>
    public  EntityTypeBuilder<T> Configure(EntityTypeBuilder<T> builder, IRequestContext requestContext )
    {
        ArgumentNullException.ThrowIfNull(builder);
        _ = builder.HasKey(r => r.Id);
        //builder.Property(r => r.Id).HasDefaultValueSql("(newid())");
        //builder.Property(e => e.DatetUpdate).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
        //builder.Property(e => e.DatetUpdate).HasDefaultValueSql("(getdate())").HasColumnType("datetime");

        _ = builder.ToTable(typeof(T).Name).HasQueryFilter(r => r.TenantId == null || r.TenantId == requestContext.TenantId).HasQueryFilter(r => !r.IsDeleted);

        _ = builder.HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");

        return builder;
    }
}
