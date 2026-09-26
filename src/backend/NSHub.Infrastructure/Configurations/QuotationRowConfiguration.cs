// <copyright file="QuotationRowConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class QuotationRowConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<QuotationRow>
{
    public void Configure(EntityTypeBuilder<QuotationRow> builder)
    {
        _ = builder.ToTable("QuotationRow", "dbo");

        _ = builder.Property(e => e.Year).IsRequired();
        _ = builder.Property(e => e.QuotationId).IsRequired();
        _ = builder.Property(e => e.ArticleId).IsRequired(false);
        _ = builder.Property(e => e.ArticleCode).HasMaxLength(255).IsUnicode(false).IsRequired(false);
        _ = builder.Property(e => e.Quantity).HasPrecision(18, 8).IsRequired(false);
        _ = builder.Property(e => e.UnitPrice).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.DiscountPercentage).HasPrecision(18, 8).IsRequired();
        _ = builder.Property(e => e.Amount).HasPrecision(18, 8).IsRequired(false);
        _ = builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        _ = builder.Property(e => e.InsertionDate).HasColumnType("datetime").IsRequired(false);
        _ = builder.Property(e => e.IsSale).IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Article)
            .WithMany(p => p.QuotationRows)
            .HasForeignKey(e => e.ArticleId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Quotation)
            .WithMany(p => p.QuotationRows)
            .HasForeignKey(e => e.QuotationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
