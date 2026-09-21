// <copyright file="BaseConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Entities;
using NSHub.Application.Interfaces;

namespace NSHub.Infrastructure.Configurations;

public class BaseConfiguration<T>
    where T : BaseEntity
{
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
