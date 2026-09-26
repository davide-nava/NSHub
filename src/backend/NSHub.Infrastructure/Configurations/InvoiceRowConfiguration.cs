// <copyright file="InvoiceRowConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class InvoiceRowConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<InvoiceRow>
{
    public void Configure(EntityTypeBuilder<InvoiceRow> builder)
    {
        _ = builder.ToTable("InvoiceRow", "dbo");

        _ = builder.Property(e => e.Year).IsRequired();
        _ = builder.Property(e => e.InvoiceId).IsRequired();
        _ = builder.Property(e => e.ArticleId).IsRequired(false);
        _ = builder.Property(e => e.ArticleCode).HasMaxLength(255).IsUnicode(false).IsRequired(false);
        _ = builder.Property(e => e.Quantity).HasPrecision(18, 8).IsRequired(false);
        _ = builder.Property(e => e.UnitPrice).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.DiscountPercentage).HasPrecision(18, 8).IsRequired();
        _ = builder.Property(e => e.Amount).HasPrecision(18, 8).IsRequired(false);
        _ = builder.Property(e => e.VatId).IsRequired(false);
        _ = builder.Property(e => e.LineTotal).HasPrecision(18, 8).IsRequired();
        _ = builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        _ = builder.Property(e => e.RowNumber).HasPrecision(18, 8).IsRequired(false);

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Article)
            .WithMany(p => p.InvoiceRows)
            .HasForeignKey(e => e.ArticleId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Invoice)
            .WithMany(p => p.InvoiceRows)
            .HasForeignKey(e => e.InvoiceId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Vat)
            .WithMany(p => p.InvoiceRows)
            .HasForeignKey(e => e.VatId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
