// <copyright file="ArticleCategoryMapConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class ArticleCategoryMapConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<ArticleCategoryMap>
{
    public void Configure(EntityTypeBuilder<ArticleCategoryMap> builder)
    {
        _ = builder.ToTable("ArticleCategoryMap", "dbo");

        _ = builder.Property(e => e.ArticleId).IsRequired();
        _ = builder.Property(e => e.ArticleCategoryId).IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Article)
            .WithMany(p => p.ArticleCategoryMaps)
            .HasForeignKey(e => e.ArticleId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.ArticleCategory)
            .WithMany(p => p.ArticleCategoryMaps)
            .HasForeignKey(e => e.ArticleCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
