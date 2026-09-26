// <copyright file="DeliveryNoteRowConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class DeliveryNoteRowConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<DeliveryNoteRow>
{
    public void Configure(EntityTypeBuilder<DeliveryNoteRow> builder)
    {
        builder.ToTable("DeliveryNoteRow", "dbo");


        builder.Property(e => e.Year).IsRequired();
        builder.Property(e => e.DeliveryNoteId).IsRequired();
        builder.Property(e => e.OrderRowId).IsRequired(false);
        builder.Property(e => e.ArticleId).IsRequired(false);
        builder.Property(e => e.ArticleCode).HasMaxLength(255).IsUnicode(false).IsRequired(false);
        builder.Property(e => e.Quantity).HasPrecision(18, 8).IsRequired(false);
        builder.Property(e => e.UnitPrice).HasPrecision(18, 4).IsRequired(false);
        builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        builder.Property(e => e.UnitOfMeasureCode).HasMaxLength(50).IsUnicode(false).IsRequired();
        builder.Property(e => e.RowNumber).HasPrecision(18, 8).IsRequired(false);
        builder.Property(e => e.InsertionDate).HasColumnType("datetime").IsRequired(false);

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Article)
            .WithMany(p => p.DeliveryNoteRows)
            .HasForeignKey(e => e.ArticleId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.DeliveryNote)
            .WithMany(p => p.DeliveryNoteRows)
            .HasForeignKey(e => e.DeliveryNoteId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.OrderRow)
            .WithMany(p => p.DeliveryNoteRows)
            .HasForeignKey(e => e.OrderRowId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
