// <copyright file="ArticleConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class ArticleConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        _ = builder.ToTable("Article", "dbo");

        _ = builder.Property(e => e.ParentArticleId).IsRequired(false);
        _ = builder.Property(e => e.ArticleBrandId).IsRequired(false);
        _ = builder.Property(e => e.ArticleCategoryId).IsRequired(false);
        _ = builder.Property(e => e.WarehouseId).IsRequired(false);
        _ = builder.Property(e => e.ArticleTypeId).IsRequired(false);
        _ = builder.Property(e => e.UnitOfMeasureId).IsRequired();
        _ = builder.Property(e => e.SupplierId).IsRequired(false);
        _ = builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        _ = builder.Property(e => e.Number).HasMaxLength(255).IsRequired();
        _ = builder.Property(e => e.Quantity).HasPrecision(18, 8).IsRequired();
        _ = builder.Property(e => e.Image).IsRequired();
        _ = builder.Property(e => e.Amount).HasPrecision(18, 8).IsRequired(false);
        _ = builder.Property(e => e.MinimumStock).HasPrecision(18, 8).IsRequired(false);
        _ = builder.Property(e => e.PurchasePrice).HasPrecision(18, 4).IsRequired(false);
        _ = builder.Property(e => e.SalePrice).HasPrecision(18, 4).IsRequired(false);
        _ = builder.Property(e => e.InternalArticleCode).IsRequired(false);
        _ = builder.Property(e => e.SupplierArticleCode).IsRequired(false);
        _ = builder.Property(e => e.FsFolder).IsRequired(false);
        _ = builder.Property(e => e.Website).IsRequired(false);
        _ = builder.Property(e => e.Notes).HasColumnType("text").IsRequired(false);
        _ = builder.Property(e => e.FamilyCode).HasMaxLength(20).IsRequired(false);
        _ = builder.Property(e => e.Barcode).HasMaxLength(50).IsRequired(false);
        _ = builder.Property(e => e.Location).HasColumnType("text").IsRequired(false);
        _ = builder.Property(e => e.Program).HasColumnType("text").IsRequired(false);
        _ = builder.Property(e => e.ProcessingTime).HasMaxLength(255).IsRequired(false);
        _ = builder.Property(e => e.Search).IsRequired(false);
        _ = builder.Property(e => e.IsBatchManaged).IsRequired();
        _ = builder.Property(e => e.IsSerialNumberManaged).IsRequired();
        _ = builder.Property(e => e.IsActive).IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.ArticleBrand)
            .WithMany(p => p.Articles)
            .HasForeignKey(e => e.ArticleBrandId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.ArticleCategory)
            .WithMany(p => p.Articles)
            .HasForeignKey(e => e.ArticleCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.ArticleType)
            .WithMany(p => p.Articles)
            .HasForeignKey(e => e.ArticleTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.ParentArticle)
            .WithMany(p => p.ChildArticles)
            .HasForeignKey(e => e.ParentArticleId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.UnitOfMeasure)
            .WithMany(p => p.Articles)
            .HasForeignKey(e => e.UnitOfMeasureId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Warehouse)
            .WithMany(p => p.Articles)
            .HasForeignKey(e => e.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
