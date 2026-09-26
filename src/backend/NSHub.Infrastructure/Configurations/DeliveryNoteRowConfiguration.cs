// <copyright file="DeliveryNoteRowConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class DeliveryNoteRowConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<DeliveryNoteRow>
{
    public void Configure(EntityTypeBuilder<DeliveryNoteRow> builder)
    {
        _ = builder.ToTable("DeliveryNoteRow", "dbo");

        _ = builder.Property(e => e.Year).IsRequired();
        _ = builder.Property(e => e.DeliveryNoteId).IsRequired();
        _ = builder.Property(e => e.OrderRowId).IsRequired(false);
        _ = builder.Property(e => e.ArticleId).IsRequired(false);
        _ = builder.Property(e => e.ArticleCode).HasMaxLength(255).IsUnicode(false).IsRequired(false);
        _ = builder.Property(e => e.Quantity).HasPrecision(18, 8).IsRequired(false);
        _ = builder.Property(e => e.UnitPrice).HasPrecision(18, 4).IsRequired(false);
        _ = builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        _ = builder.Property(e => e.UnitOfMeasureCode).HasMaxLength(50).IsUnicode(false).IsRequired();
        _ = builder.Property(e => e.RowNumber).HasPrecision(18, 8).IsRequired(false);
        _ = builder.Property(e => e.InsertionDate).HasColumnType("datetime").IsRequired(false);

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Article)
            .WithMany(p => p.DeliveryNoteRows)
            .HasForeignKey(e => e.ArticleId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.DeliveryNote)
            .WithMany(p => p.DeliveryNoteRows)
            .HasForeignKey(e => e.DeliveryNoteId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.OrderRow)
            .WithMany(p => p.DeliveryNoteRows)
            .HasForeignKey(e => e.OrderRowId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
