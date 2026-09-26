// <copyright file="QuotationRowConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class QuotationRowConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<QuotationRow>
{
    public void Configure(EntityTypeBuilder<QuotationRow> builder)
    {
        builder.ToTable("QuotationRow", "dbo");


        builder.Property(e => e.Year).IsRequired();
        builder.Property(e => e.QuotationId).IsRequired();
        builder.Property(e => e.ArticleId).IsRequired(false);
        builder.Property(e => e.ArticleCode).HasMaxLength(255).IsUnicode(false).IsRequired(false);
        builder.Property(e => e.Quantity).HasPrecision(18, 8).IsRequired(false);
        builder.Property(e => e.UnitPrice).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.DiscountPercentage).HasPrecision(18, 8).IsRequired();
        builder.Property(e => e.Amount).HasPrecision(18, 8).IsRequired(false);
        builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        builder.Property(e => e.InsertionDate).HasColumnType("datetime").IsRequired(false);
        builder.Property(e => e.IsSale).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Article)
            .WithMany(p => p.QuotationRows)
            .HasForeignKey(e => e.ArticleId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Quotation)
            .WithMany(p => p.QuotationRows)
            .HasForeignKey(e => e.QuotationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
