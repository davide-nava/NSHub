// <copyright file="ArticleGroupConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class ArticleGroupConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<ArticleGroup>
{
    public void Configure(EntityTypeBuilder<ArticleGroup> builder)
    {
        _ = builder.ToTable("ArticleGroup", "dbo");

        _ = builder.Property(e => e.Code).HasMaxLength(256).IsRequired();
        _ = builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        _ = builder.Property(e => e.Number).HasMaxLength(255).IsRequired();
        _ = builder.Property(e => e.Image).IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
