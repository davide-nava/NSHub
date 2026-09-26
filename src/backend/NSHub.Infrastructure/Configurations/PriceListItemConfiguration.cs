// <copyright file="PriceListItemConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class PriceListItemConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<PriceListItem>
{
    public void Configure(EntityTypeBuilder<PriceListItem> builder)
    {
        builder.ToTable("PriceListItem", "dbo");


        builder.Property(e => e.PriceListId).IsRequired();
        builder.Property(e => e.ArticleId).IsRequired();
        builder.Property(e => e.Price).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.MinQuantity).HasPrecision(18, 8).IsRequired();
        builder.Property(e => e.DiscountPercentage).HasPrecision(18, 8).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Article)
            .WithMany(p => p.PriceListItems)
            .HasForeignKey(e => e.ArticleId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.PriceList)
            .WithMany(p => p.PriceListItems)
            .HasForeignKey(e => e.PriceListId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
