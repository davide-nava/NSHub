// <copyright file="ArticleConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Warehouse.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Warehouse.ValueObjects;

/// <summary>
/// EF Core configuration for <see cref="NSHub.Domain.Entities.Article"/>.
/// </summary>
public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        _ = builder.ToTable("Articles");

        _ = builder.HasKey(a => a.Id);
        _ = builder.Property(a => a.Id)
            .HasConversion(id => id.Value, value => new ArticleId(value))
            .ValueGeneratedNever();

        _ = builder.Property(a => a.Code)
            .HasMaxLength(50)
            .IsRequired();

        _ = builder.HasIndex(a => a.Code).IsUnique();

        _ = builder.Property(a => a.Name)
            .HasMaxLength(200)
            .IsRequired();

        _ = builder.Property(a => a.Description)
            .HasMaxLength(1000);

        _ = builder.Property(a => a.UnitOfMeasure)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        _ = builder.Property(a => a.IsActive)
            .IsRequired();
    }
}
