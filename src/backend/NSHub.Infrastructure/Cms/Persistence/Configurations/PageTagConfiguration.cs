// <copyright file="PageTagConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Infrastructure.Cms.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Cms.Entities;
using NSHub.Domain.Cms.ValueObjects;

/// <summary>
/// EF Core configuration for <see cref="PageTag"/>.
/// </summary>
public class PageTagConfiguration : IEntityTypeConfiguration<PageTag>
{
    public void Configure(EntityTypeBuilder<PageTag> builder)
    {
        _ = builder.ToTable("CmsPageTags");

        _ = builder.HasKey(pt => new { pt.PageId, pt.TagId });

        _ = builder.Property(pt => pt.PageId)
            .HasConversion(id => id.Value, value => new PageId(value));

        _ = builder.Property(pt => pt.TagId)
            .HasConversion(id => id.Value, value => new TagId(value));

        _ = builder.Property(pt => pt.Name)
            .HasMaxLength(100)
            .IsRequired();

        _ = builder.HasIndex(pt => pt.Name);
    }
}
