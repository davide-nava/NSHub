// <copyright file="ArticleGroupMapConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class ArticleGroupMapConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<ArticleGroupMap>
{
    public void Configure(EntityTypeBuilder<ArticleGroupMap> builder)
    {
        _ = builder.ToTable("ArticleGroupMap", "dbo");

        _ = builder.Property(e => e.ArticleId).IsRequired();
        _ = builder.Property(e => e.ArticleGroupId).IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Article)
            .WithMany(p => p.ArticleGroupMaps)
            .HasForeignKey(e => e.ArticleId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.ArticleGroup)
            .WithMany(p => p.ArticleGroupMaps)
            .HasForeignKey(e => e.ArticleGroupId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
