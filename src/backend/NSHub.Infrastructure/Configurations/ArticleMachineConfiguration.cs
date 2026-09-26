// <copyright file="ArticleMachineConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class ArticleMachineConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<ArticleMachine>
{
    public void Configure(EntityTypeBuilder<ArticleMachine> builder)
    {
        builder.ToTable("ArticleMachine", "dbo");


        builder.Property(e => e.ArticleId).IsRequired();
        builder.Property(e => e.ArticleGroupId).IsRequired(false);
        builder.Property(e => e.MachineId).IsRequired(false);
        builder.Property(e => e.Quantity).HasPrecision(18, 8).IsRequired();
        builder.Property(e => e.Notes).IsUnicode(false).IsRequired(false);

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
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
