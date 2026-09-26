// <copyright file="PriceListItemConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class PriceListItemConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<PriceListItem>
{
    public void Configure(EntityTypeBuilder<PriceListItem> builder)
    {
        _ = builder.ToTable("PriceListItem", "dbo");

        _ = builder.Property(e => e.PriceListId).IsRequired();
        _ = builder.Property(e => e.ArticleId).IsRequired();
        _ = builder.Property(e => e.Price).HasPrecision(18, 4).IsRequired();
        _ = builder.Property(e => e.MinQuantity).HasPrecision(18, 8).IsRequired();
        _ = builder.Property(e => e.DiscountPercentage).HasPrecision(18, 8).IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Article)
            .WithMany(p => p.PriceListItems)
            .HasForeignKey(e => e.ArticleId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.PriceList)
            .WithMany(p => p.PriceListItems)
            .HasForeignKey(e => e.PriceListId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
