// <copyright file="PageConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Infrastructure.Cms.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Cms.Entities;
using NSHub.Domain.Cms.ValueObjects;

/// <summary>
/// EF Core configuration for <see cref="Page"/>.
/// </summary>
public class PageConfiguration : IEntityTypeConfiguration<Page>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Page> builder)
    {
        _ = builder.ToTable("CmsPages");

        _ = builder.HasKey(p => p.Id);
        _ = builder.Property(p => p.Id)
            .HasConversion(id => id.Value, value => new PageId(value))
            .ValueGeneratedNever();

        _ = builder.Property(p => p.Title)
            .HasMaxLength(200)
            .IsRequired();

        _ = builder.Property(p => p.Slug)
            .HasMaxLength(250)
            .IsRequired();

        _ = builder.HasIndex(p => p.Slug).IsUnique();

        _ = builder.Property(p => p.Content)
            .IsRequired();

        _ = builder.Property(p => p.Summary)
            .HasMaxLength(1000);

        _ = builder.Property(p => p.AuthorId)
            .IsRequired();

        _ = builder.Property(p => p.Status)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        _ = builder.OwnsOne(p => p.Seo, seoBuilder =>
        {
            _ = seoBuilder.Property(s => s.MetaTitle).HasMaxLength(200);
            _ = seoBuilder.Property(s => s.MetaDescription).HasMaxLength(500);
            _ = seoBuilder.Property(s => s.MetaKeywords).HasMaxLength(500);
            _ = seoBuilder.Property(s => s.CanonicalUrl).HasMaxLength(500);
        });

        _ = builder.Property(p => p.PublishedAtUtc);
        _ = builder.Property(p => p.CreatedAtUtc).IsRequired();

        _ = builder.HasMany(p => p.Tags)
            .WithOne()
            .HasForeignKey(t => t.PageId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Metadata.FindNavigation(nameof(Page.Tags))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
