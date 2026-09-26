// <copyright file="ArticleMachineConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class ArticleMachineConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<ArticleMachine>
{
    public void Configure(EntityTypeBuilder<ArticleMachine> builder)
    {
        _ = builder.ToTable("ArticleMachine", "dbo");

        _ = builder.Property(e => e.ArticleId).IsRequired();
        _ = builder.Property(e => e.ArticleGroupId).IsRequired(false);
        _ = builder.Property(e => e.MachineId).IsRequired(false);
        _ = builder.Property(e => e.Quantity).HasPrecision(18, 8).IsRequired();
        _ = builder.Property(e => e.Notes).IsUnicode(false).IsRequired(false);

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Article)
            .WithMany(p => p.ArticleMachines)
            .HasForeignKey(e => e.ArticleId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.ArticleGroup)
            .WithMany(p => p.ArticleMachines)
            .HasForeignKey(e => e.ArticleGroupId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Machine)
            .WithMany(p => p.ArticleMachines)
            .HasForeignKey(e => e.MachineId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
