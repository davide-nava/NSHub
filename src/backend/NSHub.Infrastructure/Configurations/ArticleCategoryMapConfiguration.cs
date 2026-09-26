// <copyright file="ArticleCategoryMapConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class ArticleCategoryMapConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<ArticleCategoryMap>
{
    public void Configure(EntityTypeBuilder<ArticleCategoryMap> builder)
    {
        builder.ToTable("ArticleCategoryMap", "dbo");


        builder.Property(e => e.ArticleId).IsRequired();
        builder.Property(e => e.ArticleCategoryId).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
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
