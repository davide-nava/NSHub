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

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .IsRequired();

        builder.Property(e => e.DateInsert)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(e => e.DateUpdate)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(e => e.DateDelete)
            .HasColumnType("datetime")
            .IsRequired(false);

        builder.Property(e => e.UserInsertId)
            .IsRequired(false);

        builder.Property(e => e.UserUpdateId)
            .IsRequired(false);

        builder.Property(e => e.UserDeleteId)
            .IsRequired(false);

        builder.Property(e => e.RowVersion)
            .IsRowVersion();

        builder.HasQueryFilter(e =>
            EF.Property<DateTime?>(e, nameof(ISoftDeletable.DateDelete)) == null);

        builder.HasIndex(nameof(ISoftDeletable.DateDelete))
            .HasFilter($"{nameof(ISoftDeletable.DateDelete)} IS NULL");
    }
}
