using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("Article", "dbo");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).IsRequired();
        builder.Property(e => e.DateInsert).HasColumnType("datetime").IsRequired();
        builder.Property(e => e.DateDelete).HasColumnType("datetime").IsRequired(false);
        builder.Property(e => e.DateUpdate).HasColumnType("datetime").IsRequired();
        builder.Property(e => e.UserInsertId).IsRequired(false);
        builder.Property(e => e.UserDeleteId).IsRequired(false);
        builder.Property(e => e.UserUpdateId).IsRequired(false);
        builder.Property(e => e.TenantId).IsRequired(false);
        builder.Property(e => e.RowVersion).IsRowVersion();
        builder.Property(e => e.ParentArticleId).IsRequired(false);
        builder.Property(e => e.ArticleBrandId).IsRequired(false);
        builder.Property(e => e.ArticleCategoryId).IsRequired(false);
        builder.Property(e => e.WarehouseId).IsRequired(false);
        builder.Property(e => e.ArticleTypeId).IsRequired(false);
        builder.Property(e => e.UnitOfMeasureId).IsRequired();
        builder.Property(e => e.SupplierId).IsRequired(false);
        builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        builder.Property(e => e.Number).HasMaxLength(255).IsRequired();
        builder.Property(e => e.Quantity).HasPrecision(18, 8).IsRequired();
        builder.Property(e => e.Image).IsRequired();
        builder.Property(e => e.Amount).HasPrecision(18, 8).IsRequired(false);
        builder.Property(e => e.MinimumStock).HasPrecision(18, 8).IsRequired(false);
        builder.Property(e => e.PurchasePrice).HasPrecision(18, 4).IsRequired(false);
        builder.Property(e => e.SalePrice).HasPrecision(18, 4).IsRequired(false);
        builder.Property(e => e.InternalArticleCode).IsRequired(false);
        builder.Property(e => e.SupplierArticleCode).IsRequired(false);
        builder.Property(e => e.FsFolder).IsRequired(false);
        builder.Property(e => e.Website).IsRequired(false);
        builder.Property(e => e.Notes).HasColumnType("text").IsRequired(false);
        builder.Property(e => e.FamilyCode).HasMaxLength(20).IsRequired(false);
        builder.Property(e => e.Barcode).HasMaxLength(50).IsRequired(false);
        builder.Property(e => e.Location).HasColumnType("text").IsRequired(false);
        builder.Property(e => e.Program).HasColumnType("text").IsRequired(false);
        builder.Property(e => e.ProcessingTime).HasMaxLength(255).IsRequired(false);
        builder.Property(e => e.Search).IsRequired(false);
        builder.Property(e => e.IsBatchManaged).IsRequired();
        builder.Property(e => e.IsSerialNumberManaged).IsRequired();
        builder.Property(e => e.IsActive).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.ArticleBrand)
            .WithMany(p => p.Articles)
            .HasForeignKey(e => e.ArticleBrandId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.ArticleCategory)
            .WithMany(p => p.Articles)
            .HasForeignKey(e => e.ArticleCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.ArticleType)
            .WithMany(p => p.Articles)
            .HasForeignKey(e => e.ArticleTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.ParentArticle)
            .WithMany(p => p.ChildArticles)
            .HasForeignKey(e => e.ParentArticleId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.UnitOfMeasure)
            .WithMany(p => p.Articles)
            .HasForeignKey(e => e.UnitOfMeasureId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Warehouse)
            .WithMany(p => p.Articles)
            .HasForeignKey(e => e.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
