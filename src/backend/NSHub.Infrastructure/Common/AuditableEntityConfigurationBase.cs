// <copyright file="AuditableEntityConfigurationBase.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Common;

namespace NSHub.Infrastructure.Common;

public abstract class AuditableEntityConfigurationBase<TEntity>
    : IEntityTypeConfiguration<TEntity>
    where TEntity : AuditableEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        _ = builder.HasKey(e => e.Id);

        _ = builder.Property(e => e.Id)
            .IsRequired();

        _ = builder.Property(e => e.DateInsert)
            .HasColumnType("datetime")
            .IsRequired();

        _ = builder.Property(e => e.DateUpdate)
            .HasColumnType("datetime")
            .IsRequired();

        _ = builder.Property(e => e.DateDelete)
            .HasColumnType("datetime")
            .IsRequired(false);

        _ = builder.Property(e => e.UserInsertId)
            .IsRequired(false);

        _ = builder.Property(e => e.UserUpdateId)
            .IsRequired(false);

        _ = builder.Property(e => e.UserDeleteId)
            .IsRequired(false);

        _ = builder.Property(e => e.RowVersion)
            .IsRowVersion();

        _ = builder.HasQueryFilter(e =>
            EF.Property<DateTime?>(e, nameof(ISoftDeletable.DateDelete)) == null);

        _ = builder.HasIndex(nameof(ISoftDeletable.DateDelete))
            .HasFilter($"{nameof(ISoftDeletable.DateDelete)} IS NULL");
    }
}
