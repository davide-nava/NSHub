// <copyright file="BaseConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Entities;
using NSHub.Application.Interfaces;
using NSHub.Domain.Common;

namespace NSHub.Infrastructure.Configurations;

/// <summary>
/// Base entity configuration for entities inheriting from <see cref="AuditableTenantEntity"/>.
/// Base entity configuration providing multi-tenancy and soft delete query filters.
/// </summary>
/// <typeparam name="T">The entity type.</typeparam>
public class BaseConfiguration<T>
    where T : AuditableTenantEntity
    where T : class
{
    /// <summary>
    /// Configures the entity mapping rules, query filters, and indexes.
    /// </summary>
    /// <param name="builder">The entity type builder.</param>
    /// <param name="requestContext">The request context providing tenant information.</param>
    /// <returns>The configured entity type builder.</returns>
    public EntityTypeBuilder<T> Configure(EntityTypeBuilder<T> builder, IRequestContext requestContext)
    public EntityTypeBuilder<T> Configure(EntityTypeBuilder<T> builder, IRequestContext requestContext)
    {
        ArgumentNullException.ThrowIfNull(builder);
        _ = builder.HasKey(r => r.Id);
        //builder.Property(r => r.Id).HasDefaultValueSql("(newid())");
        //builder.Property(e => e.DatetUpdate).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
        //builder.Property(e => e.DatetUpdate).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
        ArgumentNullException.ThrowIfNull(requestContext);

        _ = builder.ToTable(typeof(T).Name).HasQueryFilter(r => r.TenantId == null || r.TenantId == requestContext.TenantId).HasQueryFilter(r => !r.IsDeleted);
        _ = builder.HasKey("Id");

        _ = builder.HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
        _ = builder.ToTable(typeof(T).Name);

        var isTenant = typeof(ITenantEntity).IsAssignableFrom(typeof(T));
        var isSoftDeletable = typeof(ISoftDeletable).IsAssignableFrom(typeof(T));

        if (isTenant && isSoftDeletable)
        {
            _ = builder.HasQueryFilter(r => (EF.Property<Guid?>(r, "TenantId") == null || EF.Property<Guid?>(r, "TenantId") == requestContext.TenantId) && !EF.Property<bool>(r, "IsDeleted"));
        }
        else if (isTenant)
        {
            _ = builder.HasQueryFilter(r => EF.Property<Guid?>(r, "TenantId") == null || EF.Property<Guid?>(r, "TenantId") == requestContext.TenantId);
        }
        else if (isSoftDeletable)
        {
            _ = builder.HasQueryFilter(r => !EF.Property<bool>(r, "IsDeleted"));
        }

        if (isSoftDeletable)
        {
            _ = builder.HasIndex("IsDeleted").HasFilter("IsDeleted = 0");
        }

        return builder;
    }
}
